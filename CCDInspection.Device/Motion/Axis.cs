using System;
using System.Threading;
using System.Threading.Tasks;
using CCDInspection.Core.Interfaces.Hardware;
using CCDInspection.Core.Models;
using CCDInspection.Core;
using System.Runtime.InteropServices;

namespace CCDInspection.Device.Motion
{
    /// <summary>
    /// 单轴实现（封装 ZMC 底层调用，支持 CancellationToken）
    /// </summary>
    public class Axis : IAxis
    {
        /// <summary>
        /// ZMC控制器句柄（从ZmcController传入），用于调用底层API
        /// </summary>
        private readonly IntPtr _handle;
        /// <summary>
        /// 轮询事件完成的时间间隔（毫秒）
        /// </summary>
        private readonly int _pollIntervalMs;

        public int Index { get; }
        public float CurrentPosition
        {
            get
            {
                float pos = 0;
                ZmcApi.ZAux_Direct_GetDpos(_handle, Index, ref pos);
                return pos;
            }
        }
        public bool IsMoving
        {
            get
            {
                int idle = 0;
                ZmcApi.ZAux_Direct_GetIfIdle(_handle, Index, ref idle);
                return idle == 0;
            }
        }

        public Axis(IntPtr handle, int index, int pollIntervalMs = 10)
        {
            _handle = handle;
            Index = index;
            _pollIntervalMs = pollIntervalMs;
        }

        public Task<bool> MoveAbs(float position, float? speed = null)
        {
            return MoveAbsAsync(position, speed, CancellationToken.None);
        }

        public Task<bool> MoveRel(float distance, float? speed = null)
        {
            return MoveRelAsync(distance, speed, CancellationToken.None);
        }

        public Task<bool> Home(AxisConfig config)
        {
            return HomeAsync(config, CancellationToken.None);
        }

