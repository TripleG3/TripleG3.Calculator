using Specky7;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TripleG3.Calculator.Core;
using TripleG3.Calculator.Core.Exceptions;
using TripleG3.Calculator.Maui.ViewModels.Commands;

namespace TripleG3.Calculator.Maui.ViewModels;

[Scoped]
public sealed class ExpressionViewModel : ViewModelBase
{
    public ExpressionViewModel(ICalculator calculator)
    {
        AddToExpressionCommand = new RelayCommand(AddToExpression);
        DeleteFromEndOfExpressionCommand = new RelayCommand(x => DeleteFromEndOfExpression());
        SolveExpressionCommand = new RelayCommand(x => SolveExpression(calculator));
        ClearExpressionCommand = new RelayCommand(x => ClearExpression());

        expression = string.Empty;
        information = string.Empty;
        result = 0d;
    }

    private string expression;
    private double result;
    private string information;

    public ICommand SolveExpressionCommand { get; }
    public ICommand AddToExpressionCommand { get; }
    public ICommand DeleteFromEndOfExpressionCommand { get; }
    public ICommand ClearExpressionCommand { get; }

    public ObservableCollection<string> Expressions { get; } = [];

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
    
    public string Information
    {
        get => information;
        set
        {
            information = value;
            Notify();
            if (!string.IsNullOrWhiteSpace(value))
            {
                Vibration.Default.TryVibrate(200);
            }
        }
    }

    private void AddToExpression(object? x)
    {
        Information = string.Empty;
        if (x is string str)
        {
            Expression += str;
        }
    }

    private void DeleteFromEndOfExpression()
    {
        Information = string.Empty;
        Expression = expression.Length > 0 ? expression[..^1] : string.Empty;
    }

    private void ClearExpression()
    {
        Information = string.Empty;
        Expression = string.Empty;
        Result = 0d;
    }

    private void SolveExpression(ICalculator calculator)
    {
        try
        {
            Result = calculator.Calculate(Expression);
        }
        catch (ExpressionFormatInvalidException ex)
        {
            Information = ex.Message;
            return;
        }
        Expressions.Add(Expression);
        Expression = string.Empty;
    }
}