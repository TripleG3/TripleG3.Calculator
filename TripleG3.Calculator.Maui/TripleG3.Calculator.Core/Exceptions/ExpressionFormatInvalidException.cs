namespace TripleG3.Calculator.Core.Exceptions;

[Serializable]
public class ExpressionFormatInvalidException : Exception
{
    public ExpressionFormatInvalidException() : base("Expression format is invalid.") { }
}
