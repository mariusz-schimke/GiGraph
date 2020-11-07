using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Writers.Nodes
{
    public class DotNodeWriter : DotEntityWithAttributeListWriter, IDotNodeWriter
    {
        public DotNodeWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration)
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