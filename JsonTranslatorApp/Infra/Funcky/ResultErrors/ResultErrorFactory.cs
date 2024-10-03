using JsonTranslatorApp.Infra.Funcky.ResultErrors.Errors;

namespace JsonTranslatorApp.Infra.Funcky.ResultErrors;

public static class ResultErrorFactory
{
    public static NameIsEmptyResultError NameIsEmpty => new();
    public static ContentIsEmptyResultError ContentIsEmpty => new();
    public static CultureIsNullResultError CultureIsNull => new();
    public static CulturesCountIsZeroResultError CulturesCountIsZero => new();
    public static ExtensionIsEmptyResultError ExtensionIsEmpty => new();
    public static GetInfoCultureResultError GetInfoCulture(Exception exception) => new(exception);
    public static CouldNotParseJsonDocumentResultError CouldNotParseJsonDocument(Exception exception) => new(exception);
    public static JsonDocumentIsNullOrEmptyResultError JsonDocumentIsNullOrEmpty() => new();
    public static CultureCodeIsNullOrWhiteSpaceResultError CultureIsNullOrWhiteSpace => new();
    public static CultureShouldBeAtLeastTwoCharactersResultError CultureShouldBeAtLeastTwoCharacters => new();
    public static ExtensionIsNotAllowedResultError ExtensionIsNotAllowed => new();
    public static NoEntriesInImportFileResultError NoEntriesInImportFile => new();
}

public class GetInfoCultureResultError(Exception exception)
    : BaseResultError($"{exception.GetType()}: {exception.Message}");

public class JsonDocumentIsNullOrEmptyResultError() : BaseResultError;

public class CouldNotParseJsonDocumentResultError(Exception exception)
    : BaseResultError($"{exception.GetType()}: {exception.Message}");

public class ContentIsEmptyResultError : BaseResultError;

public class CultureIsNullResultError : BaseResultError;

public class CulturesCountIsZeroResultError : BaseResultError;

public class ExtensionIsEmptyResultError : BaseResultError;

public class CultureCodeIsNullOrWhiteSpaceResultError : BaseResultError;

public class CultureShouldBeAtLeastTwoCharactersResultError : BaseResultError;

public class ExtensionIsNotAllowedResultError : BaseResultError;

public class NoEntriesInImportFileResultError : BaseResultError;