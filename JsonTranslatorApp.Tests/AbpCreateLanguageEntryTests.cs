using FluentAssertions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using static JsonTranslatorApp.Models.ValueObjects.LanguageEntry;
using static JsonTranslatorApp.Tests.TestConstants;


namespace JsonTranslatorApp.Tests;

public class AbpCreateLanguageEntryTests
{
    [Fact]
    public void CreateLanguageEntry_From_AbpLanguageFile_Should_Return_Correct_Number_Of_Entries()
    {
        var result =  CreateLanguageEntry("fr.json", FrAbpJson);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as AbpLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
}