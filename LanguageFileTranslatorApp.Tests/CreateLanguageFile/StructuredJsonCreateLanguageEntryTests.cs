using FluentAssertions;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;
using static LanguageFileTranslatorApp.Tests.TestConstants;

namespace LanguageFileTranslatorApp.Tests.CreateLanguageFile;

public class StructuredJsonCreateLanguageFileTests
{
    [Fact]
    public void CreateLanguageFile_From_StructuredJsonFile1_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageFile.CreateLanguageFile("en.json", EnStructuredJson1);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.Model as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
    
    [Fact]
    public void CreateLanguageFile_From_StructuredJsonFile2_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageFile.CreateLanguageFile("en.json", EnStructuredJson2);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.Model as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(1);
    }
    
    [Fact]
    public void CreateLanguageFile_From_StructuredJsonFile3_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageFile.CreateLanguageFile("en.json", EnStructuredJson3);
        
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.Model as StructuredJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
}