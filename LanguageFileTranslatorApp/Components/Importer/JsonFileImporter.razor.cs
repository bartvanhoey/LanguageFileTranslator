using LanguageFileTranslatorApp.Services.IndexedDb;
using LanguageFileTranslatorApp.Services.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using static LanguageFileTranslatorApp.Models.ValueObjects.LanguageFile;

namespace LanguageFileTranslatorApp.Components.Importer;

public class
    JsonFileImporterBase : ComponentBase
{
    private const string DefaultStatus = "Drop a text file here to view it or click to choose a file";
    protected ElementReference DropZoneElement;
    protected IJSObjectReference? DropZoneInstance;
    protected InputFile? InputFile;
    protected IJSObjectReference? DropZoneModule;
    protected IJSObjectReference? IndexedDbServiceModule;
    protected string Status = DefaultStatus;
    protected string? ImportMessage { get; private set; } = string.Empty;
    public bool ShowSpinner { get; set; }

    [Inject] private IJSRuntime? JsRuntime { get; set; }
    [Inject] private IBrowserLocalStorageService? LocalStorageSvc { get; set; }
    [Inject] private IIndexedDbService? IndexedDbSvc { get; set; }

    protected async Task FileChangeAsync(InputFileChangeEventArgs e)
    {
        ImportMessage = "Start Importing";
        StateHasChanged();
        Status = e.File.Name;
        const long maxFileSize = 1024 * 1024; // max 1MB
        using var memoryStream = new MemoryStream();
        await e.File.OpenReadStream(maxFileSize).CopyToAsync(memoryStream);
        ShowSpinner = true;
        StateHasChanged();
        var languageFile = CreateLanguageFile(e.File.Name, memoryStream.ToArray());
        ShowSpinner = false;

        if (languageFile.IsSuccess)
        {
            Status = DefaultStatus;
            ImportMessage = null;
            if (IndexedDbSvc == null) return;

            foreach (var (key, value) in languageFile.Value.Model.Items)
                await IndexedDbSvc.InsertTranslationInDb<string>(languageFile.Value.Culture.TwoLetterIso, key, value);
        }
        else
            ImportMessage = $"Error: {languageFile.Error?.Message ?? "Import NOT successful"}";

        StateHasChanged();
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Load the JS file
            DropZoneModule = await JsRuntime!.InvokeAsync<IJSObjectReference>("import", "./js/dropZone.js");

            try
            {
                IndexedDbServiceModule =
                    await JsRuntime!.InvokeAsync<IJSObjectReference>("import", "./js/indexedDbService.js");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            // Initialize the drop zone
            DropZoneInstance =
                await DropZoneModule.InvokeAsync<IJSObjectReference>("initializeFileDropZone", DropZoneElement,
                    InputFile!.Element);

            try
            {
                await IndexedDbServiceModule.InvokeVoidAsync("initialize");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (DropZoneInstance != null)
        {
            await DropZoneInstance.InvokeVoidAsync("dispose");
            await DropZoneInstance.DisposeAsync();
        }

        if (IndexedDbServiceModule != null) await IndexedDbServiceModule.DisposeAsync();
    }
}