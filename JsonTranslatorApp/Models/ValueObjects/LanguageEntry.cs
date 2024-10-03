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

    private LanguageEntry(InfoCulture culture, string fileFileName, List<LanguageEntryItem> languageEntryItems, LanguageFileModelBase languageFileModel)
    {
        LanguageEntryItems = languageEntryItems;
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        LanguageFileModel = languageFileModel;
    }
    
    private LanguageEntry(InfoCulture culture, string fileFileName, AbpLanguageFileResult abpLanguageFile )
    {
        LanguageEntryItems = abpLanguageFile.LanguageEntryItems;
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        LanguageFileModel = abpLanguageFile.AbpModel;
    }

    public InfoCulture Culture { get; }

    public string Extension { get; }
    public string FileName { get; }
    
    public List<LanguageEntryItem> LanguageEntryItems;

    private LanguageEntry(InfoCulture culture, string fileFileName, NamespacedJsonLanguageFileResult namespacedJsonFile)
    {
        LanguageEntryItems = namespacedJsonFile.LanguageEntryItems;
        Culture = culture;
        Extension = GetExtension(fileFileName);
        FileName = fileFileName; 
        LanguageFileModel = namespacedJsonFile.NamespacedJsonModel;
    }

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

        var abpLanguageFile = json.ConvertToAbpLanguageFileResult(cultureResult.Value);
        if (abpLanguageFile.IsSuccess) return Ok(new LanguageEntry(cultureResult.Value, fileName, abpLanguageFile.Value));
        
        var namespacedJsonFile =  json.ConvertToNamespacedJsonLanguageFileResult(cultureResult.Value);
        if (namespacedJsonFile.IsSuccess) return Ok(new LanguageEntry(cultureResult.Value, fileName, namespacedJsonFile.Value));
        
        
        
        // var abpModel = json?.ConvertTo<AbpLanguageFileModel>();
        // if (abpModel?.texts.Count > 0)
        // {
        //     var languageEntryItems = abpModel.texts
        //         .Select((x, i) => new LanguageEntryItem { Key = x.Key, Value = x.Value, Id = i }).ToList();
        //     
        // }
        
        
        

        return Fail<LanguageEntry>(NoEntriesInImportFile);
    }


    protected override bool EqualsCore(LanguageEntry other) => FileName == other.FileName;
    protected override int GetHashCodeCore() => FileName.GetHashCode();
}