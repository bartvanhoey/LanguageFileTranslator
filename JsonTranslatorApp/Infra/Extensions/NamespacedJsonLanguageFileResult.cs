using JsonTranslatorApp.Models.Cultures;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;

namespace JsonTranslatorApp.Infra.Extensions;

public class StructuredJsonLanguageFileResult(List<LanguageEntryItem> languageEntryItems, InfoCulture culture, StructuredJsonLanguageFileModel structuredJsonModel)
{
    public List<LanguageEntryItem> LanguageEntryItems { get; } = languageEntryItems;
    public InfoCulture Culture { get; } = culture;
    public StructuredJsonLanguageFileModel StructuredJsonModel { get; } = structuredJsonModel;
}