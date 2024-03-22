using Specky7;
using TripleG3.Calculator.Core.Exceptions;

namespace TripleG3.Calculator.Core;

[Scoped<IStringExpressionPeriodValidator>]
public class StringExpressionPeriodValidator : IStringExpressionPeriodValidator
{
    public static IEnumerable<string> MathOperators => ["+", "-", "*", "/", "^", "(", ")"];
    public void Validate(string expression)
    {
        foreach (var smallExpression in expression.Split(MathOperators.ToArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            if (smallExpression.Count(x => x == '.') > 1)
            {
                throw new ExpressionFormatInvalidException();
            }
        }
    }
}