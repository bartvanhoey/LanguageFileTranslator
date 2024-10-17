using LanguageFileTranslatorApp.Services.IndexedDb;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using static LanguageFileTranslatorApp.Models.ValueObjects.LanguageFile;

namespace LanguageFileTranslatorApp.Components.Importer;

public class
    JsonFileImporterBase : ComponentBase
{
    private const string DefaultStatus = "Drop a file here or click to choose one";
    protected ElementReference DropZoneElement;
    private IJSObjectReference? _dropZoneInstance;
    protected InputFile? InputFile;
    private IJSObjectReference? _dropZoneModule;
    protected string Status = DefaultStatus;
    protected string? ImportMessage { get; private set; } = string.Empty;
    protected bool ShowSpinner { get; set; }

    [Inject] private IJSRuntime? JsRuntime { get; set; }
    [Inject] private ILanguageEntryDbService? LanguageEntryDb { get; set; }
    [Inject] private ILanguageEntryItemDbService? LanguageEntryItemDb { get; set; }

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
        var createLanguageFile = CreateLanguageFile(e.File.Name, memoryStream.ToArray());
        ShowSpinner = false;

        if (createLanguageFile.IsSuccess)
        {
            Status = DefaultStatus;
            ImportMessage = null;
            
            if (LanguageEntryDb == null || LanguageEntryItemDb == null) return;
            
            await LanguageEntryDb.InsertLanguageEntriesAsync(createLanguageFile.Value);
            await LanguageEntryItemDb.InsertLanguageEntryItemsAsync(createLanguageFile.Value);
        }
        else
            ImportMessage = $"Error: {createLanguageFile.Error?.Message ?? "Import NOT successful"}";

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