using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Text.Escaping.Pipelines;
using GiGraph.Dot.Types.EscapeString;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Types.Tests.EscapeString;

public class DotFormattedTextBuilderTest
{
    [Fact]
    public void formatted_text_builder_generates_a_valid_result()
    {
        var builder = new DotFormattedTextBuilder("initial")
           .Append("1")
           .AppendLine()
           .AppendLine("2")
           .AppendLeftJustifiedLine("left")
           .AppendRightJustifiedLine("right")
           .Append("left")
           .AppendLeftJustificationLineBreak()
           .Append("right")
           .AppendRightJustificationLineBreak()
           .AppendGraphIdPlaceholder().AppendLine()
           .AppendLabelPlaceholder().AppendLine()
           .AppendNodeIdPlaceholder().AppendLine()
           .AppendEdgeDefinitionPlaceholder().AppendLine()
           .AppendTailNodeIdPlaceholder().AppendLine()
           .AppendHeadNodeIdPlaceholder();

        var dotEncoded = ((IDotEscapable) builder.Build()).GetEscaped(DotTextEscapingPipeline.ForEscapeString());
        Snapshot.Match(dotEncoded, "formatted_text_builder_build_output");
        Snapshot.Match(builder.ToString(), "formatted_text_builder_tostring_output");
    }
}