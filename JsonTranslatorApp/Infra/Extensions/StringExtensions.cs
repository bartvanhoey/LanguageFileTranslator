using System.Text.Json;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
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
            using var document = JsonDocument.Parse(json ?? throw new InvalidOperationException(), options);
            return Ok();
        }
        catch (Exception exception)
        {
            return Fail(CouldNotParseJsonDocument(exception));
        }
    }
}