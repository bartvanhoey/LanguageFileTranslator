using FluentAssertions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests.CreateLanguageEntry;

public class PlainJsonCreateLanguageEntryTests
{
    
    [Fact]
    public void CreateLanguageEntry_From_PlainJsonFile1_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageEntry.CreateLanguageEntry("en.json", EnPlainJson1);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
    
    [Fact]
    public void CreateLanguageEntry_From_PlainJsonFile2_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageEntry.CreateLanguageEntry("en.json", EnPlainJson2);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(2);
    }
    
    [Fact]
    public void CreateLanguageEntry_From_PlainJsonFile3_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageEntry.CreateLanguageEntry("en.json", EnPlainJson3);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(7);
    }
}