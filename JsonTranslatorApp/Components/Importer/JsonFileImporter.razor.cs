using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using static JsonTranslatorApp.Models.JsonImportFile;

namespace JsonTranslatorApp.Components.Importer;

public class JsonFileImporterBase : ComponentBase
{
    private const string DefaultStatus = "Drop a text file here to view it or click to choose a file";
    protected ElementReference DropZoneElement;
    protected IJSObjectReference? DropZoneInstance;
    protected InputFile? InputFile;
    protected IJSObjectReference? Module;
    protected string Status = DefaultStatus;
    // [Inject] private IFileImportService? FileImportService { get; set; }
    [Inject] private IJSRuntime? JsRuntime { get; set; }
    protected string? ImportMessage { get; private set; } = string.Empty;

    public bool ShowSpinner { get; set; }


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
        var jsonImportFile = CreateJsonImportFile(e.File.Name, memoryStream.ToArray());
        ShowSpinner = false;
        if (jsonImportFile.IsFailure)
        {
            ImportMessage = $"Error: {jsonImportFile.Error?.Message ?? "Import NOT successful"}";
        }
        else
        {
            // var result = await FileImportService!.ImportFileAsync(importFile.Value);
            // ImportMessage = result.IsSuccess
            //     ? $"Import {importFile.Value.Name} Successful"
            //     : $"Error: Import {importFile.Value.Name} NOT Successful";
        }

        Status = DefaultStatus;
        StateHasChanged();
    }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Load the JS file
            Module = await JsRuntime!.InvokeAsync<IJSObjectReference>("import", "./js/dropZone.js");

            // Initialize the drop zone
            DropZoneInstance =
                await Module.InvokeAsync<IJSObjectReference>("initializeFileDropZone", DropZoneElement,
                    InputFile!.Element);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (DropZoneInstance != null)
        {
            await DropZoneInstance.InvokeVoidAsync("dispose");
            await DropZoneInstance.DisposeAsync();
        }

        if (Module != null) await Module.DisposeAsync();
    }
}