namespace JsonTranslatorApp.Models.LanguageEntries;

public class LanguageEntry(string id, string value, string culture, string jsonfilename)
{
    public string Id { get; set; } = id;
    public string Value { get; set; } = value;
    public string Culture { get; set; } = culture;
    public string Jsonfilename { get; set; } = jsonfilename;
}