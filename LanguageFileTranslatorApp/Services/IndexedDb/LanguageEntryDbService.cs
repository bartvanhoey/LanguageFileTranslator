using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Infra.Funcky.ResultErrors;
using LanguageFileTranslatorApp.Models.ValueObjects;
using Microsoft.JSInterop;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultClass.Result;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultErrors.ResultErrorFactory;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public class LanguageEntryDbService(IJSRuntime jsRuntime)
    : LanguageEntryDbServiceBase(jsRuntime), ILanguageEntryDbService
{
    private const string LanguageEntries = "languageEntries";

    public async Task InsertLanguageEntriesAsync<T>(LanguageFile languageFile) =>
        await SetManyAsync(LanguageEntries, languageFile.Model.LanguageEntryItems.Select(x =>
            new LanguageEntry(x.IdLanguageEntryItem, x.Key)).ToList());

    public async Task<Result<LanguageEntry>> GetFirstByKeyAsync()
    {
        try
        {
            // var getAllByKey = await (await GetIndexedDb()).InvokeAsync<List<LanguageEntry>>("getAllByKey", LanguageEntries, "key1");
            // var getAll = await (await GetIndexedDb()).InvokeAsync<List<LanguageEntry>>("getAll", LanguageEntries);
            var getFirstKey = await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getFirstKey", LanguageEntries);

            
            
            // var getLastKey = await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getLastKey", LanguageEntries);
            // var getFirstId = await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getFirstId", LanguageEntries);
            // var getLastId = await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getLastId", LanguageEntries);
            return Ok(getFirstKey);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<LanguageEntry>> GetPreviousByKeyAsync(LanguageEntry? languageEntry)
    {
        try
        {
            return Ok(await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getPreviousKey", LanguageEntries, languageEntry));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetNextByKeyAsync(LanguageEntry? languageEntry)
    {
        try
        {
            return Ok(await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getNextKey", LanguageEntries, languageEntry));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetLastByKeyAsync()
    {
        try
        {
            return Ok(await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getLastKey", LanguageEntries));
        }
        catch (Exception exception)
        {
             return Result.Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetFirstByIdAsync()
    {
        try
        {
            return Ok(await IndexedDb.Value.InvokeAsync<LanguageEntry>("getFirstId", LanguageEntries));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public Task<Result<LanguageEntry>> GetPreviousByIdAsync(int i)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LanguageEntry>> GetNextByIdAsync(int i)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<LanguageEntry>> GetLastByIdAsync()
    {
        try
        {
            return Ok(await IndexedDb.Value.InvokeAsync<LanguageEntry>("getLastId", LanguageEntries));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }
}