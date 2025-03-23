using System.Text.RegularExpressions;
using System.Web;
using GiGraph.Dot.Output.Metadata;
using HtmlAgilityPack;
using Xunit;
using Xunit.Abstractions;

namespace GiGraph.Dot.Entities.Tests.Attributes.GraphvizDocumentation;

public class GraphvizAttributeListDiffTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public GraphvizAttributeListDiffTest(ITestOutputHelper testOutputHelper)
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

        // skip the first row (header)
        var rows = doc.DocumentNode.SelectNodes("//table//tr[position() > 1]");

        var records = rows
            .Select(row => row.SelectNodes("td"))
            .Select(cells => new AttributeRecord
            {
                Key = GetCellText(cells[0]),
                CompatibleElements = ExtractCompatibleElements(cells[1]),
                Type = GetCellText(cells[2]),
                DefaultValue = GetCellText(cells[3]),
                MinValue = GetCellText(cells[4]),
                Description = GetCellText(cells[5])
            })
            .ToDictionary(record => record.Key);

        PrintRemovedAttributes(records);
        PrintNewlyAddedAttributes(records);
        PrintElementCompatibilityDiff(records);
    }

    private void PrintRemovedAttributes(Dictionary<string, AttributeRecord> records)
    {
        var removedAttributes = DotAttributeKeys.MetadataDictionary
            .Select(item => item.Key)
            .Where(key => !records.ContainsKey(key))
            .ToArray();

        foreach (var removedAttribute in removedAttributes)
        {
            _testOutputHelper.WriteLine($"The attribute '{removedAttribute}' was removed from the documentation.");
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
            _testOutputHelper.WriteLine($"A new attribute '{newAttribute}' was added to the documentation.");
        }
    }

    private void PrintElementCompatibilityDiff(Dictionary<string, AttributeRecord> records)
    {
        var compatibilityListDiff = records
            .Select(item => new
            {
                HtmlTableRecord = item.Value,
                MetadataRecord = DotAttributeKeys.MetadataDictionary.GetValueOrDefault(item.Key)
            })
            .Where(item => item.MetadataRecord is not null)
            .Where(item => item.HtmlTableRecord.CompatibleElements != item.MetadataRecord!.CompatibleElements)
            .ToList();

        foreach (var compatibilityListDiffItem in compatibilityListDiff)
        {
            _testOutputHelper.WriteLine($"The attribute '{compatibilityListDiffItem.HtmlTableRecord.Key}' " +
                $"defines a different compatibility list ({compatibilityListDiffItem.HtmlTableRecord.CompatibleElements}) than the metadata implementation " +
                $"({compatibilityListDiffItem.MetadataRecord!.CompatibleElements}).");
        }
    }

    private static string GetCellText(HtmlNode cell) => Regex.Replace(
        HttpUtility.HtmlDecode(cell.InnerText).ReplaceLineEndings(" ").Trim(),
        @"\s+",
        " "
    );

    private static DotCompatibleElements ExtractCompatibleElements(HtmlNode cell)
    {
        return GetCellText(cell)
            .Split(',', StringSplitOptions.TrimEntries)
            .Select(element => element.TrimEnd('s'))
            .Select(element => Enum.Parse<DotCompatibleElements>(element, true))
            .Aggregate((x, y) => x | y);
    }

    private class AttributeRecord
    {
        public required string Key { get; init; }
        public required DotCompatibleElements CompatibleElements { get; init; }
        public required string Type { get; init; }
        public required string DefaultValue { get; init; }
        public required string MinValue { get; init; }
        public required string Description { get; init; }
    }
}