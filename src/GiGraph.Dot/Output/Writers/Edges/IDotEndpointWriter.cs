namespace GiGraph.Dot.Output.Writers.Edges;

public interface IDotEndpointWriter : IDotEntityWriter
{
    void WriteEndpoint(string id, bool quoteId, string? portName, bool quotePortName, string? compassPoint, bool quoteCompassPoint);
}