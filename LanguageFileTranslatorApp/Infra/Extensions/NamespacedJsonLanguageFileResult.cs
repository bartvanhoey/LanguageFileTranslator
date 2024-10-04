using LanguageFileTranslatorApp.Models.Cultures;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;

namespace LanguageFileTranslatorApp.Infra.Extensions;

public class StructuredJsonLanguageFileResult(List<LanguageEntryItem> languageEntryItems, InfoCulture culture, StructuredJsonLanguageFileModel structuredJsonModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public StructuredJsonLanguageFileModel StructuredJsonModel { get; } = structuredJsonModel;
}