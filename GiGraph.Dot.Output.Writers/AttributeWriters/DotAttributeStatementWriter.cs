﻿using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.AttributeWriters
{
    public class DotAttributeStatementWriter : DotEntityWriter, IDotAttributeStatementWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotAttributeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeWriter(_tokenWriter, _context, enforceBlockComment: false);
        }

        public virtual void EndAttribute()
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