namespace TripleG3.Calculator.Core.Tests;

[TestClass()]
public class StringExpressionParenthesisCorrectorTests
{
    [TestMethod()]
    public void MutateTest()
    {
        //Arrange
        const string expression = ")(()))()))()(((";
        const string expected = "(())()()((()))";
        var actor = new StringExpressionParenthesisCorrector();

        //Act
        var actual = actor.Correct(expression);

        //Assert
        Assert.AreEqual(expected, actual);
    }
}