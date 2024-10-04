using JsonTranslatorApp.Models.Cultures;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;

namespace JsonTranslatorApp.Infra.Extensions;

public class PlainJsonLanguageFileResult(List<LanguageEntryItem> languageEntryItems, InfoCulture culture, PlainJsonLanguageFileModel plainJsonModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public PlainJsonLanguageFileModel PlainJsonModel { get; } = plainJsonModel;
}