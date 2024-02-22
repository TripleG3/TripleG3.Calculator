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
        var actor = new StringExpressionSolver(mockStringExpressionMutator);

        //Act
        var result = actor.Solve("((1+2·3)/4^5)+6-7/8·9+0");

        //Assert
        Assert.AreEqual(expected, result);
    }
}

internal class MockStringExpressionMutator : IStringExpressionMutator
{
    public IReadOnlyDictionary<string, string> StringToReplacements => throw new NotImplementedException();
    public string Mutate(string expression) => expression;
}