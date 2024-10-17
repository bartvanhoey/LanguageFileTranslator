using LanguageFileTranslatorApp.Models.ValueObjects;
using Microsoft.JSInterop;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public class LanguageEntryItemDbService(IJSRuntime jsRuntime) : LanguageEntryDbServiceBase(jsRuntime), ILanguageEntryItemDbService
{
    private const string LanguageEntryItems = "languageEntryItems";
    
    public async Task InsertLanguageEntryItemsAsync(LanguageFile languageFile) 
        => await SetManyAsync(LanguageEntryItems, languageFile.Model.LanguageEntryItems);

    public async Task<List<LanguageEntryItem>> GetLanguageEntryItemsAsync<T>(LanguageEntry languageEntry) 
        => await (await GetIndexedDb()).InvokeAsync<List<LanguageEntryItem>>("getAllLanguageEntryItemsByKey", languageEntry.Key);

    public async Task UpdateLanguageEntryItemAsync(string id, object? value)
    => await (await GetIndexedDb()).InvokeAsync<List<LanguageEntryItem>>("updateLanguageEntryItem", id, value);
    
}