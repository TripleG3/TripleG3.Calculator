namespace TripleG3.Calculator.Core.Tests;

[TestClass()]
public class StringExpressionCleanerTests
{
    [TestMethod()]
    public void CleanTest()
    {
        // Arrange
        var expected = "((5+5)-6/12)·4+32";
        var expression = "((5whatever+jibberish5)-and6/some12)then   ·4with+3and2";
        var actor = new StringExpressionCleaner();

        // Act
        var actual = actor.Clean(expression);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    //Jibberish TEst
    [TestMethod()]
    public void CleanJibberishTest()
    {
        // Arrange
        var expected = "";
        var expression = "asdlkfjaslkfjasldfj";
        var actor = new StringExpressionCleaner();

        // Act
        var actual = actor.Clean(expression);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}