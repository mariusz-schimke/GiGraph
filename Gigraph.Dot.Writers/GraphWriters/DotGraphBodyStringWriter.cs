using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.Contexts;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public class DotGraphBodyStringWriter : DotEntityStringWriter, IDotGraphBodyWriter
    {
        public DotGraphBodyStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
        {
        }

        public virtual IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter)
        {
            return new DotAttributeStatementStringWriter(_writer, _context, useStatementDelimiter);
        }

        public virtual IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter)
        {
            return new DotNodeStatementStringWriter(_writer, _context, useStatementDelimiter);
        }

        public virtual IDotEdgeCollectionWriter BeginEdgesSection(bool useStatementDelimiter)
        {
            return new DotEdgeStatementStringWriter(_writer, _context, useStatementDelimiter);
        }

        public virtual void EndAttributesSection(int attributeCount)
        {
            EndSection(attributeCount);
        }

        public virtual void EndNodesSection(int nodeCount)
        {
            EndSection(nodeCount);
        }

        public virtual void EndEdgesSection(int edgeCount)
        {
            EndSection(edgeCount);
        }

        protected virtual void EndSection(int entityCount)
        {
            if (entityCount > 0)
            {
                _writer.ClearLingerBuffer()
                       .LineBreak(linger: true)
                       .Indentation(_context.Level, linger: true);
            }
        }
    }
}
