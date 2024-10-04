using System.Text.Json.Nodes;
using FluentAssertions;
using JsonTranslatorApp.Infra.Extensions;
using static System.Text.Json.Nodes.JsonNode;
using static JsonTranslatorApp.Tests.TestConstants;

namespace JsonTranslatorApp.Tests;

public class GetTranslationsFromJsonObjectTests
{
    [Fact]
    public void GetTranslationsFromJsonObject_From_StructuredJsonFile_Should_Return_Correct_Number_Of_Entries()
    {
        var rootNode = Parse(EnStructuredJson1);
        var firstNode = rootNode?[rootNode[0]?.GetPath().Replace("$.", "") ?? throw new InvalidOperationException()] as JsonObject;
        var translations = firstNode.GetTranslationsFromJsonObject(new Dictionary<string, string>());
        translations.Count.Should().Be(4);
    }
    
    
    [Fact]
    public void GetTranslationsFromJsonObject_From_PlainJsonFile_Should_Return_Correct_Number_Of_Entries()
    {
        var rootNode = Parse(EnPlainJson1) as JsonObject;
        var translations = rootNode.GetTranslationsFromJsonObject(new Dictionary<string, string>());
        translations.Count.Should().Be(4);

    }
}