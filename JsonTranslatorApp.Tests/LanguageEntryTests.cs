using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using FluentAssertions;
using JsonTranslatorApp.Infra.Extensions;
using JsonTranslatorApp.Models.JsonModels.AbpModel;
using JsonTranslatorApp.Models.ValueObjects;
using static JsonTranslatorApp.Models.ValueObjects.LanguageEntry;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests;

public class LanguageEntryTests
{
    [Fact]
    public void Create_LanguageEntry_From_AbpLanguageFile_Should_Return_Correct_Number_Of_Entries()
    {
        var bytes = Encoding.ASCII.GetBytes(FrAbpJson);
        var result = CreateLanguageEntry("fr.json", bytes);
        result.IsSuccess.Should().BeTrue();
        var abpLanguageFile = result.Value.LanguageFileModel as AbpLanguageFileModel;
        abpLanguageFile?.texts.Count.Should().Be(4);
    }

    [Fact]
    public void Create_LanguageEntry_From_NamespacedJsonFile_Should_Return_Correct_Number_Of_Entries()
    {
        
        var rootNode = JsonNode.Parse(EnNamespacedJson);
        var firstNode = rootNode?[rootNode[0]?.GetPath().Replace("$.", "") ?? throw new InvalidOperationException()] as JsonObject;
        var translations = firstNode.GetTranslationsFromJsonObject(new Dictionary<string, string>());
        translations.Count.Should().Be(4);

        var result = CreateLanguageEntry("en.json", Encoding.ASCII.GetBytes(EnNamespacedJson));
        result.IsSuccess.Should().BeTrue();
        var namespacedJsonFile = result.Value.LanguageFileModel as NamespacedJsonLanguageFileModel;
        namespacedJsonFile?.Texts.Count.Should().Be(4);
    }
}