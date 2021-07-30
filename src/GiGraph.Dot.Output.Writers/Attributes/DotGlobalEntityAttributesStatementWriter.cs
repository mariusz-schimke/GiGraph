﻿using GiGraph.Dot.Output.Writers.Edges.Attributes;
using GiGraph.Dot.Output.Writers.Graphs.Attributes;
using GiGraph.Dot.Output.Writers.Nodes.Attributes;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotGlobalEntityAttributesStatementWriter : DotEntityStatementWriter, IDotGlobalEntityAttributesStatementWriter
    {
        public DotGlobalEntityAttributesStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, useStatementDelimiter)
        {
        }

        public virtual IDotGlobalGraphAttributesWriter BeginGraphAttributesStatement()
        {
            return new DotGlobalGraphAttributesWriter(_tokenWriter, _configuration);
        }

        public virtual void EndGraphAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalNodeAttributesWriter BeginNodeAttributesStatement()
        {
            return new DotGlobalNodeAttributesWriter(_tokenWriter, _configuration);
        }

        public virtual void EndNodeAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalEdgeAttributesWriter BeginEdgeAttributesStatement()
        {
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

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}