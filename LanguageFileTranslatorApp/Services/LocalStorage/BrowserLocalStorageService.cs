using Blazored.LocalStorage;
using LanguageFileTranslatorApp.ApplicationConsts;
using LanguageFileTranslatorApp.Infra.Extensions;
using static LanguageFileTranslatorApp.ApplicationConsts.AppConsts;

namespace LanguageFileTranslatorApp.Services.LocalStorage;

public class BrowserLocalStorageService(ILocalStorageService localStorage) : IBrowserLocalStorageService
{
    public async Task SaveJsonFileNamesAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var jsonFileNames = await localStorage.GetItemAsync<string>(JsonFileNames, cancellationToken);
        if (jsonFileNames.IsNullOrWhiteSpace())
            await localStorage.SetItemAsync(JsonFileNames, fileName, cancellationToken);
        else
        {
            var list = jsonFileNames?.Split(",").ToList() ?? [];
            if (!list.Contains(fileName)) list.Add(fileName);
            if (list.Count > 0) await localStorage.SetItemAsync(JsonFileNames, string.Join(",", list), cancellationToken);    
        }

        
    }

    public async Task<IEnumerable<string>> GetJsonFileNamesAsync(CancellationToken cancellationToken = default)
    {
        var jsonFileNames = await localStorage.GetItemAsync<string>(AppConsts.JsonFileNames, cancellationToken);

        return new List<string>();
    }
}