using GrawPortal.BlazorWasm.Components.Confirm;
using LanguageFileTranslatorApp.Components.Confirm;
using LanguageFileTranslatorApp.Models.ValueObjects;
using LanguageFileTranslatorApp.Services.IndexedDb;
using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Pages;

public partial class Translate(ILanguageEntryItemDbService languageEntryItemDbService) : PageComponentBase
{
    
    protected ConfirmBase? ValueChangedConfirmDialog { get; set; }
    private List<LanguageEntryItem> LanguageEntryItems { get; set; } = [];

    private async Task LanguageEntryChanged(LanguageEntry languageEntry)
    {
        LanguageEntryItems = await languageEntryItemDbService.GetLanguageEntryItemsAsync<List<LanguageEntryItem>>(languageEntry);
        StateHasChanged();
    }
    
    private void ValueChanged(ChangeEventArgs args, string key, string? culture)
    {
        var item = LanguageEntryItems.FirstOrDefault(x => x.Key == key && x.Culture == culture);
        if (item?.Id == null) return;
        ValueToSave = (string?)args.Value;
        ItemId = item.Id;
        ValueChangedConfirmDialog?.Show();
    }
    
    public required string ItemId { get; set; }

    private string? ValueToSave { get; set; }

    private async Task ConfirmValueChangedAsync(ConfirmResult confirmResult)
    {
        if (confirmResult.IsConfirmed)
        {
            await languageEntryItemDbService.UpdateLanguageEntryItemAsync(ItemId, ValueToSave);                        
            await DisplayToast("Value Changed", "The value is successfully saved to the database.");
        }
    }
}