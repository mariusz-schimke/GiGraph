namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEndpointWriter : DotEntityWriter, IDotEndpointWriter
    {
        public DotEndpointWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
        }

        public virtual void WriteEndpoint(string nodeId, bool quoteNodeId, string portName, bool quotePortName, string compassPoint, bool quoteCompassPoint)
        {
            _tokenWriter.Identifier(nodeId, quoteNodeId);

            if (portName is { })
            {
                _tokenWriter.NodePortDelimiter()
                   .Identifier(portName, quotePortName);
            }

            if (compassPoint is { })
            {
                _tokenWriter.NodePortDelimiter()
                   .Identifier(compassPoint, quoteCompassPoint);
            }
        }

        public override void EndComment()
        {
            _tokenWriter.Space();
        }
    }
}