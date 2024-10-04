using FluentAssertions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using static JsonTranslatorApp.Models.ValueObjects.LanguageEntry;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests;

public class PlainJsonCreateLanguageEntryTests
{
    
    [Fact]
    public void CreateLanguageEntry_From_PlainJsonFile1_Should_Return_Correct_Number_Of_Entries()
    {
        var result = CreateLanguageEntry("en.json", EnPlainJson1);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
    
    [Fact]
    public void CreateLanguageEntry_From_PlainJsonFile2_Should_Return_Correct_Number_Of_Entries()
    {
        var result = CreateLanguageEntry("en.json", EnPlainJson2);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(2);
    }
}