using GiGraph.Dot.Writers.AttributeWriters;
using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.NodeWriters
{
    public class DotNodeWriter : DotEntityWithAttributeListWriter, IDotNodeWriter
    {
        public DotNodeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteNodeIdentifier(string id, bool quote)
        {
            _tokenWriter.Identifier(id, quote)
                        // will be removed by a parent node statement writer or before writing attributes
                        .NodeSeparator(linger: true)
                        .Space(linger: true);
        }

        public override IDotAttributeStatementWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.ClearLingerBuffer()
                        .Space(linger: true);

            return base.BeginAttributeList(useAttributeSeparator);
        }
    }
}
