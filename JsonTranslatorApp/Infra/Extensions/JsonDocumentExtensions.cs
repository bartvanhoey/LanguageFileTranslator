using System.Text.Json;
using System.Text.Json.Nodes;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
using JsonTranslatorApp.Models.Cultures;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;
using static JsonTranslatorApp.Infra.Funcky.ResultClass.Result;

namespace JsonTranslatorApp.Infra.Extensions;

public static class JsonDocumentExtensions
{
    public static Result<NamespacedJsonLanguageFileResult> ConvertToNamespacedJsonLanguageFileResult(this string? json, InfoCulture culture)
    {
        var rootNode = JsonNode.Parse(json);
        var firstNode = rootNode?[rootNode[0]?.GetPath().Replace("$.", "") ?? throw new InvalidOperationException()] as JsonObject;
        var translations = firstNode.GetTranslationsFromJsonObject(new Dictionary<string, string>());
        
        var languageEntryItems = translations
             .Select((x, i) => new LanguageEntryItem { Key = x.Key, Value = x.Value, Id = i }).ToList();

        var model = new NamespacedJsonLanguageFileModel(translations);

        return Ok(new NamespacedJsonLanguageFileResult(languageEntryItems, culture, model));
    }
}