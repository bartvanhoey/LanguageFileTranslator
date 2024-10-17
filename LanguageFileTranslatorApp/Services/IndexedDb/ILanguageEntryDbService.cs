using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public interface ILanguageEntryDbService
{
    Task InitializeAsync();
    // Task InsertTranslationAsync<T>(string culture, string key, string value);
    Task InsertLanguageEntriesAsync(LanguageFile languageFile);
    Task<Result<LanguageEntry>> GetFirstByKeyAsync();
    Task<Result<LanguageEntry>> GetPreviousByKeyAsync(LanguageEntry languageEntry);
    Task<Result<LanguageEntry>> GetNextByKeyAsync(LanguageEntry languageEntry);
    Task<Result<LanguageEntry>> GetLastByKeyAsync();
    Task<Result<LanguageEntry>> GetFirstByIdAsync();
    Task<Result<LanguageEntry>> GetPreviousByIdAsync(LanguageEntry languageEntry);
    Task<Result<LanguageEntry>>  GetNextByIdAsync(LanguageEntry languageEntry);
    Task<Result<LanguageEntry>>  GetLastByIdAsync();
    Task<T> GetAllAsync<T>(string collectionName, string jsonFileName);
}