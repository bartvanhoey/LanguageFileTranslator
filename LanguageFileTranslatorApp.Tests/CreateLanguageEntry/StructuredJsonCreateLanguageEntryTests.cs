using FluentAssertions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests.CreateLanguageEntry;

public class StructuredJsonCreateLanguageEntryTests
{
    [Fact]
    public void CreateLanguageEntry_From_StructuredJsonFile1_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageEntry.CreateLanguageEntry("en.json", EnStructuredJson1);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
    
    [Fact]
    public void CreateLanguageEntry_From_StructuredJsonFile2_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageEntry.CreateLanguageEntry("en.json", EnStructuredJson2);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(1);
    }
    
    [Fact]
    public void CreateLanguageEntry_From_StructuredJsonFile3_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageEntry.CreateLanguageEntry("en.json", EnStructuredJson3);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
}