using LanguageFileTranslatorApp.Models.Cultures;
using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Infra.Extensions;

public static class DictionaryExtensions
{
    public static List<LanguageEntryItem> GetLanguageEntryItems(this Dictionary<string, string> translations,
        InfoCulture culture) =>
        translations
            .Select((x, i) => new LanguageEntryItem(x.Key, x.Value, culture.Name, i)).ToList();
}