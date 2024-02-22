﻿using System.Windows.Input;

namespace TripleG3.Calculator.Maui.ViewModels.Commands;

public class RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null) : ICommand
{
    private readonly Action<object?> execute = execute;
    private readonly Predicate<object?>? canExecute = canExecute;

    public event EventHandler? CanExecuteChanged;
    public bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;
    public void Execute(object? parameter) => execute(parameter);
}
