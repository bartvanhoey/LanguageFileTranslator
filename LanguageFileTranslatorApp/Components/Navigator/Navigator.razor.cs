using LanguageFileTranslatorApp.Services.IndexedDb;
using Microsoft.AspNetCore.Components;

namespace LanguageFileTranslatorApp.Components.Navigator;

public partial class Navigator(ILanguageEntryDbService db) : ComponentBase
{
    private async Task GotoFirstByKey()
    {
        var firstByKey = await db.GetFirstByKeyAsync();
    }

    private void GotoPreviousByKey()
    {
        db.GetPreviousByKeyAsync("key");
    }

    private void GotoNextByKey()
    {
        db.GetNextByKeyAsync("key");
    }

    private void GotoLastByKey()
    {
        db.GetLastByKeyAsync();
    }

    private void GotoFirstById()
    {
        db.GetFirstByIdAsync();
    }

    private void GotoPreviousById()
    {
        db.GetPreviousByIdAsync(1);
    }

    private void GotoNextById()
    {
        db.GetNextByIdAsync(2);
    }

    private void GotoLastById()
    {
        db.GetLastByIdAsync();
    }
}