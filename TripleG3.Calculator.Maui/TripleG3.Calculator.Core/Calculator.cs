using Specky7;
using System.Diagnostics.CodeAnalysis;

namespace TripleG3.Calculator.Core;

[Scoped<ICalculator>]
[ExcludeFromCodeCoverage(Justification = "Calculator is a simple class that does not need to be tested.")]
public class Calculator(IStringExpressionMutator stringExpressionMutator,
                        IStringExpressionCleaner stringExpressionCleaner,
                        IStringExpressionParenthesisCorrector stringExpressionParenthesisCorrector,
                        IStringExpressionPeriodValidator stringExpressionPeriodCorrector,
                        IStringExpressionSolver stringExpressionSolver) : ICalculator
{
    public double Calculate(string expression)
    {
        expression = stringExpressionMutator.Mutate(expression);
        expression = stringExpressionCleaner.Clean(expression);
        expression = stringExpressionParenthesisCorrector.Correct(expression);
        stringExpressionPeriodCorrector.Validate(expression);
        return stringExpressionSolver.Solve(expression);
    }
}
