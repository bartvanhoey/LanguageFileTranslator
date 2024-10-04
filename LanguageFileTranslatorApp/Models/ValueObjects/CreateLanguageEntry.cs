using LanguageFileTranslatorApp.Infra.Extensions;
using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Infra.Funcky.ValueObjectClass;
using LanguageFileTranslatorApp.Models.Cultures;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using static System.IO.Path;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultClass.Result;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultErrors.ResultErrorFactory;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace LanguageFileTranslatorApp.Models.ValueObjects;

public class LanguageEntry : ValueObject<LanguageEntry>
{
    private static readonly string[] AllowedFileExtensions = [".json"];

    public InfoCulture Culture { get; }
    public string Extension { get; }
    public string FileName { get; }
    public LanguageFileModelBase LanguageFileModel { get; set; }

    private LanguageEntry(InfoCulture culture, string fileFileName, AbpLanguageFileResult abpLanguageFile )
    {
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        LanguageFileModel = abpLanguageFile.AbpModel;
    }

    private LanguageEntry(InfoCulture culture, string fileFileName, StructuredJsonLanguageFileResult structuredJsonLanguageFile)
    {
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        LanguageFileModel = structuredJsonLanguageFile.StructuredJsonModel;
    }

    private LanguageEntry(InfoCulture culture, string fileFileName, PlainJsonLanguageFileResult plainJsonLanguageFile)
    {
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        LanguageFileModel = plainJsonLanguageFile.PlainJsonModel;
    }


    public static Result<LanguageEntry> CreateLanguageEntry(string? fileName, string json) 
        => CreateLanguageEntry(fileName, json.ToByteArray());

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

        var abpLanguageFile = json.ConvertToAbpLanguageFileResult(cultureResult.Value);
        if (abpLanguageFile.IsSuccess) return Ok(new LanguageEntry(cultureResult.Value, fileName, abpLanguageFile.Value));
        
        var structuredJsonFile =  json.ConvertToStructuredJsonLanguageFileResult(cultureResult.Value);
        if (structuredJsonFile.IsSuccess) return Ok(new LanguageEntry(cultureResult.Value, fileName, structuredJsonFile.Value));
        
        var plainJsonFile =  json.ConvertToPlainJsonLanguageFileResult(cultureResult.Value);
        return plainJsonFile.IsSuccess ? Ok(new LanguageEntry(cultureResult.Value, fileName, plainJsonFile.Value)) : Fail<LanguageEntry>(NoEntriesInImportFile);
    }


    protected override bool EqualsCore(LanguageEntry other) => FileName == other.FileName;
    protected override int GetHashCodeCore() => FileName.GetHashCode();
}