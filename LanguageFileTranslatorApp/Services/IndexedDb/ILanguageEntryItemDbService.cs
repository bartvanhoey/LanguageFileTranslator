﻿using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Services.IndexedDb;

public interface ILanguageEntryItemDbService
{
    Task InitializeAsync();
    Task InsertLanguageEntryItemsAsync<T>(LanguageFile languageFile);
    Task<List<LanguageEntryItem>> GetLanguageEntryItemsAsync<T>(LanguageEntry languageEntry);
}