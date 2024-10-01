using System.Text.Json;
using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
using JsonTranslatorApp.Infra.Funcky.ValueObjectClass;
using JsonTranslatorApp.Models.Cultures;
using static System.IO.Path;
using static System.StringSplitOptions;
using static JsonTranslatorApp.Infra.Funcky.ResultClass.Result;
using static JsonTranslatorApp.Infra.Funcky.ResultErrors.ErrorFactory;

namespace JsonTranslatorApp.Models.ValueObjects;

public class JsonImportFile : ValueObject<JsonImportFile>
{
    private static readonly string[] AllowedFileExtensions = [".json"];
    private static readonly string[] Separator = ["-"];

    private JsonImportFile(string extension, InfoCulture culture, string fileName, string json)
    {
        Culture = culture;
        Extension = extension;
        Name = fileName;
        Json = json;
    }

    public InfoCulture Culture { get; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Extension { get; }
    public string Name { get; }
    public string Json { get; }

    public static Result<JsonImportFile> CreateJsonImportFile(string? fileName, byte[]? fileContent)
    {
        if (fileName == null || fileName.IsNullOrWhiteSpace()) return Fail<JsonImportFile>(NameIsEmpty);
        fileName = fileName.Trim();

        if (fileContent is not { Length: > 2 }) return Fail<JsonImportFile>(ContentIsEmpty);

        var extension = GetExtension(fileName);
        if (extension.IsNullOrWhiteSpace()) return Fail<JsonImportFile>(ExtensionIsEmpty);
        if (!AllowedFileExtensions.Contains(extension)) return Fail<JsonImportFile>(ExtensionIsNotAllowed);

        var cultureResult = InfoCultureHelper.GetInfoCulture(fileName,extension);
        if (cultureResult.IsFailure) return Fail<JsonImportFile>(cultureResult.Error);
        
        var json = fileContent.GetJsonString();
        if (json.IsNullOrWhiteSpace()) return Fail<JsonImportFile>(NoEntriesInImportFile);

        try
        {
            var options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };
            using var document = JsonDocument.Parse(json ?? throw new InvalidOperationException(), options);
        }
        catch (Exception exception)
        {
            return Fail<JsonImportFile>(CouldNotParseJsonDocument(exception));
        }
        
        
        
        return Ok(new JsonImportFile(extension, cultureResult.Value, fileName, json));
    }

    protected override bool EqualsCore(JsonImportFile other) => Name == other.Name;
    protected override int GetHashCodeCore() => Name.GetHashCode();
}