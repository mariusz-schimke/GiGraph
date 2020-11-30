namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEndpointWriter : DotEntityWriter, IDotEndpointWriter
    {
        public DotEndpointWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
        }

        public virtual void WriteEndpoint(string nodeId, bool quoteNodeId, string portName, bool quotePortName, string compassPoint, bool quoteCompassPoint)
        {
            _tokenWriter.Identifier(nodeId, quoteNodeId);

            if (portName is { })
            {
                _tokenWriter.NodePortSeparator()
                   .Identifier(portName, quotePortName);
            }

            if (compassPoint is { })
            {
                _tokenWriter.NodePortSeparator()
                   .Identifier(compassPoint, quoteCompassPoint);
            }
        }

        public override void EndComment()
        {
            _tokenWriter.Space();
        }
    }
}