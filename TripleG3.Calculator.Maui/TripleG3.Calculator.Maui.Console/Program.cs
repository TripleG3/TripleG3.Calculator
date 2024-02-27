
var expression = "(1+4) multiply by 8 divided by 2";

var mutator = new TripleG3.Calculator.Core.StringExpressionMutator();
var cleaner = new TripleG3.Calculator.Core.StringExpressionCleaner();
var corrector = new TripleG3.Calculator.Core.StringExpressionParenthesisCorrector();
var solver = new TripleG3.Calculator.Core.StringExpressionSolver(mutator, cleaner, corrector);

Console.WriteLine(solver.Solve(expression));