using LanguageFileTranslatorApp.Models.ValueObjects;
using LanguageFileTranslatorApp.Services.IndexedDb;
using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Components.Navigator;

public partial class Navigator(ILanguageEntryDbService db) : ComponentBase
{
    
    [Parameter]
    public EventCallback<LanguageEntry> OnLanguageEntryChanged { get; set; }
    
    protected override async Task OnInitializedAsync() => await GotoFirstByKey();

    private async Task GotoFirstByKey()
    {
        var first = await db.GetFirstByKeyAsync();
        if (first.IsSuccess)
        {
            LanguageEntry = first.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }

    private async Task GotoPreviousByKey()
    {
        if (LanguageEntry == null) return;
        var previous = await db.GetPreviousByKeyAsync(LanguageEntry);
        if (previous.IsSuccess) LanguageEntry = previous.Value;
    }

    private async Task GotoNextByKey()
    {
        if (LanguageEntry == null) return;
        var next = await db.GetNextByKeyAsync(LanguageEntry);
        if (next.IsSuccess) LanguageEntry = next.Value;
    }

    private async Task GotoLastByKey()
    {
        var lastByKey = await db.GetLastByKeyAsync();
        if (lastByKey.IsSuccess) LanguageEntry = lastByKey.Value;
    }

    private async Task GotoFirstById()
    {
        var first = await db.GetFirstByIdAsync();
        if (first.IsSuccess) LanguageEntry = first.Value;
    }

    private LanguageEntry? LanguageEntry { get; set; }

    private async Task GotoPreviousById()
    {
        if (LanguageEntry == null) return;
        var previous = await db.GetPreviousByIdAsync(LanguageEntry);
        if (previous.IsSuccess) LanguageEntry = previous.Value;
    }

    private async Task GotoNextById()
    {
        if (LanguageEntry == null) return;
        var next = await db.GetNextByIdAsync(LanguageEntry);
        if (next.IsSuccess) LanguageEntry = next.Value;
    }

    private async Task GotoLastById()
    {
        var result = await db.GetLastByIdAsync();
        if (result.IsSuccess) LanguageEntry = result.Value;
    }
}

public class LanguageEntryChangedEventArgs : EventArgs
{
    public LanguageEntry? LanguageEntry { get; set; }
}