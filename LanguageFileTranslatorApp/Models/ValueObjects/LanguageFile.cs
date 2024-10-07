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

public class LanguageFile : ValueObject<LanguageFile>
{
    private static readonly string[] AllowedFileExtensions = [".json"];
    public InfoCulture Culture { get; }
    public string Extension { get; }
    public string FileName { get; }
    public LanguageFileModelBase Model { get; set; }

    private LanguageFile(InfoCulture culture, string fileFileName, AbpLanguageFileResult abpLanguageFile )
    {
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName;
        Model = abpLanguageFile.AbpModel;
        Model.LanguageEntryItems = abpLanguageFile.AbpModel.Texts.Select((x, i) => new LanguageEntryItem(x.Key, x.Value, culture.Name, i)).ToList();

    }

    private LanguageFile(InfoCulture culture, string fileFileName, StructuredJsonLanguageFileResult structuredJsonLanguageFile)
    {
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        Model = structuredJsonLanguageFile.StructuredJsonModel;
        Model.LanguageEntryItems = structuredJsonLanguageFile.StructuredJsonModel.Texts.Select((x, i) => new LanguageEntryItem(x.Key, x.Value, culture.Name, i)).ToList();;
    }

    private LanguageFile(InfoCulture culture, string fileFileName, PlainJsonLanguageFileResult plainJsonLanguageFile)
    {
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        Model = plainJsonLanguageFile.PlainJsonModel;
        Model.LanguageEntryItems = plainJsonLanguageFile.PlainJsonModel.Texts.Select((x, i) => new LanguageEntryItem(x.Key, x.Value, culture.Name, i)).ToList();;
    }
    
    private LanguageFile(InfoCulture culture, string fileFileName, GrawLanguageFileResult plainJsonLanguageFile)
    {
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        Model = plainJsonLanguageFile.GrawLanguageFileModel;
        Model.LanguageEntryItems = plainJsonLanguageFile.GrawLanguageFileModel.LanguageEntryItems;
    }


    public static Result<LanguageFile> CreateLanguageFile(string? fileName, string json) 
        => CreateLanguageFile(fileName, json.ToByteArray());

    public static Result<LanguageFile> CreateLanguageFile(string? fileName, byte[]? fileContent)
    {
        if (fileName == null || fileName.IsNullOrWhiteSpace()) return Fail<LanguageFile>(NameIsEmpty);
        fileName = fileName.Trim();

        if (fileContent is not { Length: > 2 }) return Fail<LanguageFile>(ContentIsEmpty);

        var extension = GetExtension(fileName);
        if (extension.IsNullOrWhiteSpace()) return Fail<LanguageFile>(ExtensionIsEmpty);
        if (!AllowedFileExtensions.Contains(extension)) return Fail<LanguageFile>(ExtensionIsNotAllowed);

        var cultureResult = InfoCultureHelper.GetInfoCulture(fileName, extension);
        if (cultureResult.IsFailure) return Fail<LanguageFile>(cultureResult.Error);

        var json = fileContent.GetJsonString();
        if (json != null && json.IsNullOrWhiteSpace()) return Fail<LanguageFile>(NoEntriesInImportFile);

        var jsonDocResult = json.CheckIsValidJsonDocument();
        if (jsonDocResult.IsFailure) return Fail<LanguageFile>(jsonDocResult.Error);

        var abpLanguageFile = json.ConvertToAbpLanguageFileResult(cultureResult.Value);
        if (abpLanguageFile.IsSuccess) return Ok(new LanguageFile(cultureResult.Value, fileName, abpLanguageFile.Value));
        
        var structuredJsonFile =  json.ConvertToStructuredJsonLanguageFileResult(cultureResult.Value);
        if (structuredJsonFile.IsSuccess) return Ok(new LanguageFile(cultureResult.Value, fileName, structuredJsonFile.Value));
        
        var plainJsonFile =  json.ConvertToPlainJsonLanguageFileResult(cultureResult.Value);
         if (plainJsonFile.IsSuccess) return Ok(new LanguageFile(cultureResult.Value, fileName, plainJsonFile.Value)); 
        
        var grawLanguageJsonFile =  fileContent.ConvertToGrawLanguageFileResult(cultureResult.Value);
        return grawLanguageJsonFile.IsSuccess ? Ok(new LanguageFile(cultureResult.Value, fileName, grawLanguageJsonFile.Value)) : Fail<LanguageFile>(NoEntriesInImportFile);
    }


    protected override bool EqualsCore(LanguageFile other) => FileName == other.FileName;
    protected override int GetHashCodeCore() => FileName.GetHashCode();
}