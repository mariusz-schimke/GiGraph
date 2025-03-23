using System.Text.RegularExpressions;
using System.Web;
using GiGraph.Dot.Output.Metadata;
using HtmlAgilityPack;
using Xunit;
using Xunit.Abstractions;

namespace GiGraph.Dot.Entities.Tests.Attributes.GraphvizDocumentation;

public class GraphvizAttributeListTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public GraphvizAttributeListTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void print_attribute_diff_based_on_html_documentation()
    {
        // the file was acquired from https://www.graphviz.org/doc/info/attrs.html (the HTML table was extracted to the file read by this test)
        var filePath = Path.Join("Attributes", "GraphvizDocumentation", "Graphviz.html");
        var html = File.ReadAllText(filePath);

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var rows = doc.DocumentNode.SelectNodes("//table//tr[position() > 1]"); // pomijamy nagłówek
        var records = rows.Select(row => row.SelectNodes("td"))
            .Select(cells => new AttributeRecord
            {
                Key = GetCellText(cells[0]),
                CompatibleElements = GetCellText(cells[1]),
                Type = GetCellText(cells[2]),
                DefaultValue = GetCellText(cells[3]),
                MinValue = GetCellText(cells[4]),
                Description = GetCellText(cells[5])
            })
            .ToDictionary(record => record.Key);

        PrintRemovedAttributes(records);
        PrintNewlyAddedAttributes(records);
    }

    private void PrintRemovedAttributes(Dictionary<string, AttributeRecord> records)
    {
        var removedAttributes = DotAttributeKeys.MetadataDictionary
            .Select(item => item.Key)
            .Where(key => !records.ContainsKey(key))
            .ToArray();

        foreach (var removedAttribute in removedAttributes)
        {
            _testOutputHelper.WriteLine($"Attribute removed from the documentation: {removedAttribute}");
        }
    }

    private void PrintNewlyAddedAttributes(Dictionary<string, AttributeRecord> records)
    {
        var newAttributes = records
            .Select(item => item.Key)
            .Where(key => !DotAttributeKeys.MetadataDictionary.ContainsKey(key))
            .ToList();

        foreach (var newAttribute in newAttributes)
        {
            _testOutputHelper.WriteLine($"A new attribute was added to the documentation: {newAttribute}");
        }
    }

    private static string GetCellText(HtmlNode cell) => Regex.Replace(
        HttpUtility.HtmlDecode(cell.InnerText).ReplaceLineEndings(" ").Trim(),
        @"\s+",
        " "
    );

    private class AttributeRecord
    {
        public required string Key { get; init; }
        public required string CompatibleElements { get; init; }
        public required string Type { get; init; }
        public required string DefaultValue { get; init; }
        public required string MinValue { get; init; }
        public required string Description { get; init; }
    }
}