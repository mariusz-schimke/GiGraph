using GiGraph.Dot.Output.Writers.Edges.Attributes;
using GiGraph.Dot.Output.Writers.Graphs.Attributes;
using GiGraph.Dot.Output.Writers.Nodes.Attributes;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotGlobalEntityAttributesStatementWriter : DotEntityStatementWriter, IDotGlobalEntityAttributesStatementWriter
    {
        protected bool? _wasPreviousEntitySingleLine;

        public DotGlobalEntityAttributesStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, useStatementDelimiter)
        {
        }

        public virtual IDotGlobalGraphAttributesWriter BeginGraphAttributesStatement()
        {
            EnsureStatementSpacing(_configuration.Formatting.GlobalAttributes.SingleLineGraphAttributeList);
            return new DotGlobalGraphAttributesWriter(_tokenWriter, _configuration);
        }

        public virtual void EndGraphAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalNodeAttributesWriter BeginNodeAttributesStatement()
        {
            EnsureStatementSpacing(_configuration.Formatting.GlobalAttributes.SingleLineNodeAttributeList);
            return new DotGlobalNodeAttributesWriter(_tokenWriter, _configuration);
        }

        public virtual void EndNodeAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalEdgeAttributesWriter BeginEdgeAttributesStatement()
        {
            EnsureStatementSpacing(_configuration.Formatting.GlobalAttributes.SingleLineEdgeAttributeList);
            return new DotGlobalEdgeAttributesWriter(_tokenWriter, _configuration);
        }

        public virtual void EndEdgeAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        protected virtual void EndEntityAttributesStatement()
        {
            EndStatement();
        }

        protected virtual void EnsureStatementSpacing(bool isCurrentEntitySingleLine)
        {
            // if the previous entity was multiline, or the current one is, insert a line break to separate them for clarity
            // (unless this is the first entity)
            if (_wasPreviousEntitySingleLine.HasValue && (!_wasPreviousEntitySingleLine.Value || !isCurrentEntitySingleLine))
            {
                LineBreak();
            }

            _wasPreviousEntitySingleLine = isCurrentEntitySingleLine;
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}