using LanguageFileTranslatorApp.Infra.Extensions;

namespace LanguageFileTranslatorApp.Models.JsonModels.AbpModel;

public class AbpLanguageFileModel : LanguageFileModelBase
{
    public string culture { get; set; }
    public Dictionary<string, string> Texts { get; set; } = new();

}

public class StructuredJsonLanguageFileModel(Dictionary<string, string> texts) : LanguageFileModelBase
{
    public Dictionary<string, string> Texts { get; set; } = texts;
}

public class PlainJsonLanguageFileModel(Dictionary<string, string> texts) : LanguageFileModelBase
{
    public Dictionary<string, string> Texts { get; set; } = texts;
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

