using LanguageFileTranslatorApp.Services.IndexedDb;
using LanguageFileTranslatorApp.Services.LocalStorage;

namespace LanguageFileTranslatorApp.Services;

public static class ServicesRegistration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBrowserLocalStorageService, BrowserLocalStorageService>(); 
        services.AddScoped<ILanguageEntryDbService, LanguageEntryDbService>();

        
    }
}