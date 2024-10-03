using System.Text;
using FluentAssertions;
using JsonTranslatorApp.Models.ValueObjects;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests;

public class LanguageEntryTests
{
        
    [Fact]
    public void DeserializeAbpRootModel1()
    {
        var bytes = Encoding.ASCII.GetBytes(FrJson);
        var jsonImportFile = LanguageEntry.CreateLanguageEntry("fr.json", bytes);

        jsonImportFile.IsSuccess.Should().BeTrue();


        
    }
}