namespace TripleG3.Calculator.Core.Tests;

[TestClass()]
public class StringExpressionSolverTests
{
    private readonly IStringExpressionMutator mockStringExpressionMutator = new MockStringExpressionMutator();
    private readonly IStringExpressionCleaner mockStringExpressionCleaner = new MockStringExpressionCleaner();
    private readonly IStringExpressionParenthesisCorrector mockStringExpressionParenthesisCorrector = new MockStringExpressionParenthesisCorrector();
    private StringExpressionSolver actor;

    [TestInitialize]
    public void TestInitialize()
    {
        actor = new StringExpressionSolver(mockStringExpressionMutator, mockStringExpressionCleaner, mockStringExpressionParenthesisCorrector);
    }

    [TestMethod()]
    public void SolveTest()
    {
        //Arrange
        const double expected = -1.8681640625d;

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

        //Act
        var result = actor.Solve(expression!);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod()]
    public void SolveEmptyTest()
    {
        //Arrange
        const double expected = 0d;
        const string expression = "";

        //Act
        var result = actor.Solve(expression);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
