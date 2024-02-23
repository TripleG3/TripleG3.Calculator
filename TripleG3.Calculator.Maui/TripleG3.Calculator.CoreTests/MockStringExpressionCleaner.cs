namespace TripleG3.Calculator.Core.Tests;

internal class MockStringExpressionCleaner : IStringExpressionCleaner
{
    public IReadOnlyCollection<string> CleanItems { get; } = [];

    public string Clean(string expression)
    {
        return expression;
    }
}

internal class MockStringExpressionParenthesisCorrector : IStringExpressionParenthesisCorrector
{
    public string Correct(string expression)
    {
        return expression;
    }
}