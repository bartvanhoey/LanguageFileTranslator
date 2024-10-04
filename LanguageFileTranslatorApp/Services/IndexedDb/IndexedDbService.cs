using LanguageFileTranslatorApp.Models.ValueObjects;
using Microsoft.JSInterop;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public interface IIndexedDbService
{
    Task InitializeAsync();
    // Task InsertTranslationAsync<T>(string culture, string key, string value);
    Task InsertTranslationsAsync<T>(LanguageFile languageFile);
}

public class IndexedDbService(IJSRuntime jsRuntime) : IIndexedDbService, IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();

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

    private async Task SetValueAsync<T>(string collectionName, T value)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("set", collectionName, value);
    }

    private async Task WaitForReference()
    {
        if (_accessorJsRef.IsValueCreated is false)
            _accessorJsRef =
                new(await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/indexedDbService.js"));
    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated) await _accessorJsRef.Value.DisposeAsync();
    }

    // public async Task InsertTranslationAsync<T>(string culture, string key, string value)
    //     => await SetValueAsync("translations",
    //         new { Id = $"{culture}#{key}", Key = key, Culture = culture, Name = value });

    public async Task InsertTranslationsAsync<T>(LanguageFile languageFile)
    {
        var culture = languageFile.Culture.Name;
        
        foreach (var (key, value) in languageFile.Model.Items)
            await SetValueAsync("translations",
                new { Id = $"{culture}#{key}", Key = key, Culture = culture, Name = value });
    }
}