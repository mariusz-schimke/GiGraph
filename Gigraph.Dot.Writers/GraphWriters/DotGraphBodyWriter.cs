using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.CommonEntityWriters;
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

        public virtual void EndAttributesSection()
        {
            EndSection();
        }

        public virtual IDotEntityDefaultsWriter BeginNodeDefaults()
        {
            return new DotNodeDefaultsWriter(_tokenWriter, _context);
        }

        public virtual void EndNodeDefaults(bool useStatementDelimiter)
        {
            EndDefaults(useStatementDelimiter);
        }

        public virtual IDotEntityDefaultsWriter BeginEdgeDefaults()
        {
            return new DotEdgeDefaultsWriter(_tokenWriter, _context);
        }

        public virtual void EndEdgeDefaults(bool useStatementDelimiter)
        {
            EndDefaults(useStatementDelimiter);
        }

        public virtual IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter)
        {
            return new DotNodeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual void EndNodesSection()
        {
            EndSection();
        }

        public virtual IDotEdgeCollectionWriter BeginEdgesSection(bool useStatementDelimiter)
        {
            return new DotEdgeStatementWriter(_tokenWriter, _context, useStatementDelimiter);
        }

        public virtual void EndEdgesSection()
        {
            EndSection();
        }

        public virtual IDotSubgraphCollectionWriter BeginSubgraphsSection()
        {
            return new DotSubgraphCollectionWriter(_tokenWriter, _context);
        }

        public virtual void EndSubgraphsSection()
        {
            EndSection();
        }

        protected virtual void EndDefaults(bool useStatementDelimiter)
        {
            if (useStatementDelimiter)
            {
                _tokenWriter.StatementEnd();
            }

            _tokenWriter.LineBreak();

            EndSection();
        }

        protected virtual void EndSection()
        {
            _tokenWriter.ClearLingerBuffer()
                        .LineBreak(linger: true)
                        .Indentation(_context.Level, linger: true);
        }
    }
}
