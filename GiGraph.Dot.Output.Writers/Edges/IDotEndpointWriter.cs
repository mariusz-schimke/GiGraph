namespace GiGraph.Dot.Output.Writers.Edges
{
    public interface IDotEndpointWriter : IDotEntityWriter
    {
        void WriteEndpoint(string nodeId, bool quoteNodeId, string portName, bool quotePortName, string compassPoint, bool quoteCompassPoint);
    }
}