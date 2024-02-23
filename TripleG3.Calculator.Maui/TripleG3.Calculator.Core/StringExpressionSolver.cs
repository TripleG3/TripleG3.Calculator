using Specky7;

namespace TripleG3.Calculator.Core;

[Scoped<IStringExpressionSolver>]
public class StringExpressionSolver(IStringExpressionMutator stringExpressionTrimmer, IStringExpressionCleaner stringExpressionCleaner) : IStringExpressionSolver
{
    private readonly IStringExpressionMutator stringExpressionTrimmer = stringExpressionTrimmer;
    private readonly IStringExpressionCleaner stringExpressionCleaner = stringExpressionCleaner;

    public double Solve(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression)) return 0;

        expression = stringExpressionTrimmer.Mutate(expression);
        expression = stringExpressionCleaner.Clean(expression);

        List<string> values = [];

        char[] chars = new char[] { '+', '-', '/', '÷', '*', '·', '^' };

        string tempString = string.Empty;

        bool lastCharIsDigit = false;

        int startLocation = 0;

        if (expression[startLocation] == '-')
        {
            tempString += "-";
            startLocation += 1;
        }

        for (int location = startLocation; location < expression.Length; location++)
        {
            char c = expression[location];

            if (char.IsDigit(c) || c == '.')
            {
                lastCharIsDigit = true;

                tempString += c;
                continue;
            }

            if (lastCharIsDigit)
            {
                values.Add(tempString);
                tempString = string.Empty;
                lastCharIsDigit = false;

                if (location < expression.Length - 1)
                    if (expression[location] == '(')
                        values.Add("·");
            }

            foreach (char opers in chars)
            {
                if (c == opers)
                {
                    values.Add(c.ToString());
                    break;
                }
            }

            if (c == '(')
            {
                location++;
                values.Add(SolveString(expression, ref location).ToString());
                continue;
            }

            if (c == ')')
            {

                values = DoExponents(values);

                values = DoDivisionMultiply(values);

                values = DoAddSubtract(values);

                return Convert.ToDouble(values[0]);
            }
        }

        if (!string.IsNullOrEmpty(tempString))
            values.Add(tempString);

        values = DoExponents(values);

        values = DoDivisionMultiply(values);

        values = DoAddSubtract(values);

        return Convert.ToDouble(values[0]);
    }

    private static double SolveString(string equation, ref int location)
    {
        List<string> values = [];

        char[] chars = ['+', '-', '/', '÷', '*', '·', '^'];

        string tempString = string.Empty;

        bool lastCharIsDigit = false;

        if (equation[location] == '-')
        {
            tempString += "-";
            location += 1;
        }

        for (location = location; location < equation.Length; location++)
        {
            char c = equation[location];

            if (char.IsDigit(c) || c == '.')
            {
                lastCharIsDigit = true;

                tempString += c;
                continue;
            }

            if (lastCharIsDigit)
            {
                values.Add(tempString);
                tempString = string.Empty;
                lastCharIsDigit = false;

                if (location < equation.Length - 1)
                    if (equation[location] == '(')
                        values.Add("·");
            }

            foreach (char opers in chars)
            {
                if (c == opers)
                {
                    values.Add(c.ToString());
                    break;
                }
            }

            if (c == '(')
            {
                location++;
                values.Add(SolveString(equation, ref location).ToString());
                continue;
            }

            if (c == ')')
            {
                values = DoExponents(values);

                values = DoDivisionMultiply(values);

                values = DoAddSubtract(values);

                return Convert.ToDouble(values[0]);
            }
        }

        if (!string.IsNullOrEmpty(tempString))
            values.Add(tempString);

        values = DoExponents(values);

        values = DoDivisionMultiply(values);

        values = DoAddSubtract(values);

        return Convert.ToDouble(values[0]);
    }

    private static List<string> DoExponents(List<string> values)
    {
        if (values.Count == 1)
            return values;

        List<string> newValues = [];

        for (int x = 0; x < values.Count; x++)
        {
            if (values[x] == "^")
            {
                double first = Convert.ToDouble(newValues[^1]);
                var nextValue = x + 1;
                double second = Convert.ToDouble(nextValue >= values.Count ? 0 : values[nextValue]);
                double result = Math.Pow(first, second);
                newValues.RemoveAt(newValues.Count - 1);
                newValues.Add(result.ToString());
                x++;
                continue;
            }

            newValues.Add(values[x]);
        }

        return newValues;
    }

    private static List<string> DoAddSubtract(List<string> values)
    {
        if (values.Count == 1)
            return values;

        List<string> newValues = [];

        for (int x = 0; x < values.Count; x++)
        {
            if (values[x] == "+")
            {
                double first = Convert.ToDouble(newValues[^1]);
                var nextValue = x + 1;
                double second = Convert.ToDouble(nextValue >= values.Count ? 0 : values[nextValue]);
                double result = first + second;
                newValues.RemoveAt(newValues.Count - 1);
                newValues.Add(result.ToString());
                x++;
                continue;
            }

            if (values[x] == "-")
            {
                double first = Convert.ToDouble(newValues[^1]);
                var nextValue = x + 1;
                double second = Convert.ToDouble(nextValue >= values.Count ? 0 : values[nextValue]);
                double result = first - second;
                newValues.RemoveAt(newValues.Count - 1);
                newValues.Add(result.ToString());
                x++;
                continue;
            }

            newValues.Add(values[x]);
        }

        return newValues;
    }

    private static List<string> DoDivisionMultiply(List<string> values)
    {
        if (values.Count == 1)
            return values;

        List<string> newValues = [];

        for (int x = 0; x < values.Count; x++)
        {
            if (values[x] == "*" || values[x] == "·")
            {
                double first = Convert.ToDouble(newValues[^1]);
                var nextValue = x + 1;
                double second = Convert.ToDouble(nextValue >= values.Count ? 0 : values[nextValue]);
                double result = first * second;
                newValues.RemoveAt(newValues.Count - 1);
                newValues.Add(result.ToString());
                x++;
                continue;
            }

            if (values[x] == "/" || values[x] == "÷")
            {
                double first = Convert.ToDouble(newValues[^1]);
                var nextValue = x + 1;
                double second = Convert.ToDouble(nextValue >= values.Count ? 0 : values[nextValue]);
                double result = first / second;
                newValues.RemoveAt(newValues.Count - 1);
                newValues.Add(result.ToString());
                x++;
                continue;
            }

            newValues.Add(values[x]);
        }

        return newValues;
    }
}
