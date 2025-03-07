﻿using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Examples.Html;

public static class HtmlColoredTextNodeFromBuilder
{
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("Bar").SetAsHtml(builder => builder.AppendText(DotEscapeString.NodeIdPlaceholder, new DotFont(Color.Red)));

        return graph;
    }
}