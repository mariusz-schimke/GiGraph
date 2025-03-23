using System.Text.RegularExpressions;
using System.Web;
using GiGraph.Dot.Output.Metadata;
using HtmlAgilityPack;
using Xunit;
using Xunit.Abstractions;

namespace GiGraph.Dot.Entities.Tests.Attributes.GraphvizDocumentation;

/// <summary>
///     The assumption of this test is that the HTML documentation of Graphviz attributes is up-to-date and complete. The test does
///     not report any errors, but it prints the differences between the documentation and the metadata implementation.
/// </summary>
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
            .Where(item => !IsEqualCompatibilityList(item.HtmlTableRecord, item.MetadataRecord))
            .ToList();

        foreach (var compatibilityListDiffItem in compatibilityListDiff)
        {
            _testOutputHelper.WriteLine($"The attribute '{compatibilityListDiffItem.HtmlTableRecord.Key}' " +
                $"defines a different compatibility list ({compatibilityListDiffItem.HtmlTableRecord.CompatibleElements}) than the metadata implementation " +
                $"({compatibilityListDiffItem.MetadataRecord!.CompatibleElements}).");
        }
    }

    private static bool IsEqualCompatibilityList(AttributeRecord htmlTableRecord, DotAttributeMetadata? metadataRecord)
    {
        // overrides where the difference is intentional
        var metadataRecordCompatibleElements = metadataRecord switch
        {
            { Key: DotAttributeKeys.Color } r => r.CompatibleElements & ~DotCompatibleElements.Graph,
            { Key: DotAttributeKeys.FillColor } r => r.CompatibleElements & ~DotCompatibleElements.Graph,
            { Key: DotAttributeKeys.PenColor } r => r.CompatibleElements & ~DotCompatibleElements.Graph,
            { Key: DotAttributeKeys.PenWidth } r => r.CompatibleElements & ~DotCompatibleElements.Graph,
            { Key: DotAttributeKeys.Rank } r => r.CompatibleElements & ~DotCompatibleElements.Graph & ~DotCompatibleElements.Cluster,
            _ => metadataRecord?.CompatibleElements
        };

        return htmlTableRecord.CompatibleElements == metadataRecordCompatibleElements;
    }

    private static DotCompatibleElements ExtractCompatibleElements(HtmlNode cell)
    {
        return GetCellText(cell)
            .Split(',', StringSplitOptions.TrimEntries)
            .Select(element => element.TrimEnd('s'))
            .Select(element => Enum.Parse<DotCompatibleElements>(element, true))
            .Aggregate((x, y) => x | y);
    }

    private static string GetCellText(HtmlNode cell) => Regex.Replace(
        HttpUtility.HtmlDecode(cell.InnerText).ReplaceLineEndings(" ").Trim(),
        @"\s+",
        " "
    );

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