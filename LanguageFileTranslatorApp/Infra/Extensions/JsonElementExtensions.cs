using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonTranslatorApp.Infra.Extensions;

public static class JsonElementExtensions
{
    public static JsonElement? Get(this JsonElement element, string name) => 
        element.ValueKind != JsonValueKind.Null && element.ValueKind != JsonValueKind.Undefined && element.TryGetProperty(name, out var value) 
            ? value : (JsonElement?)null;
    
    public static JsonElement? Get(this JsonElement element, int index)
    {
        if (element.ValueKind == JsonValueKind.Null || element.ValueKind == JsonValueKind.Undefined)
            return null;
        // Throw if index < 0
        return index < element.GetArrayLength() ? element[index] : null;
    }

    public static Dictionary<string, string> GetTranslationsFromJsonObject(this JsonObject? jsonObject, Dictionary<string, string> translations)
    {
        if (jsonObject == null || jsonObject.Count == 0) return new Dictionary<string, string>();
        for (var i = 0; i < jsonObject.Count; i++)
        {
            if (jsonObject[i] is JsonObject)
            {
                var childJsonObject = jsonObject[i] as JsonObject;
                if (childJsonObject?.Count == 0) continue;
                foreach (var path in (childJsonObject?.GetTranslationsFromJsonObject(translations) ?? []).Where(x => !translations.Contains(x))) 
                    translations.Add(path.Key, path.Value);
            }
            else
            {
                if (jsonObject[i] is JsonValue)
                {
                    var key = (jsonObject[i]?.AsValue().GetPath() ?? throw new ArgumentException()).Replace("$.","");
                    var value = jsonObject[i]?.AsValue().GetValue<string>() ?? throw new InvalidOperationException();
                    if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value)) continue;
                    translations.TryAdd(key, value);    
                }
                else if(jsonObject[i] is JsonArray)
                {
                    var jsonArray = jsonObject[i] as JsonArray;
                    if (jsonArray == null) continue;
                    foreach (var arrayItem in jsonArray)
                    {
                        if (arrayItem == null) continue;
                        if (arrayItem is JsonObject childJsonObject)
                        {
                            if (childJsonObject?.Count == 0) continue;
                            foreach (var path in (childJsonObject?.GetTranslationsFromJsonObject(translations) ?? []).Where(x => !translations.Contains(x))) 
                                translations.Add(path.Key, path.Value);
                        }
                        else
                        {
                            var key = (arrayItem.AsValue().GetPath() ?? throw new ArgumentException()).Replace("$.","");
                            var value = arrayItem.AsValue().GetValue<string>() ?? throw new InvalidOperationException();
                            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value)) continue;
                            translations.TryAdd(key, value);    
                        }
                    }
                }
                
                
            }
        }
        return translations;
    }
    
    
    // public static List<string> GetPathsFromJsonObject(this JsonObject jsonObject, List<string> paths)
    // {
    //     for (var i = 0; i < jsonObject.Count; i++)
    //     {
    //         if (jsonObject[i] is JsonObject)
    //         {
    //             var childJsonObject = jsonObject[i] as JsonObject;
    //             if (childJsonObject?.Count == 0) continue;
    //             foreach (var path in (childJsonObject?.GetPathsFromJsonObject(paths) ?? []).Where(x => !paths.Contains(x))) 
    //                 paths.Add(path);
    //         }
    //         else
    //         {
    //             var path = (jsonObject[i]?.AsValue().GetPath() ?? throw new InvalidOperationException()).Replace("$.","");
    //             if (!paths.Contains(path)) paths.Add(path);
    //         }
    //     }
    //     return paths;
    // }
    
    
    
    
}