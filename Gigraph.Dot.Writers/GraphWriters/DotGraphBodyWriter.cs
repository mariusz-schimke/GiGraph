using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.Contexts;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public class DotGraphBodyWriter : DotEntityWriter, IDotGraphBodyWriter
    {
        public DotGraphBodyWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter)
        {
            return new DotAttributeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter)
        {
            return new DotNodeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual IDotEdgeCollectionWriter BeginEdgesSection(bool useStatementDelimiter)
        {
            return new DotEdgeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual IDotSubgraphCollectionWriter BeginSubgraphsSection()
        {
            return new DotSubgraphCollectionWriter(_tokenWriter, _context);
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

        public virtual void EndSubgraphsSection(int subgraphCount)
        {
            EndSection(subgraphCount);
        }

        protected virtual void EndSection(int entityCount)
        {
            if (entityCount > 0)
            {
                _tokenWriter.ClearLingerBuffer()
                            .LineBreak(linger: true)
                            .Indentation(_context.Level, linger: true);
            }
        }
    }
}
