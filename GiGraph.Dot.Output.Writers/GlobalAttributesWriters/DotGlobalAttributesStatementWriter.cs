using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using GiGraph.Dot.Output.Writers.GraphWriters;
using GiGraph.Dot.Output.Writers.NodeWriters;

namespace GiGraph.Dot.Output.Writers.GlobalAttributesWriters
{
    public class DotGlobalAttributesStatementWriter : DotEntityWriter, IDotGlobalAttributesStatementWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotGlobalAttributesStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public IDotGraphAttributesWriter BeginGraphAttributes()
        {
            throw new System.NotImplementedException();
        }

        public void EndGraphAttributes()
        {
            EndEntityDefaults();
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
