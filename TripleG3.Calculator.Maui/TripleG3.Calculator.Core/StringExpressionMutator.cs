using Specky7;

namespace TripleG3.Calculator.Core;

[Scoped<IStringExpressionMutator>]
public class StringExpressionMutator : IStringExpressionMutator
{
    //Order of these matter
    public IReadOnlyDictionary<string, string> StringToReplacements { get; } = new Dictionary<string, string>()
    {
        ["raised to the power of"] = "^",
        ["raised to the"] = "^",
        ["to the power of"] = "^",
        ["to the"] = "^",
        ["power"] = "^",
        ["open parenthesis"] = "(",
        ["open"] = "(",
        ["close parenthesis"] = ")",
        ["close"] = ")",
        ["divided by"] = "/",
        ["divide"] = "/",
        ["multiply"] = "·",
        ["multiplied by"] = "·",
        ["times"] = "·",
        ["six"] = "6",
        ["x"] = "·",
        ["×"] = "·",
        ["÷"] = "/",
        ["subtract"] = "-",
        ["minus"] = "-",
        ["add"] = "+",
        ["and"] = "+",
        ["plus"] = "+",
        ["+-"] = "-",
        ["-+"] = "-",
        [")("] = ")·(",
        ["one"] = "1",
        ["two"] = "2",
        ["three"] = "3",
        ["four"] = "4",
        ["five"] = "5",
        ["seven"] = "7",
        ["eight"] = "8",
        ["nine"] = "9",
        ["zero"] = "0",
        ["raised"] = "^",
        ["squared"] = "^2",
        ["cubed"] = "^3",
        [" "] = "",
    };

    public string Mutate(string expression)
    {
        foreach (var (Key, Value) in StringToReplacements)
        {
            expression = expression.ToLower().Replace(Key, Value);
        }
        return expression;
    }
}