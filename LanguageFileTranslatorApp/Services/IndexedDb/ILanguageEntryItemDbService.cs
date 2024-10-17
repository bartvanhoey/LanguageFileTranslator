using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public interface ILanguageEntryItemDbService
{
    Task InitializeAsync();
    Task InsertLanguageEntryItemsAsync(LanguageFile languageFile);
    Task<List<LanguageEntryItem>> GetLanguageEntryItemsAsync<T>(LanguageEntry languageEntry);
    Task UpdateLanguageEntryItemAsync(string id, object? value);
}