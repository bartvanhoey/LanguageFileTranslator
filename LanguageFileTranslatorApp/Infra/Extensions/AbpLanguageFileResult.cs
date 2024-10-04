using LanguageFileTranslatorApp.Models.Cultures;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Infra.Extensions;

public class AbpLanguageFileResult(
    List<LanguageEntryItem> languageEntryItems,
    InfoCulture culture,
    AbpLanguageFileModel abpModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public AbpLanguageFileModel AbpModel { get; } = abpModel;
}