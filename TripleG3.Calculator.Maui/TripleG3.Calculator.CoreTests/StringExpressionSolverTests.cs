namespace TripleG3.Calculator.Core.Tests;

[TestClass()]
public class StringExpressionSolverTests
{
    [TestMethod()]
    public void SolveTest()
    {
        //Arrange
        const double expected = -1.8681640625d;
        var mockStringExpressionMutator = new MockStringExpressionMutator();
        var mockStringExpressionCleaner = new MockStringExpressionCleaner();
        var actor = new StringExpressionSolver(mockStringExpressionMutator, mockStringExpressionCleaner);

        //Act
        var result = actor.Solve("((1+2·3)/4^5)+6-7/8·9+0");

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod()]
    public void SolveNullTest()
    {
        //Arrange
        const double expected = 0d;
        const string? expression = null;
        var mockStringExpressionMutator = new MockStringExpressionMutator();
        var mockStringExpressionCleaner = new MockStringExpressionCleaner();
        var actor = new StringExpressionSolver(mockStringExpressionMutator, mockStringExpressionCleaner);

        //Act
        var result = actor.Solve(expression);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod()]
    public void SolveEmptyTest()
    {
        //Arrange
        const double expected = 0d;
        const string? expression = "";
        var mockStringExpressionMutator = new MockStringExpressionMutator();
        var mockStringExpressionCleaner = new MockStringExpressionCleaner();
        var actor = new StringExpressionSolver(mockStringExpressionMutator, mockStringExpressionCleaner);

        //Act
        var result = actor.Solve(expression);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
