using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

public class LanguageFileModelBase
{
    public List<LanguageEntryItem> LanguageEntryItems { get; set; } = [];
}