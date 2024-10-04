using FluentAssertions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;
using static JsonTranslatorApp.Tests.TestConstants;


namespace JsonTranslatorApp.Tests.CreateLanguageEntry;

public class AbpJsonCreateLanguageEntryTests
{
    [Fact]
    public void CreateLanguageEntry_From_AbpLanguageFile_Should_Return_Correct_Number_Of_Entries()
    {
        var result =  LanguageEntry.CreateLanguageEntry("fr.json", FrAbpJson);
        result.IsSuccess.Should().BeTrue();
        
        var model = result.Value.LanguageFileModel as AbpLanguageFileModel;
        model?.Texts.Count.Should().Be(4);
    }
}