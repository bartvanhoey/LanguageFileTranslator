using LanguageFileTranslatorApp.Models.ValueObjects;
using LanguageFileTranslatorApp.Services.IndexedDb;
using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Components.Navigator;

public partial class Navigator(ILanguageEntryDbService db) : ComponentBase
{
    protected override async Task OnInitializedAsync()
    {
        var firstByKey = await db.GetFirstByKeyAsync();
        if (firstByKey.IsSuccess) LanguageEntry = firstByKey.Value;
    }

    private async Task GotoFirstByKey()
    {
        var firstByKey = await db.GetFirstByKeyAsync();
        if (firstByKey.IsSuccess) LanguageEntry = firstByKey.Value;
    }

    private async Task GotoPreviousByKey()
    {
        var previous = await db.GetPreviousByKeyAsync(LanguageEntry);
        if (previous.IsSuccess) LanguageEntry = previous.Value;
    }

    private async Task GotoNextByKey()
    {
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
        var result = await db.GetFirstByIdAsync();
        if (result.IsSuccess) LanguageEntry = result.Value;
    }

    public LanguageEntry? LanguageEntry { get; set; }

    private void GotoPreviousById()
    {
        db.GetPreviousByIdAsync(1);
    }

    private void GotoNextById()
    {
        db.GetNextByIdAsync(2);
    }

    private async Task GotoLastById()
    {
        var result = await db.GetLastByIdAsync();
        if (result.IsSuccess) LanguageEntry = result.Value;
    }
}