using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Examples.Html;

public static class HtmlTableStringNode
{
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("Bar").ToPlainHtmlNode
        (
            """
            <table border="0" cellborder="1" cellspacing="0" cellpadding="4">
                <tr>
                    <td rowspan="3">Foo<br/>Bar</td>
                    <td colspan="3" align="left">Baz</td>
                    <td rowspan="3">Qux</td>
                    <td rowspan="3">Quux</td>
                </tr>
                <tr>
                    <td>Garply</td>
                    <td>Waldo</td>
                    <td port="port1"><font color="royalblue"><b><i>Fred</i></b></font></td>
                </tr>
                <tr>
                    <td colspan="3" align="right">Plugh</td>
                </tr>
            </table>
            """
        );

        // sets an attribute of the edge (can be set globally)
        graph.Edges.Add("Foo", "Bar").Head.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

        // an equivalent method of defining a port (directly on the endpoint; cannot be set globally)
        graph.Edges.Add("Foo", "Bar").Head.Endpoint.Port = new DotEndpointPort("port1", DotCompassPoint.NorthEast);

        return graph;
    }
}