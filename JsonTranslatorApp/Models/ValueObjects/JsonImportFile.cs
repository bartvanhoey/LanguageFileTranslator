using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
using JsonTranslatorApp.Infra.Funcky.ValueObjectClass;
using JsonTranslatorApp.Models.Cultures;
using static System.IO.Path;
using static System.StringSplitOptions;
using static JsonTranslatorApp.Infra.Funcky.ResultClass.Result;
using static JsonTranslatorApp.Infra.Funcky.ResultErrors.ErrorFactory;

namespace JsonTranslatorApp.Models.ValueObjects;

public class JsonImportFile : ValueObject<JsonImportFile>
{
    private static readonly string[] AllowedFileExtensions = [".json"];
    private static readonly string[] Separator = ["-"];

    private JsonImportFile(string extension, InfoCulture culture, string fileName, byte[] content)
    {
        Culture = culture;
        Extension = extension;
        Name = fileName;
        Content = content;
    }

    public InfoCulture Culture { get; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Extension { get; }
    public string Name { get; }
    public byte[] Content { get; }

    public static Result<JsonImportFile> CreateJsonImportFile(string? fileName, byte[]? fileContent)
    {
        if (fileName == null || fileName.IsNullOrWhiteSpace()) return Fail<JsonImportFile>(NameIsEmpty);
        fileName = fileName.Trim();

        if (fileContent is not { Length: > 2 }) return Fail<JsonImportFile>(ContentIsEmpty);

        var extension = GetExtension(fileName);
        if (extension.IsNullOrWhiteSpace()) return Fail<JsonImportFile>(ExtensionIsEmpty);
        if (!AllowedFileExtensions.Contains(extension)) return Fail<JsonImportFile>(ExtensionIsNotAllowed);

        var cultureResult = InfoCultureHelper.GetInfoCulture(fileName,extension);

        return cultureResult.IsFailure ? Fail<JsonImportFile>(cultureResult.Error) :
            Ok(new JsonImportFile(extension, cultureResult.Value, fileName, fileContent));
    }

    protected override bool EqualsCore(JsonImportFile other) => Name == other.Name;
    protected override int GetHashCodeCore() => Name.GetHashCode();
}