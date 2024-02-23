namespace TripleG3.Calculator.Core.Tests;

internal class MockStringExpressionMutator : IStringExpressionMutator
{
    public IReadOnlyDictionary<string, string> StringToReplacements => throw new NotImplementedException();
    public string Mutate(string expression) => expression;
}