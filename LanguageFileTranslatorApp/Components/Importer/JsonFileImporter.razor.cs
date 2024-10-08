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
    private const string DefaultStatus = "Drop a json file here or click to choose a json file";
    protected ElementReference DropZoneElement;
    private IJSObjectReference? _dropZoneInstance;
    protected InputFile? InputFile;
    private IJSObjectReference? _dropZoneModule;
    protected string Status = DefaultStatus;
    protected string? ImportMessage { get; private set; } = string.Empty;
    public bool ShowSpinner { get; set; }

    [Inject] private IJSRuntime? JsRuntime { get; set; }
    [Inject] private IBrowserLocalStorageService? LocalStorageSvc { get; set; }
    [Inject] private ILanguageEntryDbService? Db { get; set; }

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
            if (Db == null) return;
            await Db.InsertTranslationsAsync<string>(languageFile.Value);
        }
        else
            ImportMessage = $"Error: {languageFile.Error?.Message ?? "Import NOT successful"}";

        StateHasChanged();
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (JsRuntime != null) 
                _dropZoneModule = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/dropZone.js");
            
            if (_dropZoneModule != null && InputFile != null)
                    _dropZoneInstance = await _dropZoneModule.InvokeAsync<IJSObjectReference>("initializeFileDropZone", DropZoneElement, InputFile.Element);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_dropZoneInstance != null)
        {
            await _dropZoneInstance.InvokeVoidAsync("dispose");
            await _dropZoneInstance.DisposeAsync();
        }
    }
}