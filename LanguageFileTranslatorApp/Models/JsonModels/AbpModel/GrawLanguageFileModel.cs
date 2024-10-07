using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

public class GrawLanguageFileModel(List<LanguageEntryItem> languageEntryItems) : LanguageFileModelBase
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    
}