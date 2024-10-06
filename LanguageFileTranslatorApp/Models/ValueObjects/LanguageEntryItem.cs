using System.Diagnostics.CodeAnalysis;

namespace LanguageFileTranslatorApp.Models.ValueObjects;

public class LanguageEntryItem
{
    public LanguageEntryItem(string key, string? value, string? culture, int index)
    {
        Key = key;
        Value = value;
        Culture = culture;
        Index = index;
        Id = $"{culture}#{Key}";
    }

    public string Id { get; set; }
    public string Key { get; set; }
    public string? Value { get; set; }
    public int Index { get; set; }
    public string? Culture  { get; set; }
}