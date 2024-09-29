using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonTranslatorApp.Models.JsonModels.AbpModel;

public class AbpRootModel
{
    public string culture { get; set; }
    public Dictionary<string, string> texts { get; set; } = new Dictionary<string, string>();

}


