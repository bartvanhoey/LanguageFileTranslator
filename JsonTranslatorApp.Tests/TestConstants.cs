namespace JsonTranslatorApp.Tests;

public static class TestConstants
{
    public const string FrAbpJson = "{\n  \"culture\": \"fr\",\n  \"texts\": {\n    \"Menu:Home\": \"Accueil\",\n    \"Welcome\": \"Bienvenue\",\n    \"LongWelcomeMessage\": \"Bienvenue dans l\\u0027application. Il s\\u0027agit d\\u0027un projet de démarrage basé sur le framework ABP. Pour plus d\\u0027informations, visitez abp.io.\",\n    \"ShortWelcomeMessage\": \"Bienvenue dans l\\u0027application.\"\n  }\n}";
    public const string EnNamespacedJson = "{\n    \"main\": {\n        \"sidebar\": {\n            \"project\": \"Project\",\n            \"title\": \"Name of the project.\"\n        },\n        \"statusbar\": {\n            \"statusbar_empty\": \"Empty! No entries added yet.\",\n            \"statusbar_ok\": \"Ok.\"\n        }\n    }\n}";
}