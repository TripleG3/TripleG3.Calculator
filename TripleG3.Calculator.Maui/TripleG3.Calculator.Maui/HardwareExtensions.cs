namespace TripleG3.Calculator.Maui;

public static class HardwareExtensions
{
    public static void TryVibrate(this IVibration vibration, double duration)
    {
        if (vibration is null) return;
        try
        {
            if (vibration.IsSupported)
            {
                vibration.Vibrate(duration);
            }
        }
        catch (FeatureNotSupportedException)
        {
            // Ignore
        }
    }
}
 