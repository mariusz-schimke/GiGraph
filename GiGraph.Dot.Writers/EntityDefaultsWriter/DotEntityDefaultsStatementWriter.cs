using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;
using GiGraph.Dot.Writers.EdgeWriters;
using GiGraph.Dot.Writers.NodeWriters;

namespace GiGraph.Dot.Writers.EntityDefaultsWriter
{
    public class DotEntityDefaultsStatementWriter : DotEntityWriter, IDotEntityDefaultsStatementWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotEntityDefaultsStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual IDotNodeDefaultsWriter BeginNodeDefaults()
        {
            return new DotNodeDefaultsWriter(_tokenWriter, _context);
        }

        public virtual void EndNodeDefaults()
        {
            EndEntityDefaults();
        }

        public virtual IDotEdgeDefaultsWriter BeginEdgeDefaults()
        {
            return new DotEdgeDefaultsWriter(_tokenWriter, _context);
        }

        public virtual void EndEdgeDefaults()
        {
            EndEntityDefaults();
        }

        protected virtual void EndEntityDefaults()
        {
            if (_useStatementDelimiter)
            {
                _tokenWriter.StatementEnd();
            }

            _tokenWriter.LineBreak()
                        .Indentation(_context.Level, linger: true);
        }
    }
}
