namespace TripleG3.Calculator.Core.Tests;

[TestClass()]
public class StringExpressionMutatorTests
{
    [TestMethod()]
    public void MutateTest()
    {
        //Arrange
        var expected = "((1+2·3)/4^5)+6-7/8·9+0";
        var actor = new StringExpressionMutator();

        //Act
        var result = actor.Mutate("open open one+two·three close divided by four to the power of five close parenthesis plus six-seven/eight·nine+zero");

        //Assert
        Assert.AreEqual(expected, result);
    }
}