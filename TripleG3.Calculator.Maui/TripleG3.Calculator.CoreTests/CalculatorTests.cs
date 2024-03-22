namespace TripleG3.Calculator.Core.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void CalculateTest()
        {
            //Arrange
            var expected = 0;
            var expression = "";

            var stringExpressionMutator = new MockStringExpressionMutator();
            var stringExpressionCleaner = new MockStringExpressionCleaner();
            var stringExpressionParenthesisCorrector = new MockStringExpressionParenthesisCorrector();
            var stringExpressionPeriodCorrector = new MockStringExpressionPeriodCorrector();
            var stringExpressionSolver = new MockStringExpressionSolver();

            var actor = new Calculator(stringExpressionMutator,
                                       stringExpressionCleaner,
                                       stringExpressionParenthesisCorrector,
                                       stringExpressionPeriodCorrector,
                                       stringExpressionSolver);

            //Act
            var actual = actor.Calculate(expression);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}