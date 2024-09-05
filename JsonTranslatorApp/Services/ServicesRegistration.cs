using JsonTranslatorApp.Services.LocalStorage;

namespace JsonTranslatorApp.Services;

public static class ServicesRegistration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBrowserLocalStorageService, BrowserLocalStorageService>(); 

        
    }
}