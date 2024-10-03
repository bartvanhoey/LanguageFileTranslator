using System.Text.Json;
using System.Text.Json.Serialization;
using JsonTranslatorApp.Infra.Extensions;

namespace JsonTranslatorApp.Models.JsonModels.AbpModel;

public class AbpLanguageFileModel : LanguageFileModelBase
{
    public string culture { get; set; }
    public Dictionary<string, string> texts { get; set; } = new();

}

public class LanguageFileModelBase
{
}

public class AbpRootModelFalse : LanguageFileModelBase
{
    public AbpRootModelFalse(string jam)
    {
        if (jam.IsNullOrWhiteSpace()) throw new ArgumentNullException();

        Jam = jam;
    }

    public string Jam { get; set; }
    public Dictionary<string, string> objects { get; set; } = new();

}

