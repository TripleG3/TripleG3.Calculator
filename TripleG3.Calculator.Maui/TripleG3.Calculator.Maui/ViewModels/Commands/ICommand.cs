using System.Windows.Input;

namespace TripleG3.Calculator.Maui.ViewModels.Commands;

public interface ICommand<T> : ICommand
{
    bool CanExecute(T parameter);
    void Execute(T parameter);
}