        /// <summary>
        /// 带取消支持的绝对移动
        /// </summary>
        public Task<bool> MoveAbsAsync(float position, float? speed = null, CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                try
                {
                    ct.ThrowIfCancellationRequested();

                    if (speed.HasValue)
                        ZmcApi.ZAux_Direct_SetSpeed(_handle, Index, speed.Value);

                    int ret = ZmcApi.ZAux_Direct_Single_MoveAbs(_handle, Index, position);
                    if (ret != 0)
                    {
                        LogService.Error("Z轴绝对移动失败, 目标={Position}, 错误码={Error}", position, ret);
                        return false;
                    }

                    WaitForDone(ct);
                    return true;
                }
                catch (OperationCanceledException)
                {
                    Stop();
                    LogService.Information("Z轴移动已取消");
                    return false;
                }
                catch (Exception ex)
                {
                    LogService.Error(ex, "Z轴绝对移动异常");
                    return false;
                }
            }, ct);
        }

        /// <summary>
        /// 带取消支持的相对移动
        /// </summary>
        public Task<bool> MoveRelAsync(float distance, float? speed = null, CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                try
                {
                    ct.ThrowIfCancellationRequested();

                    if (speed.HasValue)
                        ZmcApi.ZAux_Direct_SetSpeed(_handle, Index, speed.Value);

                    int ret = ZmcApi.ZAux_Direct_Single_Move(_handle, Index, distance);
                    if (ret != 0)
                    {
                        LogService.Error("Z轴相对移动失败, 距离={Distance}, 错误码={Error}", distance, ret);
                        return false;
                    }

                    WaitForDone(ct);
                    return true;
                }
                catch (OperationCanceledException)
                {
                    Stop();
                    LogService.Information("Z轴移动已取消");
                    return false;
                }
                catch (Exception ex)
                {
                    LogService.Error(ex, "Z轴相对移动异常");
                    return false;
                }
            }, ct);
        }

        /// <summary>
        /// 带取消支持的回零
        /// </summary>
        public Task<bool> HomeAsync(AxisConfig config, CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                try
                {
                    ct.ThrowIfCancellationRequested();

                    LogService.Information("[回零] 轴{Index} 开始 | Model={Mode} Spd={HS} Creep={CS} OriginIO={OIO}",
                        Index, config.HomeModel, config.HomeSpeed, config.CreepSpeed, config.OriginIo);

                    if (config.HomeModel <= 0) { LogService.Error("[回零] HomeModel={M}无效", config.HomeModel); return false; }

                    // 读取状态
                    float curPos = 0, axisStatus = 0; int idle = 0;
                    ZmcApi.ZAux_Direct_GetDpos(_handle, Index, ref curPos);
                    ZmcApi.ZAux_Direct_GetIfIdle(_handle, Index, ref idle);
                    ZmcApi.ZAux_Direct_GetParam(_handle, "AXISSTATUS", Index, ref axisStatus);
                    LogService.Information("[回零] 轴{Index} 位置={Pos:F2} 空闲={Idle} AXISSTATUS={St}",
                        Index, curPos, idle, axisStatus);

                    // 如果在限位上，先用 CreepSpeed 反向 Vmove 退出，超时最多 3 秒
                    int ast = (int)axisStatus;
                    if ((ast & 0x0010) != 0 || (ast & 0x0020) != 0)
                    {
                        int dir = (ast & 0x0010) != 0 ? -1 : 1;
                        LogService.Information("[回零] 轴{Index} 在限位, 先退出 dir={Dir}", Index, dir);
                        ZmcApi.ZAux_Direct_SetSpeed(_handle, Index, config.CreepSpeed > 0 ? config.CreepSpeed : config.HomeSpeed / 4);
                        ZmcApi.ZAux_Direct_Single_Vmove(_handle, Index, dir);
                        // 等待直到退出限位或 3 秒超时
                        int exitWait = 0;
                        while (exitWait < 30)
                        {
                            Thread.Sleep(100); exitWait++;
                            float exitSt = 0;
                            ZmcApi.ZAux_Direct_GetParam(_handle, "AXISSTATUS", Index, ref exitSt);
                            if (((int)exitSt & 0x0030) == 0) break; // 正负限位都清除了
                        }
                        ZmcApi.ZAux_Direct_Single_Cancel(_handle, Index, 2);
                        Thread.Sleep(100);
                        // 再次确认已退出限位
                        float confirmSt = 0;
                        ZmcApi.ZAux_Direct_GetParam(_handle, "AXISSTATUS", Index, ref confirmSt);
                        if (((int)confirmSt & 0x0030) != 0)
                        {
                            LogService.Error("[回零] 轴{Index} 限位退出失败! AXISSTATUS={St}", Index, (int)confirmSt);
                            return false;
                        }
                        LogService.Information("[回零] 轴{Index} 已退出限位 | 耗时={Ms}ms 位置={Pos:F2}",
                            Index, exitWait * 100, CurrentPosition);
                    }

                    // 退出限位成功后，先反向走一小段确保不再触发限位
                    float exitPos = 0;
                    ZmcApi.ZAux_Direct_GetDpos(_handle, Index, ref exitPos);
                    float safeOffset = config.CreepSpeed > 0 ? config.CreepSpeed : 20f;
                    if (ast != 0)
                    {
                        int safeDir = (ast & 0x0010) != 0 ? -1 : 1; // 正限位往负走，反之
                        LogService.Information("[回零] 限位安全偏移 dir={Dir} 距离={Dist:F1}", safeDir, safeOffset);
                        ZmcApi.ZAux_Direct_SetSpeed(_handle, Index, safeOffset);
                        ZmcApi.ZAux_Direct_Single_Move(_handle, Index, safeDir * safeOffset);
                        // 等待偏移完成
                        int offsetWait = 0;
                        while (offsetWait < 100)
                        {
                            Thread.Sleep(50); offsetWait++;
                            int idleCheck = 0;
                            ZmcApi.ZAux_Direct_GetIfIdle(_handle, Index, ref idleCheck);
                            if (idleCheck != 0) break;
                        }
                    }

                    // 参数设置
                    ZmcApi.ZAux_Direct_SetSpeed(_handle, Index, config.HomeSpeed);
                    ZmcApi.ZAux_Direct_SetCreep(_handle, Index, config.CreepSpeed > 0 ? config.CreepSpeed : config.HomeSpeed / 4);
                    ZmcApi.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", Index, 0);

                    // 控制器回零
                    int ret = ZmcApi.ZAux_Direct_Single_Datum(_handle, Index, config.HomeModel);
                    LogService.Information("[回零] Single_Datum(mode={M}) ret={R}", config.HomeModel, ret);
                    if (ret != 0) { LogService.Error("[回零] Single_Datum失败"); return false; }

                    // 等待完成
                    LogService.Information("[回零] 等待完成(超时30s)...");
                    int to = 0;
                    while (to < 300 && !ct.IsCancellationRequested)
                    {
                        Thread.Sleep(100); to++;
                        float st = 0; ZmcApi.ZAux_Direct_GetParam(_handle, "AXISSTATUS", Index, ref st);
                        if (to % 10 == 0) { float p = 0; ZmcApi.ZAux_Direct_GetDpos(_handle, Index, ref p); LogService.Information("[回零] {Sec}s 位置={Pos:F2} AXISSTATUS={St}", to / 10, p, (int)st); }
                        if (((int)st & 0x0040) == 0 && to > 5) break;
                    }
                    ZmcApi.ZAux_Direct_Single_Cancel(_handle, Index, 2);
                    ZmcApi.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", Index, 0);
                    LogService.Information("[回零] 完成 耗时={Sec}s", to / 10);

                    return true;
                }
                catch (OperationCanceledException) { Stop(); LogService.Information("[回零] 取消"); return false; }
                catch (Exception ex) { LogService.Error(ex, "[回零] 异常"); return false; }
            }, ct);
        }

        public void Jog(int direction, float speed)
        {
            ZmcApi.ZAux_Direct_SetSpeed(_handle, Index, speed);
            ZmcApi.ZAux_Direct_Single_Vmove(_handle, Index, direction);


        }

        public void Stop()
        {
            LogService.Information("[停止] 轴{Index} 停止运动", Index);
            ZmcApi.ZAux_Direct_Single_Cancel(_handle, Index, 2);
            // 短暂延迟后清除 CANCEL(2048) 状态，避免被 timer 误判为急停
            System.Threading.Thread.Sleep(50);
            ZmcApi.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", Index, 0);
        }

        public bool Enable()
        {
            // 先清除可能阻止使能的停止原因
            ZmcApi.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", Index, 0);
            // 脉冲轴使能
            int ret = ZmcApi.ZAux_Direct_SetAxisEnable(_handle, Index, 1);
            LogService.Information("[轴{Index}] 使能 | ret={Ret}", Index, ret);
            if (ret != 0) return false;
            // 验证使能
            System.Threading.Thread.Sleep(50);
            float status = 0;
            ZmcApi.ZAux_Direct_GetParam(_handle, "AXISSTATUS", Index, ref status);
            int st = (int)status;
            bool ok = (st & 0x0001) == 0; // bit0=0 表示已使能
            LogService.Information("[轴{Index}] 使能验证 AXISSTATUS={St} (bit0=0→使能={Ok})", Index, st, ok);
            return ok;
        }

        public bool Disable()
        {
            int ret = ZmcApi.ZAux_Direct_SetAxisEnable(_handle, Index, 0);
            LogService.Information("[轴{Index}] 去使能 | ret={Ret}", Index, ret);
            return ret == 0;
        }

        public void ClearAlarm()
        {
            LogService.Information("[轴{Index}] 清除报警", Index);
            // EtherCAT总线：清除驱动器报警(0=当前告警 2=外部告警)
            ZmcApi.ZAux_BusCmd_DriveClear(_handle, (uint)Index, 0);
            ZmcApi.ZAux_BusCmd_DriveClear(_handle, (uint)Index, 2);
            // 清除停止原因
            ZmcApi.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", Index, 0);
            ZmcApi.ZAux_Direct_Single_Cancel(_handle, Index, 2);
            // 重新使能
            System.Threading.Thread.Sleep(50);
            ZmcApi.ZAux_Direct_SetAxisEnable(_handle, Index, 1);
            LogService.Information("[轴{Index}] 报警清除完成", Index);
        }

        private void WaitForDone(CancellationToken ct, Action onPoll = null)
        {
            while (IsMoving)
            {
                ct.ThrowIfCancellationRequested();
                Thread.Sleep(_pollIntervalMs);
                onPoll?.Invoke();
            }
        }

        public void TestHom(AxisConfig axisConfig)
        {
            ZmcApi.ZAux_Direct_SetSpeed(_handle, Index, axisConfig.HomeSpeed);
            ZmcApi.ZAux_Direct_SetCreep(_handle, Index, axisConfig.HomeSpeed/4);
            ZmcApi.ZAux_Direct_SetParam(_handle, "AXIS_STOPREASON", Index, 0);
        }

    }
}
