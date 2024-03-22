using TripleG3.Calculator.Core;

var expression = "(1+4) multiply by 8 divided by 2";

var mutator = new StringExpressionMutator();
var cleaner = new StringExpressionCleaner();
var parenthesisCorrector = new StringExpressionParenthesisCorrector();
var periodCorrect = new StringExpressionPeriodValidator();
var solver = new StringExpressionSolver();
var calculator = new Calculator(mutator, cleaner, parenthesisCorrector, periodCorrect, solver);

Console.WriteLine(calculator.Calculate(expression));