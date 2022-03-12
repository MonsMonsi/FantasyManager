using System;
using System.Windows.Input;

namespace FantasyManager.WPF.Commands
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            { CommandManager.RequerySuggested += value; }
            remove
            { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action m_execute;
        private readonly Func<bool> m_canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            m_execute = execute;
            m_canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return m_canExecute == null ? true : m_canExecute();
        }

        public void Execute(object parameter)
        {
            m_execute();
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
