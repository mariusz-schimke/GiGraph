using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Examples.Basic
{
    public static class LabelJustification
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph();

            // node label with the ID of the node
            graph.Nodes.Add("Foo", attrs =>
            {
                attrs.Shape = DotNodeShape.Box;
                attrs.Width = 3;

                attrs.Label = new DotEscapeStringBuilder()
                             .AppendLine("Centered line")
                             .AppendLeftJustifiedLine("Left-justified line")
                             .AppendRightJustifiedLine("Right-justified line")
                             .ToEscapeString();

                // or an alternative way
                attrs.Label = "Centered line" + DotEscapeString.NewLine +
                              "Left-justified line" + DotEscapeString.JustifyLeft +
                              "Right-justified line" + DotEscapeString.JustifyRight;
            });

            return graph;
        }
    }
}