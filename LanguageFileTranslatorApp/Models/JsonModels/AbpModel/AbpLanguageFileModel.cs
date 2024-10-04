namespace LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

public class AbpLanguageFileModel : LanguageFileModelBase
{
    public string? Culture { get; set; }
    public Dictionary<string, string> Texts { get; set; } = new();

}

public class StructuredJsonLanguageFileModel(Dictionary<string, string> texts) : LanguageFileModelBase
{
    public Dictionary<string, string> Texts { get; set; } = texts;
}

public class PlainJsonLanguageFileModel(Dictionary<string, string> texts) : LanguageFileModelBase
{
    public Dictionary<string, string> Texts { get; set; } = texts;
}

public class LanguageFileModelBase
{
    public Dictionary<string, string> Items { get; set; } = [];
}