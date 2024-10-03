using System.Text.Json;
using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
using JsonTranslatorApp.Infra.Funcky.ValueObjectClass;
using JsonTranslatorApp.Models.Cultures;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using static System.IO.Path;
using static JsonTranslatorApp.Infra.Funcky.ResultClass.Result;
using static JsonTranslatorApp.Infra.Funcky.ResultErrors.ResultErrorFactory;

namespace JsonTranslatorApp.Models.ValueObjects;

public class LanguageEntry : ValueObject<LanguageEntry>
{
    private static readonly string[] AllowedFileExtensions = [".json"];
    private static readonly string[] Separator = ["-"];

    private LanguageEntry(string extension, InfoCulture culture, string fileName, string json,
        List<LanguageEntryItem> languageEntryItems, LanguageFileModelBase languageFileModel)
    {
        LanguageEntryItems = languageEntryItems;
        Culture = culture;
        Extension = extension;
        Name = fileName;
        Json = json;
        LanguageFileModel = languageFileModel;
    }

    public InfoCulture Culture { get; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Extension { get; }
    public string Name { get; }
    public string Json { get; }

    public List<LanguageEntryItem> LanguageEntryItems;
    public LanguageFileModelBase LanguageFileModel { get; set; }

    public static Result<LanguageEntry> CreateLanguageEntry(string? fileName, byte[]? fileContent)
    {
        if (fileName == null || fileName.IsNullOrWhiteSpace()) return Fail<LanguageEntry>(NameIsEmpty);
        fileName = fileName.Trim();

        if (fileContent is not { Length: > 2 }) return Fail<LanguageEntry>(ContentIsEmpty);

        var extension = GetExtension(fileName);
        if (extension.IsNullOrWhiteSpace()) return Fail<LanguageEntry>(ExtensionIsEmpty);
        if (!AllowedFileExtensions.Contains(extension)) return Fail<LanguageEntry>(ExtensionIsNotAllowed);

        var cultureResult = InfoCultureHelper.GetInfoCulture(fileName, extension);
        if (cultureResult.IsFailure) return Fail<LanguageEntry>(cultureResult.Error);

        var json = fileContent.GetJsonString();
        if (json != null && json.IsNullOrWhiteSpace()) return Fail<LanguageEntry>(NoEntriesInImportFile);

        var jsonDocResult = json.CheckIsValidJsonDocument();
        if (jsonDocResult.IsFailure) return Fail<LanguageEntry>(jsonDocResult.Error);

        var abpLanguageFileModel = json?.ConvertTo<AbpLanguageFileModel>();
        if (abpLanguageFileModel?.texts.Count > 0)
        {
            var languageEntryItems = abpLanguageFileModel.texts
                .Select((x, i) => new LanguageEntryItem { Key = x.Key, Value = x.Value, Id = i }).ToList();
            return Ok(new LanguageEntry(extension, cultureResult.Value, fileName, json ?? throw new InvalidOperationException(), languageEntryItems,
                abpLanguageFileModel ?? throw new InvalidOperationException()));
        }

        return Fail<LanguageEntry>(NoEntriesInImportFile);
    }


    protected override bool EqualsCore(LanguageEntry other) => Name == other.Name;
    protected override int GetHashCodeCore() => Name.GetHashCode();
}