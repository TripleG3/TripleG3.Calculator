namespace TripleG3.Calculator.Maui.ViewModels.Commands;

public interface ICommandResult<TValue, TResult> : ICommand<TValue>
{
    new TResult Execute(TValue parameter);
}
