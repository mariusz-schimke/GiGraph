using GiGraph.Dot.Output.Writers.AttributeWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public abstract class DotEntityWithAttributeListWriter : DotEntityWriter, IDotEntityWithAttributeListWriter
    {
        protected DotEntityWithAttributeListWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, enforceBlockComment: false)
        {
        }

        public virtual IDotAttributeListItemWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.AttributeListStart(linger: true)
                        .Space(linger: true);

            return new DotAttributeListItemWriter(_tokenWriter.NextIndentationLevel(), _context, useAttributeSeparator);
        }

        public virtual void EndAttributeList()
        {
            _tokenWriter.ClearLingerBuffer()
                        .Space()
                        .AttributeListEnd();
        }
    }
}