using JsonTranslatorApp.Models.Cultures;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;

namespace JsonTranslatorApp.Infra.Extensions;

public class AbpLanguageFileResult(
    List<LanguageEntryItem> languageEntryItems,
    InfoCulture culture,
    AbpLanguageFileModel abpModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public AbpLanguageFileModel AbpModel { get; } = abpModel;
}