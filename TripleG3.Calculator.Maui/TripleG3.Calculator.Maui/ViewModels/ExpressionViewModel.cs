using Specky7;
using System.Collections.ObjectModel;
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
        ClearExpressionCommand = new RelayCommand(x => ClearExpression());
    }

    private string expression = string.Empty;
    private double result;

    public ICommand SolveExpressionCommand { get; }
    public ICommand AddToExpressionCommand { get; }
    public ICommand DeleteFromEndOfExpressionCommand { get; }
    public ICommand ClearExpressionCommand { get; }

    public ObservableCollection<string> Expressions { get; } = new();

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

    private void ClearExpression()
    {
        Expression = string.Empty;
    }

    private void SolveExpression(IStringExpressionSolver stringExpressionSolver)
    {
        Result = stringExpressionSolver.Solve(Expression);
        Expressions.Add(Expression);
        Expression = string.Empty;
    }
}