﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Verleihsystem.Services
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T?> _execute;
        private readonly Predicate<T?>? _canExecute;

        public RelayCommand(Action<T?> execute) : this(execute, null)
        { }

        public RelayCommand(Action<T?> execute, Predicate<T?>? canExecute)
        { 
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) 
            => _canExecute == null || (parameter == null ? _canExecute(default) : _canExecute((T)parameter));

        public void Execute(object? parameter)
        {
            if (parameter == null) _execute(default);
            else _execute((T)parameter);
        }
    }
}
