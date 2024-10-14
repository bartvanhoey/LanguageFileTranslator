using LanguageFileTranslatorApp.Models.ValueObjects;
using LanguageFileTranslatorApp.Services.IndexedDb;
using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Pages;

public partial class Translate : ComponentBase
{
    private readonly ILanguageEntryItemDbService _languageEntryItemDbService;

    public Translate(ILanguageEntryItemDbService languageEntryItemDbService)
    {
        _languageEntryItemDbService = languageEntryItemDbService;
    }
    
    private async Task LanguageEntryChanged(LanguageEntry languageEntry)
    {
      var resutl =  await _languageEntryItemDbService.GetLanguageEntryItemsAsync<List<LanguageEntryItem>>(languageEntry);
    }
    
}