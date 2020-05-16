using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;
using Gigraph.Dot.Writers.EdgeWriters;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Writers.EntityDefaultsWriter
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
