namespace LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

public class StructuredJsonLanguageFileModel(Dictionary<string, string> texts) : LanguageFileModelBase
{
    public Dictionary<string, string> Texts { get; set; } = texts;
}