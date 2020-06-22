using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.EdgeWriters
{
    public interface IDotEndpointWriter : IDotEntityWriter
    {
        void WriteEndpoint(string nodeId, bool quoteNodeId, string portName, bool quotePortName, string compassPoint, bool quoteCompassPoint);
    }
}