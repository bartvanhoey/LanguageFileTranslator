using Microsoft.JSInterop;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public class LanguageEntryDbServiceBase: IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    protected LanguageEntryDbServiceBase(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

    protected Lazy<IJSObjectReference> IndexedDb = new();

    private async Task SetAsync<T>(string collectionName, T value)
        => await (await GetIndexedDb()).InvokeVoidAsync("set", collectionName, value);

    protected async Task SetManyAsync<T>(string collectionName, List<T> languageEntryItems)
        => await (await GetIndexedDb()).InvokeVoidAsync("setMany", collectionName, languageEntryItems);

    protected async Task<IJSObjectReference> GetIndexedDb()
    {
        if (IndexedDb.IsValueCreated is false)
            IndexedDb = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/indexedDbService.js"));
        return IndexedDb.Value;
    }

    public async ValueTask DisposeAsync()
    {
        if (IndexedDb.IsValueCreated) await IndexedDb.Value.DisposeAsync();
    }
}