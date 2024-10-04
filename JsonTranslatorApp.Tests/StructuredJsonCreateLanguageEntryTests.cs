using FluentAssertions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using static JsonTranslatorApp.Models.ValueObjects.LanguageEntry;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests;

public class StructuredJsonCreateLanguageEntryTests
{
    [Fact]
    public void CreateLanguageEntry_From_StructuredJsonFile1_Should_Return_Correct_Number_Of_Entries()
    {
        var result = CreateLanguageEntry("en.json", EnStructuredJson1);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
    
    [Fact]
    public void CreateLanguageEntry_From_StructuredJsonFile2_Should_Return_Correct_Number_Of_Entries()
    {
        var result = CreateLanguageEntry("en.json", EnStructuredJson2);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(1);
    }
}