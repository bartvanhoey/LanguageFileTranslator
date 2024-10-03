using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Services.IndexedDb;
using JsonTranslatorApp.Services.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using static JsonTranslatorApp.Models.ValueObjects.LanguageEntry;

namespace JsonTranslatorApp.Components.Importer;

public class JsonFileImporterBase : ComponentBase
{
    private const string DefaultStatus = "Drop a text file here to view it or click to choose a file";
    protected ElementReference DropZoneElement;
    protected IJSObjectReference? DropZoneInstance;
    protected InputFile? InputFile;
    protected IJSObjectReference? DropZoneModule;
    protected IJSObjectReference? IndexedDbServiceModule;
    protected string Status = DefaultStatus;

    // [Inject] private IFileImportService? FileImportService { get; set; }
    [Inject] private IJSRuntime? JsRuntime { get; set; }
    [Inject] private IBrowserLocalStorageService? LocalStorageSvc { get; set; }
    [Inject] private IndexedDbService? IndexedDbSvc { get; set; }
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
        var jsonImportFile = CreateLanguageEntry(e.File.Name, memoryStream.ToArray());
        ShowSpinner = false;
        if (jsonImportFile.IsFailure)
        {
            ImportMessage = $"Error: {jsonImportFile.Error?.Message ?? "Import NOT successful"}";
            return;
        }


        try
        {
            var abpRootModel = jsonImportFile.Value.Json.ConvertTo<AbpRootModel>();
            var abpRootModel2 = jsonImportFile.Value.Json.ConvertTo<AbpRootModelFalse>();
            if (IndexedDbSvc != null && abpRootModel != null)
            {
                foreach (var (key, value) in abpRootModel.texts) 
                    await IndexedDbSvc.SetValueAsync("translations", new { Id = key, Name = value });    
            }
         
   
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }

        Status = DefaultStatus;
        ImportMessage = null;
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


