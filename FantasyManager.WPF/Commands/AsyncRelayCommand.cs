using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyManager.WPF.Commands
{
    public class AsyncRelayCommand : AsyncCommandBase
    {
        private readonly Func<Task> _execute;

        public AsyncRelayCommand(Func<Task> execute, Action<Exception> onException) : base(onException)
        {
            _execute = execute;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            await _execute();
        }
    }

    public class AsyncRelayCommand<T> : AsyncCommandBase<T>
    {
        private readonly Func<T, Task> _execute;

        public AsyncRelayCommand(Func<T, Task> execute, Action<Exception> onException) : base(onException)
        {
            _execute = execute;
        }

        protected override async Task ExecuteAsync(T parameter)
        {
            await _execute(parameter);
        }
    }
}
