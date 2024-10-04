using LanguageFileTranslatorApp.Infra.Extensions;
using LanguageFileTranslatorApp.Infra.Funcky.ResultClass;
using LanguageFileTranslatorApp.Infra.Funcky.ResultErrors;
using static System.StringComparison;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultClass.Result;
using static LanguageFileTranslatorApp.Infra.Funcky.ResultErrors.ResultErrorFactory;

namespace LanguageFileTranslatorApp.Models.Cultures;

public static class InfoCultureHelper
{
    private static List<string> GetInfoCultureNames()
        => InfoCultures.GetInfoCultures().Select(x => x.Name).Where(x => x.Length > 0).ToList();

    public static int GetMaxLength()
        => InfoCultures.GetInfoCultures().Select(x => x.Name.Length).Max();

    public static Result<InfoCulture> GetInfoCulture(string fileName, string extension)
    {
        InfoCulture? infoCulture = null;
        try
        {
            var fileNamePart = fileName.GetLastCharacters(extension).Replace(extension, "");
            var infoCultureNames = GetInfoCultureNames();
            var cultures = new List<string>();
            foreach (var cultureName in infoCultureNames)
            {
                if (!fileNamePart.EndsWith(cultureName, InvariantCultureIgnoreCase)) continue;
                var twoLetterCultureExist = cultures.FirstOrDefault(x => x.Length == 2);
                if (twoLetterCultureExist != null) cultures.Remove(twoLetterCultureExist);
                cultures.Add(cultureName);
            }

            if (cultures.Count==0) return Fail<InfoCulture>(CulturesCountIsZero);
            infoCulture = InfoCultures.GetInfoCultures().FirstOrDefault(x => x.Name == cultures.FirstOrDefault());
        }
        catch (Exception exception)
        {
            Fail<InfoCulture>(ResultErrorFactory.GetInfoCulture(exception));
        }

        return infoCulture != null ? Ok(infoCulture) : Fail<InfoCulture>(CultureIsNull);
    }
}