using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Graphs;
using GiGraph.Dot.Output.Writers.Nodes;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotGlobalAttributesStatementWriter : DotEntityWriter, IDotGlobalAttributesStatementWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotGlobalAttributesStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual IDotGraphAttributesWriter BeginGraphAttributes()
        {
            return new DotGraphAttributesWriter(_tokenWriter, _context);
        }

        public virtual void EndGraphAttributes()
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
               .Indentation(linger: true);
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}