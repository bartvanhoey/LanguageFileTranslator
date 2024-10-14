using LanguageFileTranslatorApp.Models.ValueObjects;
using Microsoft.JSInterop;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public class LanguageEntryItemDbService(IJSRuntime jsRuntime) : LanguageEntryDbServiceBase(jsRuntime), ILanguageEntryItemDbService
{
    private const string LanguageEntryItems = "languageEntryItems";
    
    public async Task InsertLanguageEntryItemsAsync<T>(LanguageFile languageFile) 
        => await SetManyAsync(LanguageEntryItems, languageFile.Model.LanguageEntryItems);

    public async Task<List<LanguageEntryItem>> GetLanguageEntryItemsAsync<T>(LanguageEntry languageEntry)
    {
        var result =  await GetAllAsync<List<LanguageEntryItem>>(LanguageEntryItems, "");
        return result;
    }
}