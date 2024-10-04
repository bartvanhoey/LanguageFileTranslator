using LanguageFileTranslatorApp.Models.Cultures;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Infra.Extensions;

public class PlainJsonLanguageFileResult(List<LanguageEntryItem> languageEntryItems, InfoCulture culture, PlainJsonLanguageFileModel plainJsonModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public PlainJsonLanguageFileModel PlainJsonModel { get; } = plainJsonModel;
}