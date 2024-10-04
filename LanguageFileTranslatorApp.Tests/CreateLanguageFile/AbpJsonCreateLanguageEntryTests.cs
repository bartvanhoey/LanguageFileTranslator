using FluentAssertions;
using LanguageFileTranslatorApp.Models.JsonModels.AbpModel;
using LanguageFileTranslatorApp.Models.ValueObjects;
using static LanguageFileTranslatorApp.Tests.TestConstants;


namespace LanguageFileTranslatorApp.Tests.CreateLanguageFile;

public class AbpJsonCreateLanguageFileTests
{
    [Fact]
    public void CreateLanguageFile_From_AbpLanguageFile_Should_Return_Correct_Number_Of_Entries()
    {
        var result =  LanguageFile.CreateLanguageFile("fr.json", FrAbpJson);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.Model as AbpLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
}