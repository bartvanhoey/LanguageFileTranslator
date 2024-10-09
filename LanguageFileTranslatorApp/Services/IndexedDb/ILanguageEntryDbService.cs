using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public interface ILanguageEntryDbService
{
    Task InitializeAsync();
    // Task InsertTranslationAsync<T>(string culture, string key, string value);
    Task InsertLanguageEntriesAsync<T>(LanguageFile languageFile);
    Task<Result<LanguageEntryItem>> GetFirstByKeyAsync();
    Task<Result<LanguageEntryItem>> GetPreviousByKeyAsync(string key);
    Task<Result<LanguageEntryItem>> GetNextByKeyAsync(string key);
    Task<Result<LanguageEntryItem>> GetLastByKeyAsync();
    Task<Result<LanguageEntryItem>> GetFirstByIdAsync();
    Task<Result<LanguageEntryItem>> GetPreviousByIdAsync(int i);
    Task<Result<LanguageEntryItem>>  GetNextByIdAsync(int i);
    Task<Result<LanguageEntryItem>>  GetLastByIdAsync();
}