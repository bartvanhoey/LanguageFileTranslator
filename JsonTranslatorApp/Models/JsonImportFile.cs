using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Infra.Funcky.ResultClass;
using JsonTranslatorApp.Infra.Funcky.ValueObjectClass;
using static System.IO.Path;
using static System.StringSplitOptions;
using static JsonTranslatorApp.Infra.Funcky.ResultClass.Result;
using static JsonTranslatorApp.Infra.Funcky.ResultErrors.ErrorFactory;

namespace JsonTranslatorApp.Models;

public class JsonImportFile : ValueObject<JsonImportFile>
{
    private static readonly string[] AllowedFileExtensions = [".json"];
    private static readonly string[] Separator = ["-"];

    private JsonImportFile(string extension, string culture, string fileName, byte[] content)
    {
        Culture = culture;
        Extension = extension;
        Name = fileName;
        Content = content;
    }

    public string? Culture { get; }

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

        var culture = fileName.Split(Separator, None)[1].Split('.')[0].Trim();
        if (culture.IsNullOrWhiteSpace()) return Fail<JsonImportFile>(CultureIsNullOrWhiteSpace);

        return culture.Length >= 2
            ? Ok(new JsonImportFile( extension, culture, fileName, fileContent))
            : Fail<JsonImportFile>(CultureShouldBeAtLeastTwoCharacters);
    }

    protected override bool EqualsCore(JsonImportFile other) => Name == other.Name;
    protected override int GetHashCodeCore() => Name.GetHashCode();
}