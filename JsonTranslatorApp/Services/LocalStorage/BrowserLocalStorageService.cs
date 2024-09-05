using Blazored.LocalStorage;
using JsonTranslatorApp.ApplicationConsts;
using JsonTranslatorApp.Infra.Extensions;
using static JsonTranslatorApp.ApplicationConsts.AppConsts;

namespace JsonTranslatorApp.Services.LocalStorage;

public class BrowserLocalStorageService(ILocalStorageService localStorage) : IBrowserLocalStorageService
{
    public async Task SaveJsonFileNamesAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var jsonFileNames = await localStorage.GetItemAsync<string>(AppConsts.JsonFileNames, cancellationToken);
        if (jsonFileNames.IsNullOrWhiteSpace()) return;

        var list = jsonFileNames?.Split(",").ToList() ?? [];

        if (list.Contains(fileName)) list.Add(fileName);
        if (list.Count > 0) await localStorage.SetItemAsync(JsonFileNames, string.Join(",", list), cancellationToken);
    }

    public async Task<IEnumerable<string>> GetJsonFileNamesAsync(CancellationToken cancellationToken = default)
    {
        var jsonFileNames = await localStorage.GetItemAsync<string>(AppConsts.JsonFileNames, cancellationToken);

        return new List<string>();
    }
}