namespace TripleG3.Calculator.Maui;

public static class Specky
{
    public static IServiceProvider ServiceProvider { get; set; } = new EmptyServiceProvider();
    public static object GetInject(BindableObject obj) => obj.GetValue(InjectProperty);
    public static void SetInject(BindableObject obj, object value) => obj.SetValue(InjectProperty, value);
    public static readonly BindableProperty InjectProperty = BindableProperty.CreateAttached("Inject", typeof(object), typeof(Specky), null, propertyChanged: (bindable, oldValue, newValue) =>
    {
        if (bindable is VisualElement visualElement && newValue is Type type)
        {
            if (visualElement.IsLoaded)
            {
                LoadSpeck(visualElement, type);
            }
            else
            {
                visualElement.Loaded += FrameworkElementLoaded;
            }

            void FrameworkElementLoaded(object? sender, EventArgs e)
            {
                visualElement.Loaded -= FrameworkElementLoaded;
                LoadSpeck(visualElement, type);
            }

            static void LoadSpeck(VisualElement visualElement, Type type)
            {
                if (ServiceProvider is EmptyServiceProvider)
                {
                    throw new Exception("The service provider has not been set. You must set the service provider during startup.  ex: Specky.Wpf.Attachables.Specky.ServiceProvider = builder.Services");
                }
                var speck = ServiceProvider.GetService(type) ?? throw new Exception($"The type {type.Name} was not found in the service provider.");
                visualElement.BindingContext = speck;
            }
        }
    });

    private class EmptyServiceProvider : IServiceProvider
    {
        public object? GetService(Type serviceType) => null;
    }
}
