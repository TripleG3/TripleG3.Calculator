using Specky7;
using System.Text;

namespace TripleG3.Calculator.Core;

[Scoped<IStringExpressionParenthesisCorrector>]
public class StringExpressionParenthesisCorrector : IStringExpressionParenthesisCorrector
{
    public string Correct(string expression)
    {
        StringBuilder stringBuilder = new();

        int parenthesisCounter = 0;
        foreach (char c in expression)
        {
            if (c == '(')
            {
                parenthesisCounter++;
                stringBuilder.Append(c);
            }
            else
            {
                if (c == ')')
                {
                    if (parenthesisCounter > 0)
                    {
                        parenthesisCounter--;
                        stringBuilder.Append(c);
                    }
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
        }
        while (parenthesisCounter > 0)
        {
            stringBuilder.Append(')');
            parenthesisCounter--;
        }
        return stringBuilder.ToString();
    }
}