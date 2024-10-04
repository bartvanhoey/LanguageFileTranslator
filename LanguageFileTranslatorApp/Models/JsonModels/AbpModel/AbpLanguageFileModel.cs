namespace LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

public class AbpLanguageFileModel : LanguageFileModelBase
{
    public string? Culture { get; set; }
    public Dictionary<string, string> Texts { get; set; } = new();

}