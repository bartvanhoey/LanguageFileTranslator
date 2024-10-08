using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

public class GrawLanguageFileModel : LanguageFileModelBase
{
    public GrawLanguageFileModel(List<LanguageEntryItem> languageEntryItems) 
        => LanguageEntryItems = languageEntryItems;
}