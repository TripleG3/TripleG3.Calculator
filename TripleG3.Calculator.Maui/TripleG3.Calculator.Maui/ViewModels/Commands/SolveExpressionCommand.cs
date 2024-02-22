using Specky7;
using System.Windows.Input;
using TripleG3.Calculator.Core;

namespace TripleG3.Calculator.Maui.ViewModels.Commands;

[Transient]
public class SolveExpressionCommand(IStringExpressionSolver stringExpressionSolver) : ICommandResult<string, double>
{
    private readonly IStringExpressionSolver stringExpressionSolver = stringExpressionSolver;
    public event EventHandler? CanExecuteChanged;
    public double Result { get; private set; }
    public bool CanExecute(string parameter) => CanExecute((object)parameter);
    public bool CanExecute(object? parameter) => parameter is string expression && !string.IsNullOrWhiteSpace(expression);
    public void Execute(object? parameter) => Result = stringExpressionSolver.Solve((string)parameter!);
    void ICommand<string>.Execute(string parameter) => Execute(parameter);
    public double Execute(string parameter)
    {
        Execute((object)parameter);
        return Result;
    }
}
