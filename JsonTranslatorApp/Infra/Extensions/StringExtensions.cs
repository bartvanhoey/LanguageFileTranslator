using System.Text.Json;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
using JsonTranslatorApp.Infra.Funcky.ResultErrors;
using JsonTranslatorApp.Models.Cultures;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;
using static System.Text.Json.JsonDocument;
using static JsonTranslatorApp.Infra.Funcky.ResultClass.Result;
using static JsonTranslatorApp.Infra.Funcky.ResultErrors.ResultErrorFactory;

namespace JsonTranslatorApp.Infra.Extensions;

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
        var abpModel = json?.ConvertTo<AbpLanguageFileModel>();
        if (abpModel?.texts.Count > 0 && abpModel.culture == culture.TwoLetterIso)
        {
            var languageEntryItems = abpModel.texts
                .Select((x, i) => new LanguageEntryItem { Key = x.Key, Value = x.Value, Id = i }).ToList();
            return Ok(new AbpLanguageFileResult(languageEntryItems, culture, abpModel));
        }
        return Fail<AbpLanguageFileResult>(NoAbpLanguageFile);
    }
    
    
    
}

public class NamespacedJsonLanguageFileResult(List<LanguageEntryItem> languageEntryItems, InfoCulture culture, NamespacedJsonLanguageFileModel namespacedJsonModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public NamespacedJsonLanguageFileModel NamespacedJsonModel { get; } = namespacedJsonModel;
}

public class AbpLanguageFileResult(
    List<LanguageEntryItem> languageEntryItems,
    InfoCulture culture,
    AbpLanguageFileModel abpModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public AbpLanguageFileModel AbpModel { get; } = abpModel;
}