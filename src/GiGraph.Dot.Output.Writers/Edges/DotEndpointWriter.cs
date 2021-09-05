using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEndpointWriter : DotEntityWriter, IDotEndpointWriter
    {
        public DotEndpointWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
        }

        public virtual void WriteEndpoint(string id, bool quoteId, string portName, bool quotePortName, string compassPoint, bool quoteCompassPoint)
        {
            _tokenWriter.Identifier(id, quoteId);

            if (portName is not null)
            {
                _tokenWriter.NodePortSeparator()
                   .Identifier(portName, quotePortName);
            }

            if (compassPoint is not null)
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