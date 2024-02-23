namespace TripleG3.Calculator.Core.Exceptions;

[Serializable]
public class ExpressionEmptyException : Exception
{
    public ExpressionEmptyException() : base("Expression is empty") { }
}
