using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.EdgeWriters
{
    public class DotEndpointWriter : DotEntityWriter, IDotEndpointWriter
    {
        public DotEndpointWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
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

        public override IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, _context.Level, preferBlockComment: true);
        }

        public override void EndComment()
        {
            _tokenWriter.Space();
        }
    }
}