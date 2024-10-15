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
        if (previous.IsSuccess)
        {
            LanguageEntry = previous.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }

    private async Task GotoNextByKey()
    {
        if (LanguageEntry == null) return;
        var next = await db.GetNextByKeyAsync(LanguageEntry);
        if (next.IsSuccess)
        {
            LanguageEntry = next.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }

    private async Task GotoLastByKey()
    {
        var lastByKey = await db.GetLastByKeyAsync();
        if (lastByKey.IsSuccess)
        {
            LanguageEntry = lastByKey.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }

    private async Task GotoFirstById()
    {
        var first = await db.GetFirstByIdAsync();
        if (first.IsSuccess)
        {
            LanguageEntry = first.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }

    private LanguageEntry? LanguageEntry { get; set; }

    private async Task GotoPreviousById()
    {
        if (LanguageEntry == null) return;
        var previous = await db.GetPreviousByIdAsync(LanguageEntry);
        if (previous.IsSuccess)
        {
            LanguageEntry = previous.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }

    private async Task GotoNextById()
    {
        if (LanguageEntry == null) return;
        var next = await db.GetNextByIdAsync(LanguageEntry);
        if (next.IsSuccess)
        {
            LanguageEntry = next.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }

    private async Task GotoLastById()
    {
        var last = await db.GetLastByIdAsync();
        if (last.IsSuccess)
        {
            LanguageEntry = last.Value;
            await OnLanguageEntryChanged.InvokeAsync(LanguageEntry);
        }
    }
}