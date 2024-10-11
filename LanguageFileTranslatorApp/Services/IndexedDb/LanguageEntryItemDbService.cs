using LanguageFileTranslatorApp.Models.ValueObjects;
using Microsoft.JSInterop;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public class LanguageEntryItemDbService(IJSRuntime jsRuntime) : LanguageEntryDbServiceBase(jsRuntime), ILanguageEntryItemDbService, IAsyncDisposable
{
    private const string LanguageEntryItems = "languageEntryItems";
    
    public async Task InsertLanguageEntryItemsAsync<T>(LanguageFile languageFile) 
        => await SetManyAsync(LanguageEntryItems, languageFile.Model.LanguageEntryItems);

    
  
}