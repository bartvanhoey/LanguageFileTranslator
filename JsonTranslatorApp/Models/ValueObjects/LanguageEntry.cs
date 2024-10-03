using System.Text.Json;
using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
using JsonTranslatorApp.Infra.Funcky.ValueObjectClass;
using JsonTranslatorApp.Models.Cultures;
using static System.IO.Path;
using static JsonTranslatorApp.Infra.Funcky.ResultClass.Result;
using static JsonTranslatorApp.Infra.Funcky.ResultErrors.ErrorFactory;

namespace JsonTranslatorApp.Models.ValueObjects;

public class LanguageEntry : ValueObject<LanguageEntry>
{
    private static readonly string[] AllowedFileExtensions = [".json"];
    private static readonly string[] Separator = ["-"];

    private LanguageEntry(string extension, InfoCulture culture, string fileName, string json)
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
    public string Json { get
        ; }

    public List<LanguageEntryItem> LanguageEntryItems = [];
    
    
    

    public static Result<LanguageEntry> CreateLanguageEntry(string? fileName, byte[]? fileContent)
    {
        if (fileName == null || fileName.IsNullOrWhiteSpace()) return Fail<LanguageEntry>(NameIsEmpty);
        fileName = fileName.Trim();

        if (fileContent is not { Length: > 2 }) return Fail<LanguageEntry>(ContentIsEmpty);

        var extension = GetExtension(fileName);
        if (extension.IsNullOrWhiteSpace()) return Fail<LanguageEntry>(ExtensionIsEmpty);
        if (!AllowedFileExtensions.Contains(extension)) return Fail<LanguageEntry>(ExtensionIsNotAllowed);

        var cultureResult = InfoCultureHelper.GetInfoCulture(fileName,extension);
        if (cultureResult.IsFailure) return Fail<LanguageEntry>(cultureResult.Error);
        
        var json = fileContent.GetJsonString();
        if (json.IsNullOrWhiteSpace()) return Fail<LanguageEntry>(NoEntriesInImportFile);

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
            return Fail<LanguageEntry>(CouldNotParseJsonDocument(exception));
        }
        
        
        
        return Ok(new LanguageEntry(extension, cultureResult.Value, fileName, json));
    }

    protected override bool EqualsCore(LanguageEntry other) => Name == other.Name;
    protected override int GetHashCodeCore() => Name.GetHashCode();
}