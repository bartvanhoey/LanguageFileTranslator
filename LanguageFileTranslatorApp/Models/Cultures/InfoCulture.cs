namespace JsonTranslatorApp.Models.Cultures;

public class InfoCulture(
    string englishName,
    string displayName,
    string twoLetterIso,
    string threeLetterIso,
    string nativeName,
    string name)
{
    public string EnglishName { get; set; } = englishName;
    public string DisplayName { get; set; } = displayName;
    public string TwoLetterIso { get; set; } = twoLetterIso;
    public string ThreeLetterIso { get; set; } = threeLetterIso;
    public string NativeName { get; set; } = nativeName;
    public string Name { get; set; } = name;
}