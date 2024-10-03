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
            var abpRootModel = JsonSerializer.Deserialize<AbpLanguageFileModel>(TestConstants.FrJson);
            abpRootModel.Should().NotBeNull();
        }
        
        [Fact]
        public void DeserializeAbpRootModel1()
        {
            var abpRootModel = TestConstants.FrJson.ConvertTo<AbpLanguageFileModel>();
            abpRootModel.Should().NotBeNull();
        }


        
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