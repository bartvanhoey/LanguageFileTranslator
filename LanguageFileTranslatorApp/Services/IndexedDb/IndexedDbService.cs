using Microsoft.JSInterop;

namespace JsonTranslatorApp.Services.IndexedDb;

public class IndexedDbService : IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;

    public IndexedDbService(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

    public async Task InitializeAsync()
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("initialize");
    }

    public async Task<T> GetValueAsync<T>(string collectionName, string id)
    {
        await WaitForReference();
        var result = await _accessorJsRef.Value.InvokeAsync<T>("get", collectionName, id);

        return result;
    }
    
    public async Task<T> GetAllAsync<T>(string collectionName, string jsonFileName)
    {
        await WaitForReference();
        var result = await _accessorJsRef.Value.InvokeAsync<T>("getAll", collectionName, jsonFileName);

        return result;
    }

    public async Task SetValueAsync<T>(string collectionName, T value)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("set", collectionName, value);
    }

    private async Task WaitForReference()
    {
        if (_accessorJsRef.IsValueCreated is false) 
            _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/indexedDbService.js"));
    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated) await _accessorJsRef.Value.DisposeAsync();
    }
}