using System.Globalization;

namespace TripleG3.Calculator.Maui.Views.Converters;

public class StringToBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) => value is string str && !string.IsNullOrWhiteSpace(str);
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>  throw new NotImplementedException();
}
