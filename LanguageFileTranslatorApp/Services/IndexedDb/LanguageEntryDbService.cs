using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Models.ValueObjects;
using Microsoft.JSInterop;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public class LanguageEntryDbService(IJSRuntime jsRuntime)
    : LanguageEntryDbServiceBase(jsRuntime), ILanguageEntryDbService
{
    private const string LanguageEntries = "languageEntries";

    public async Task InitializeAsync()
        => await (await GetIndexedDb()).InvokeVoidAsync("initialize");

    public async Task<T> GetValueAsync<T>(string collectionName, string id)
    {
        await GetIndexedDb();
        var result = await IndexedDb.Value.InvokeAsync<T>("get", collectionName, id);
        return result;
    }

    public async Task<T> GetAllAsync<T>(string collectionName, string jsonFileName)
    {
        await GetIndexedDb();
        var result = await IndexedDb.Value.InvokeAsync<T>("getAll", collectionName, jsonFileName);

        return result;
    }

 

    public async Task InsertLanguageEntriesAsync<T>(LanguageFile languageFile)
    {
        var entries = languageFile.Model.LanguageEntryItems.Select(x =>
            new LanguageEntry(x.IdLanguageEntryItem, x.Key)).ToList();

        await SetManyAsync(LanguageEntries, entries);
    }

    public async Task<Result<LanguageEntry>> GetFirstByKeyAsync()
    {
        await GetIndexedDb();
        try
        {
            // var result = await _js.Value.InvokeAsync<List<LanguageEntry>>("getAllByKey", LanguageEntries, "key1");
            // var result = await _js.Value.InvokeAsync<List<LanguageEntry>>("getAll", LanguageEntries);
            var resultFirst = await IndexedDb.Value.InvokeAsync<LanguageEntry>("getFirstId", LanguageEntries);
            var resultLast = await IndexedDb.Value.InvokeAsync<LanguageEntry>("getLastId", LanguageEntries);
            return Result.Ok(new LanguageEntry());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Result<LanguageEntry>> GetPreviousByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntry>> GetNextByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntry>> GetLastByKeyAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntry>> GetFirstByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntry>> GetPreviousByIdAsync(int i)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntry>> GetNextByIdAsync(int i)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntry>> GetLastByIdAsync()
    {
        throw new NotImplementedException();
    }
}