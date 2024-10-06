using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Models.ValueObjects;
using Microsoft.JSInterop;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public class LanguageEntryDbService(IJSRuntime jsRuntime) : ILanguageEntryDbService, IAsyncDisposable
{
    private const string LanguageEntries = "languageEntries";
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

    public async Task InsertTranslationsAsync<T>(LanguageFile languageFile)
    {
        foreach (var languageEntryItem in languageFile.Model.LanguageEntryItems) 
            await SetValueAsync(LanguageEntries, languageEntryItem);
    }

    public async Task<Result<LanguageEntryItem>> GetFirstByKeyAsync()
    {
        await WaitForReference();
        try
        {
            var result = await _accessorJsRef.Value.InvokeAsync<List<LanguageEntryItem>>("getAll", LanguageEntries, "LongWelcomeMessage");
            return Result.Ok(new LanguageEntryItem("","","",1)) ;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Result<LanguageEntryItem>> GetPreviousByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntryItem>> GetNextByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntryItem>> GetLastByKeyAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntryItem>> GetFirstByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntryItem>> GetPreviousByIdAsync(int i)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntryItem>> GetNextByIdAsync(int i)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntryItem>> GetLastByIdAsync()
    {
        throw new NotImplementedException();
    }
}