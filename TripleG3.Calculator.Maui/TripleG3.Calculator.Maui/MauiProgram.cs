using Microsoft.Extensions.Logging;
using Specky7;

namespace TripleG3.Calculator.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSpecks(options =>
        {
            options.AddAssemblies(typeof(MauiProgram).Assembly, 
                                  typeof(Core.IStringExpressionMutator).Assembly);
        });
#if DEBUG
		builder.Logging.AddDebug();
#endif

        var app = builder.Build();
        Specky.ServiceProvider = app.Services;
        return app;
    }
}
