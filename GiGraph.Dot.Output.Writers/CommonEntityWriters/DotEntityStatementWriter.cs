﻿using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public abstract class DotEntityStatementWriter : DotEntityWriter
    {
        protected readonly bool _useStatementDelimiter;

        protected DotEntityStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual void EndStatement()
        {
            _tokenWriter.ClearLingerBuffer();

            if (_useStatementDelimiter)
            {
                _tokenWriter.StatementEnd();
            }

            _tokenWriter.LineBreak()
                        .Indentation(linger: true);
        }

        public override IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, preferBlockComment: true);
        }

        public override void EndComment()
        {
            _tokenWriter.LineBreak()
                        .LineBreak(linger: true)
                        .Indentation(linger: true);
        }
    }
}