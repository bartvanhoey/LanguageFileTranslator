using LanguageFileTranslatorApp.Models.Cultures;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Infra.Extensions;

public class GrawLanguageFileResult(List<LanguageEntryItem> languageEntryItems, InfoCulture culture, GrawLanguageFileModel grawLanguageFileModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public GrawLanguageFileModel GrawLanguageFileModel { get; } = grawLanguageFileModel;
}