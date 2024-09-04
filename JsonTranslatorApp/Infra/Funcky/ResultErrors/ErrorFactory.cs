using JsonTranslatorApp.Infra.Funcky.ResultErrors.Errors;

namespace JsonTranslatorApp.Infra.Funcky.ResultErrors;

public static class ErrorFactory
{
    public static NameIsEmptyResultError NameIsEmpty => new();
    public static ContentIsEmptyResultError ContentIsEmpty => new();
    public static ExtensionIsEmptyResultError ExtensionIsEmpty => new();
    public static CultureCodeIsNullOrWhiteSpaceResultError CultureIsNullOrWhiteSpace => new();
    public static CultureShouldBeAtLeastTwoCharactersResultError CultureShouldBeAtLeastTwoCharacters => new();
    public static ExtensionIsNotAllowedResultError ExtensionIsNotAllowed => new();
}

public class ContentIsEmptyResultError : BaseResultError;

public class ExtensionIsEmptyResultError : BaseResultError;

public class CultureCodeIsNullOrWhiteSpaceResultError : BaseResultError;

public class CultureShouldBeAtLeastTwoCharactersResultError : BaseResultError;

public class ExtensionIsNotAllowedResultError : BaseResultError;


