using GiGraph.Dot.Output.Writers.AttributeWriters;
using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.NodeWriters
{
    public class DotNodeWriter : DotEntityWithAttributeListWriter, IDotNodeWriter
    {
        public DotNodeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public override IDotAttributeListItemWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.ClearLingerBuffer()
               .Space(linger: true);

            return base.BeginAttributeList(useAttributeSeparator);
        }

        public virtual void WriteNodeIdentifier(string id, bool quote)
        {
            _tokenWriter.Identifier(id, quote)
                // these will be removed by a parent node statement writer or before writing attributes
               .NodeSeparator(linger: true)
               .Space(linger: true);
        }
    }
}