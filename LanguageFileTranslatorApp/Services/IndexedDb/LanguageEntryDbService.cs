using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
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
            var getFirstByKey = await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getFirstByKey", LanguageEntries);
            return Ok(getFirstByKey);
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetPreviousByKeyAsync(LanguageEntry languageEntry)
    {
        try
        {
            return Ok(await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getPreviousLanguageEntryByKey", LanguageEntries, languageEntry));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetNextByKeyAsync(LanguageEntry languageEntry)
    {
        try
        {
            return Ok(await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getNextLanguageEntryByKey", LanguageEntries, languageEntry));
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
            return Ok(await (await GetIndexedDb()).InvokeAsync<LanguageEntry>("getLastLanguageEntryByKey", LanguageEntries));
        }
        catch (Exception exception)
        {
             return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetFirstByIdAsync()
    {
        try
        {
            return Ok(await IndexedDb.Value.InvokeAsync<LanguageEntry>("getFirstLanguageEntryById", LanguageEntries));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetPreviousByIdAsync(LanguageEntry languageEntry)
    {
        try
        {
            return Ok(await IndexedDb.Value.InvokeAsync<LanguageEntry>("getPreviousLanguageEntryById", LanguageEntries, languageEntry));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetNextByIdAsync(LanguageEntry languageEntry)
    {
        try
        {
            return Ok(await IndexedDb.Value.InvokeAsync<LanguageEntry>("getNextLanguageEntryById", LanguageEntries, languageEntry));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }

    public async Task<Result<LanguageEntry>> GetLastByIdAsync()
    {
        try
        {
            return Ok(await IndexedDb.Value.InvokeAsync<LanguageEntry>("getLastLanguageEntryById", LanguageEntries));
        }
        catch (Exception exception)
        {
            return Fail<LanguageEntry>(CallToIndexedDbWentWrong(exception));
        }
    }
}