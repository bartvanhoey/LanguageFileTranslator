using JsonTranslatorApp.Models.ValueObjects;

namespace JsonTranslatorApp.Infra.Extensions;

public static class DictionaryExtensions
{
    public static List<LanguageEntryItem> GetLanguageEntryItems(this Dictionary<string, string> translations) =>
        translations
            .Select((x, i) => new LanguageEntryItem { Key = x.Key, Value = x.Value, Id = i }).ToList();
}