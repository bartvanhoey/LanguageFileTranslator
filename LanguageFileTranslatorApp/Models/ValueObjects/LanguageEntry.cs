using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

namespace LanguageFileTranslatorApp.Models.ValueObjects;

public class LanguageEntry
{
    public LanguageEntry()
    {
    }

    public LanguageEntry(int id, string key)
    {
        Id = id;
        Key = key;
    }

    public int Id { get; set; }
    public string Key { get; set; }
}