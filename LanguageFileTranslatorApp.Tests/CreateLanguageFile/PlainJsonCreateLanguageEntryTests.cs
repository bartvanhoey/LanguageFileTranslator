using FluentAssertions;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;
using static LanguageFileTranslatorApp.Tests.TestConstants;

namespace LanguageFileTranslatorApp.Tests.CreateLanguageFile;

public class PlainJsonCreateLanguageFileTests
{
    
    [Fact]
    public void CreateLanguageFile_From_PlainJsonFile1_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageFile.CreateLanguageFile("en.json", EnPlainJson1);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.Model as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
    
    [Fact]
    public void CreateLanguageFile_From_PlainJsonFile2_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageFile.CreateLanguageFile("en.json", EnPlainJson2);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.Model as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(2);
    }
    
    [Fact]
    public void CreateLanguageFile_From_PlainJsonFile3_Should_Return_Correct_Number_Of_Entries()
    {
        var result = LanguageFile.CreateLanguageFile("en.json", EnPlainJson3);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.Model as PlainJsonLanguageFileModel;
        model?.Texts.Count.Should().Be(7);
    }
}