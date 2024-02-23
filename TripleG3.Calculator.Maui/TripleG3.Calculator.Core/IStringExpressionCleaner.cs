namespace TripleG3.Calculator.Core;

public interface IStringExpressionCleaner
{
    IReadOnlyCollection<string> CleanItems { get; }
    string Clean(string expression);
}
