namespace JsonTranslatorApp.Tests;

public static class TestConstants
{
    public const string FrAbpJson = "{\n  \"culture\": \"fr\",\n  \"texts\": {\n    \"Menu:Home\": \"Accueil\",\n    \"Welcome\": \"Bienvenue\",\n    \"LongWelcomeMessage\": \"Bienvenue dans l\\u0027application. Il s\\u0027agit d\\u0027un projet de démarrage basé sur le framework ABP. Pour plus d\\u0027informations, visitez abp.io.\",\n    \"ShortWelcomeMessage\": \"Bienvenue dans l\\u0027application.\"\n  }\n}";
    
    public const string EnStructuredJson1 = "{\n    \"main\": {\n        \"sidebar\": {\n            \"project\": \"Project\",\n            \"title\": \"Name of the project.\"\n        },\n        \"statusbar\": {\n            \"statusbar_empty\": \"Empty! No entries added yet.\",\n            \"statusbar_ok\": \"Ok.\"\n        }\n    }\n}";
    public const string EnStructuredJson2 = "{\n  \"parent\": {\n    \"child\": {\n      \"another_nested_level\": \"All is supported.\"\n    }\n  }\n}";
    public const string EnStructuredJson3 = "{\n  \"string1\": {\n    \"example\": [\n      {\n        \"title\": \"This is a test!\",\n        \"text\": \"This is some text.\"\n      },\n      {\n        \"title\": \"This is a test.\",\n        \"text\": \"This is some text.\"\n      }\n    ]\n  }\n}";
    
    public const string EnPlainJson1 = "{\n    \"main.sidebar.project\": \"Project\",\n    \"main.sidebar.title\": \"Name of the project.\",\n    \"main.statusbar.status_empty\": \"Empty! No entries added yet.\",\n    \"main.statusbar.status_ok\": \"Ok.\"\n}";
    public const string EnPlainJson2 = "{\n  \"key1\": \"Text 1\",\n  \"key2\": \"Text 2\"\n}";
    public const string EnPlainJson3 = "{\n  \"error\": \"A problem occurred.\",\n  \"hello\": \"Hi\",\n  \"greetings\": \"Hello there\",\n  \"timeago\": {\n    \"x_days\": {\n      \"one\": \"1 day ago\",\n      \"other\": \" days ago\"\n    },\n    \"x_seconds\": {\n      \"one\": \"1 second ago\",\n      \"other\": \" seconds ago\"\n    }\n  }\n}";
}