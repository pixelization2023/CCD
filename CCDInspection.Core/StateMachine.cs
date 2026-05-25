using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CCDInspection.Core
{
    /// <summary>
    /// 轻量级异步状态机引擎
    /// 锁只保护 CurrentState 变更瞬间，handler 在锁外执行，允许 handler 内部链式调用 TransitionToAsync
    /// </summary>
    public class StateMachine<TState> where TState : Enum
    {
        private readonly Dictionary<TState, Func<Task>> _handlers = new Dictionary<TState, Func<Task>>();
        private readonly SemaphoreSlim _stateLock = new SemaphoreSlim(1, 1);

        public TState CurrentState { get; private set; }
        public event Action<TState, TState> OnStateChanged;

        public StateMachine(TState initialState) { CurrentState = initialState; }

        public void Register(TState state, Func<Task> handler)
        {
            lock (_handlers) { _handlers[state] = handler; }
        }

        /// <summary>
        /// 异步状态转换
        /// 锁只包裹状态变更，handler 在锁外执行 → handler 内部可以递归调 TransitionToAsync 不死锁
        /// </summary>
        public async Task TransitionToAsync(TState newState)
        {
            if (!_handlers.ContainsKey(newState))
                throw new InvalidOperationException($"State '{newState}' not registered");

            TState oldState;
            Func<Task> handler;

            // —— 临界区：只保护状态变更 ——
            await _stateLock.WaitAsync();
            try
            {
                oldState = CurrentState;
                if (oldState.Equals(newState)) return; // 同状态跳过，防止顶层状态重复执行
                CurrentState = newState;
                handler = _handlers[newState];
            }
            finally
            {
                _stateLock.Release();
            }

            // —— 锁外：通知事件 + 执行 handler ——
            // 这样 handler（如 Paused→AutoRun, Alarm→Resetting→Idle）里再调 TransitionToAsync 时
            // 能正常获取锁，不会死锁
            OnStateChanged?.Invoke(oldState, newState);
            await handler();
        }
    }
}
