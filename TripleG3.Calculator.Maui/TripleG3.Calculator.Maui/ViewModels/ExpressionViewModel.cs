﻿using Specky7;
using System.Windows.Input;
using TripleG3.Calculator.Core;
using TripleG3.Calculator.Maui.ViewModels.Commands;

namespace TripleG3.Calculator.Maui.ViewModels;

[Scoped]
public sealed class ExpressionViewModel : ViewModelBase
{
    public ExpressionViewModel(IStringExpressionSolver stringExpressionSolver)
    {
        AddToExpressionCommand = new RelayCommand(AddToExpression);
        DeleteFromEndOfExpressionCommand = new RelayCommand(x => DeleteFromEndOfExpression());
        SolveExpressionCommand = new RelayCommand(x => SolveExpression(stringExpressionSolver));
    }

    private string expression = string.Empty;
    private double result;

    public ICommand SolveExpressionCommand { get; }
    public ICommand AddToExpressionCommand { get; }
    public ICommand DeleteFromEndOfExpressionCommand { get; }

    public string Expression
    {
        get => expression;
        set
        {
            expression = value;
            Notify();
        }
    }

    public double Result
    {
        get => result;
        set
        {
            result = value;
            Notify();
        }
    }

    private void AddToExpression(object? x)
    {
        if (x is string str)
        {
            Expression += str;
        }
    }

    private void DeleteFromEndOfExpression()
    {
        Expression = expression.Length > 0 ? expression[..^1] : string.Empty;
    }

    private void SolveExpression(IStringExpressionSolver stringExpressionSolver)
    {
        Result = stringExpressionSolver.Solve(Expression);
    }
}