using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Infra.Funcky.ResultErrors;
using LanguageFileTranslatorApp.Models.Cultures;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;
using static System.Text.Json.JsonDocument;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultClass.Result;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultErrors.ResultErrorFactory;

namespace LanguageFileTranslatorApp.Infra.Extensions;

public static class StringExtensions
{
    // Modified Extension method of the ABP Framework
    [ContractAnnotation("null <= this:null")]
    public static string ToSentenceCase(this string @this) =>
        string.IsNullOrWhiteSpace(@this)
            ? @this
            : Regex.Replace(@this, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLowerInvariant(m.Value[1]));

    // Modified Extension method of the ABP Framework
    [ContractAnnotation("null => true")]
    public static bool IsNullOrWhiteSpace(this string? @this) => string.IsNullOrWhiteSpace(@this);

    public static string GetUntilOrEmpty(this string text, string stopAt = "-")
    {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;
        var charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);
        return charLocation > 0 ? text[..charLocation] : string.Empty;
    }
    
    public static string GetLastCharacters(this string source, string extension)
    {
        var tailLength = extension.Length + 11;
        return tailLength >= source.Length ? source : source[^tailLength..];
    }
    
    public static T? ConvertTo<T>(this string jsonString) =>
                  jsonString switch
                  {
                      null => throw new ArgumentNullException($@"ConvertTo: You cannot convert a null string to a Type"),
                      "[]" => default,
                      _ => JsonSerializer.Deserialize<T>(jsonString,
                          new JsonSerializerOptions
                          {
                              PropertyNameCaseInsensitive = true,
                              
                          })
                  };

    public static Result<AbpLanguageFileModel?>? ConvertToAbpLanguageFileModel(this string jsonString)
    {
        switch (jsonString)
        {
            case null:
                throw new ArgumentNullException($"{nameof(ConvertToAbpLanguageFileModel)}: You cannot convert a null string to a Type");
            case "[]":
                return default;
            default:
            {
                var result  = Deserialize(jsonString);
                return result.IsSuccess ? result : Fail<AbpLanguageFileModel?>(CouldNotConvertJsonToAbpLanguageFileModel);
            }
        }
    }

    private static Result<AbpLanguageFileModel?> Deserialize(string jsonString)
    {
        try
        {
            var abpLanguageFileModel = JsonSerializer.Deserialize<AbpLanguageFileModel>(jsonString,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    
                });
            return Ok(abpLanguageFileModel) ;
        }
        catch (Exception)
        {
            return Fail<AbpLanguageFileModel>(ResultErrorFactory.JsonException);
        }
    }


    public static Result CheckIsValidJsonDocument(this string? json)
    {
        if (json == null || string.IsNullOrWhiteSpace(json)) return Fail(JsonDocumentIsNullOrEmpty());
        try
        {
            var options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };
            using var document = Parse(json ?? throw new InvalidOperationException(), options);
            return Ok();
        }
        catch (Exception exception)
        {
            return Fail(CouldNotParseJsonDocument(exception));
        }
    }

    public static Result<AbpLanguageFileResult> ConvertToAbpLanguageFileResult(this string? json, InfoCulture culture)
    {
        if (json == null || string.IsNullOrWhiteSpace(json)) return Fail<AbpLanguageFileResult>(JsonDocumentIsNullOrEmpty());
        var abpModel = json?.ConvertToAbpLanguageFileModel();
        
        if (abpModel == null || abpModel.IsFailure) return Fail<AbpLanguageFileResult>(NoAbpLanguageFile);
        
        if (abpModel?.Value?.Texts.Count == 0 || abpModel?.Value?.Culture != culture.Name)
            return Fail<AbpLanguageFileResult>(NoAbpLanguageFile);
        
        var languageEntryItems = abpModel.Value.Texts
            .Select((x, i) => new LanguageEntryItem(x.Key, x.Value, culture.Name, i)).ToList();
        return Ok(new AbpLanguageFileResult(languageEntryItems, culture, abpModel.Value));
    }
    
    public static Result<StructuredJsonLanguageFileResult> ConvertToStructuredJsonLanguageFileResult(this string? json, InfoCulture culture)
    {
        try
        {
            if (json == null || string.IsNullOrWhiteSpace(json)) return Fail<StructuredJsonLanguageFileResult>(JsonDocumentIsNullOrEmpty());
            var rootNode = JsonNode.Parse(json);
            var firstNode = rootNode?[rootNode[0]?.GetPath().Replace("$.", "") ?? throw new InvalidOperationException()] as JsonObject;
            var translations = firstNode.GetTranslationsFromJsonObject(new Dictionary<string, string>());
        
            if (translations.Count == 0)
                return Fail<StructuredJsonLanguageFileResult>(CouldNotGetTranslationsFromJsonObject);
        
            var languageEntryItems = translations.GetLanguageEntryItems(culture);

            var model = new StructuredJsonLanguageFileModel(translations);

            return Ok(new StructuredJsonLanguageFileResult(languageEntryItems, culture, model));
        }
        catch (Exception)
        {
            return Fail<StructuredJsonLanguageFileResult>(NoStructuredJsonFile);
        }
    }
    

    public static Result<PlainJsonLanguageFileResult> ConvertToPlainJsonLanguageFileResult(this string? json, InfoCulture culture)
    {
        try
        {
            if (json == null || string.IsNullOrWhiteSpace(json)) return Fail<PlainJsonLanguageFileResult>(JsonDocumentIsNullOrEmpty());

            var rootNode = JsonNode.Parse(json) as JsonObject;
            var translations = rootNode.GetTranslationsFromJsonObject(new Dictionary<string, string>());
        
            if (translations.Count == 0)
                return Fail<PlainJsonLanguageFileResult>(CouldNotGetTranslationsFromJsonObject);

            var languageEntryItems = translations.GetLanguageEntryItems(culture);

            var model = new PlainJsonLanguageFileModel(translations);

            return Ok(new PlainJsonLanguageFileResult(languageEntryItems, culture, model));
        }
        catch (Exception)
        {
            return Fail<PlainJsonLanguageFileResult>(NoPlainJsonLanguageFile);
        }
    }
    
    public static Result<GrawLanguageFileResult> ConvertToGrawLanguageFileResult(this byte[] fileContent, InfoCulture culture)
    {
        try
        {
            var grawLanguageEntryItems = fileContent.ConvertTo<List<GrawLanguageEntryItem>>();
            if (grawLanguageEntryItems == null || grawLanguageEntryItems.Count == 0) return Fail<GrawLanguageFileResult>(CouldNotGetGrawLanguageEntryItems);
            var languageEntryItems = grawLanguageEntryItems.Select(x => new LanguageEntryItem(x.Name, x.Text, culture.Name, x.Id)).ToList();
            var model = new GrawLanguageFileModel(languageEntryItems);
            return Ok(new GrawLanguageFileResult(languageEntryItems, culture, model));
        }
        catch (Exception)
        {
            return Fail<GrawLanguageFileResult>(NoPlainJsonLanguageFile);
        }
    }
    

    public static byte[] ToByteArray(this string text) => Encoding.ASCII.GetBytes(text);
}

public class GrawLanguageEntryItem
{
    public required string Name { get; set; }
    public int Id { get; set; }
    public required string Text { get; set; }
    public int DepartmentId { get; set; }
}