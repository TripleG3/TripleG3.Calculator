namespace TripleG3.Calculator.Core;

public interface IStringExpressionMutator
{
    IReadOnlyDictionary<string, string> StringToReplacements { get; }
    string Mutate(string expression);
}