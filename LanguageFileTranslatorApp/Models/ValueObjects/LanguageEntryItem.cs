using System.Diagnostics.CodeAnalysis;

namespace LanguageFileTranslatorApp.Models.ValueObjects;

public class LanguageEntryItem
{
    public LanguageEntryItem(string key, string? value, string? culture, int idLanguageEntryItem)
    {
        Key = key;
        Value = value;
        Culture = culture;
        IdLanguageEntryItem = idLanguageEntryItem;
        Id = $"{culture}#{Key}";
    }

    public string? Id { get; set; }
    public string Key { get; set; }
    public string? Value { get; set; }
    public int IdLanguageEntryItem { get; set; }
    public string? Culture  { get; set; }
}