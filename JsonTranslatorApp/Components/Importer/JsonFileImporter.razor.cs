using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.LanguageEntries;
using JsonTranslatorApp.Services.IndexedDb;
using JsonTranslatorApp.Services.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using static JsonTranslatorApp.Models.ValueObjects.JsonImportFile;

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
        var jsonImportFile = CreateJsonImportFile(e.File.Name, memoryStream.ToArray());
        ShowSpinner = false;
        if (jsonImportFile.IsFailure)
        {
            ImportMessage = $"Error: {jsonImportFile.Error?.Message ?? "Import NOT successful"}";
            return;
        }

        var jsonString = jsonImportFile.Value.Content.GetJsonString();

        if (jsonString.IsNullOrWhiteSpace())
        {
            ImportMessage = $"Error: No entries in the import file";
            return;
        }

        var options = new JsonDocumentOptions
        {
            AllowTrailingCommas = true, 

        };

        try
        {
            var abpRootModel = jsonString?.ConvertTo<AbpRootModel>();

            if (IndexedDbSvc != null && abpRootModel != null)
            {
                foreach (var (key, value) in abpRootModel.texts)
                {
                    await IndexedDbSvc.SetValueAsync("translations", new { Id = key, Name = value });
                }    
            }
                
            
            
            
        
            
            
            // var jsonObject = JsonNode.Parse(jsonString).AsObject();


            using var document = JsonDocument.Parse(jsonString ?? throw new InvalidOperationException(), options);
            var rootElement = document.RootElement;
            var jsonElement = rootElement.GetProperty("culture");
            Console.WriteLine($"culture: {jsonElement}" );
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }


        if (LocalStorageSvc != null) await LocalStorageSvc.SaveJsonFileNamesAsync(jsonImportFile.Value.Name);
        // var result = await FileImportService!.ImportFileAsync(importFile.Value);
        // ImportMessage = result.IsSuccess
        //     ? $"Import {importFile.Value.Name} Successful"
        //     : $"Error: Import {importFile.Value.Name} NOT Successful";


        // if (IndexedDbSvc != null)
        //     await IndexedDbSvc.SetValueAsync("books", new { Id = "Menu:Book", Name = "MyBookName" });
        // if (IndexedDbSvc != null)
        // {
        //     var book = await IndexedDbSvc.GetValueAsync<JsonDocument>("books", "Menu:Book");
        //     var bookName = book.RootElement.GetProperty("name").GetString() ?? "NotFound";
        // }
        //
        // if (IndexedDbSvc != null)
        // {
        //     var book = await IndexedDbSvc.GetAllAsync<JsonDocument>("languageEntries", jsonImportFile.Value.Name);
        //     // var bookName = book.RootElement.GetProperty("name").GetString() ?? "NotFound";
        // }

        Status = DefaultStatus;
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


