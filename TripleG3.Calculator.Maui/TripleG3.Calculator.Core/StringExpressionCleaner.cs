using Specky7;
using System.Text;

namespace TripleG3.Calculator.Core;

[Scoped<IStringExpressionCleaner>]
public class StringExpressionCleaner : IStringExpressionCleaner
{
    public IReadOnlyCollection<string> CleanItems { get; } = ["(", ")", "+", "-", "/", "^", "·", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."];

    public string Clean(string expression)
    {
        StringBuilder stringBuilder = new();

        foreach (char c in expression)
        {
            if (CleanItems.Contains(c.ToString()))
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }
}