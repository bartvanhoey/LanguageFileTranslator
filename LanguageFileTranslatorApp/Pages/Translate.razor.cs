using LanguageFileTranslatorApp.Models.ValueObjects;
using LanguageFileTranslatorApp.Services.IndexedDb;
using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Pages;

public partial class Translate(ILanguageEntryItemDbService languageEntryItemDbService) : ComponentBase
{
    private List<LanguageEntryItem> LanguageEntryItems { get; set; } = [];

    private async Task LanguageEntryChanged(LanguageEntry languageEntry)
    {
        LanguageEntryItems = await languageEntryItemDbService.GetLanguageEntryItemsAsync<List<LanguageEntryItem>>(languageEntry);
        StateHasChanged();
    }
    
    private async Task ValueChanged(ChangeEventArgs args, string key, string? culture)
    {
        var item = LanguageEntryItems.FirstOrDefault(x => x.Key == key && x.Culture == culture);

        if (item != null) await languageEntryItemDbService.UpdateLanguageEntryItemAsync(item.Id, args.Value);

        await Task.CompletedTask;
    }
    
}