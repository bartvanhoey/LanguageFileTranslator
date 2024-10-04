namespace LanguageFileTranslatorApp.Services.LocalStorage;

public interface IBrowserLocalStorageService
{
    Task SaveJsonFileNamesAsync(string fileName, CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> GetJsonFileNamesAsync(CancellationToken cancellationToken = default);
}