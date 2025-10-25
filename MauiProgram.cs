using CommunityToolkit.Maui;
using GitFlightApp.Helpers;
using GitFlightApp.Models;
using GitFlightApp.Repositories;
using GitFlightApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GitFlightApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(options => { options.SetShouldEnableSnackbarOnWindows(true); })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var dbPath = FileAccessHelper.GetLocalFilePath("flights.db");
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddSingleton<FlightRepository>();
            builder.Services.AddSingleton<FlightViewModel>();
            builder.Services.AddSingleton<UserViewModel>();
            builder.Services.AddSingleton<PlaneViewModel>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();
            }
            return app;
        }
    }
}
