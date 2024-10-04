using static System.Text.Encoding;
using static System.Text.Json.JsonSerializer;


namespace LanguageFileTranslatorApp.Infra.Extensions;

public static class ByteArrayExtensions
{
    public static string? GetJsonString(this byte[] bytes) => bytes.Length <= 2 ? default : UTF8.GetString(bytes);

    public static T? ConvertTo<T>(this byte[] bytes)
    {
        var json = bytes.GetJsonString();
        return json == null || json.IsNullOrWhiteSpace() ? default : Deserialize<T>(json);
    }
}