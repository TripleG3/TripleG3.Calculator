namespace TripleG3.Calculator.Core.Tests;

internal class MockStringExpressionParenthesisCorrector : IStringExpressionParenthesisCorrector
{
    public string Correct(string expression)
    {
        return expression;
    }
}