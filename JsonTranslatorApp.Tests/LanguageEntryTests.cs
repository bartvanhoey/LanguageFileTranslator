using System.Text;
using FluentAssertions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using static JsonTranslatorApp.Models.ValueObjects.LanguageEntry;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests;

public class LanguageEntryTests
{
        
    [Fact]
    public void DeserializeAbpRootModel1()
    {
        var bytes = Encoding.ASCII.GetBytes(FrJson);
        var result = CreateLanguageEntry("fr.json", bytes);

        var abpLanguageFile = result.Value.LanguageFileModel as AbpLanguageFileModel;
        abpLanguageFile?.texts.Count.Should().Be(4);


        result.IsSuccess.Should().BeTrue();


        
    }
}