using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;

namespace JsonTranslatorApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DeserializeTestDefault()
        {
            var json = @"{ ""value"": { ""content"": ""test"" } }";
            var r = JsonSerializer.Deserialize<TestDefault>(json);
            r.Should().NotBeNull();
        }
        
        [Fact]
        public void DeserializeAbpRootModel()
        {
            var abpRootModel = JsonSerializer.Deserialize<AbpRootModel>(_json);
            abpRootModel.Should().NotBeNull();
        }
        
        [Fact]
        public void DeserializeAbpRootModel1()
        {
            var abpRootModel = _json.ConvertTo<AbpRootModel>();
            abpRootModel.Should().NotBeNull();
        }

        
        
        private string _json =
            "{\n  \"culture\": \"fr\",\n  \"texts\": {\n    \"Menu:Home\": \"Accueil\",\n    \"Welcome\": \"Bienvenue\",\n    \"LongWelcomeMessage\": \"Bienvenue dans l\\u0027application. Il s\\u0027agit d\\u0027un projet de démarrage basé sur le framework ABP. Pour plus d\\u0027informations, visitez abp.io.\",\n    \"ShortWelcomeMessage\": \"Bienvenue dans l\\u0027application.\"\n  }\n}";

    }

    
    

    public class TestDefault
    {
        [JsonIgnore]
        public JsonElement Value => Values["value"];

        [JsonExtensionData]
        public Dictionary<string, JsonElement> Values { get; set; }
    }
    
    // public class AbpRootModel
    // {
    //     public string culture { get; set; }
    //
    //     public Dictionary<string, string> texts { get; set; }
    // }
}