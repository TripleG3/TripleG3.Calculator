namespace TripleG3.Calculator.Core.Tests;

[TestClass()]
public class StringExpressionSolverTests
{
    [TestMethod()]
    public void SolveTest()
    {
        //Arrange
        var expected = -1.8681640625d;
        var mockStringExpressionMutator = new MockStringExpressionMutator();
        var mockStringExpressionCleaner = new MockStringExpressionCleaner();
        var actor = new StringExpressionSolver(mockStringExpressionMutator, mockStringExpressionCleaner);

        //Act
        var result = actor.Solve("((1+2·3)/4^5)+6-7/8·9+0");

        //Assert
        Assert.AreEqual(expected, result);
    }
}

internal class MockStringExpressionCleaner : IStringExpressionCleaner
{
    public IReadOnlyCollection<string> CleanItems { get; } = [];

    public string Clean(string expression)
    {
        return expression;
    }
}