using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

namespace LanguageFileTranslatorApp.Models.ValueObjects;

public class LanguageEntry
{
    public LanguageEntry(AbpLanguageFileModel model)
    {
          
    }
    
    public List<LanguageEntryItem> Items { get; set; } = [];
}