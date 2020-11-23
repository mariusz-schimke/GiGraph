﻿using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Comments;

namespace GiGraph.Dot.Output.Writers.Graphs
{
    public class DotGraphWriterRoot : IDotGraphWriterRoot
    {
        protected readonly DotFormattingOptions _formattingOptions;
        protected readonly DotTokenWriter _tokenWriter;
        private bool _initializeIndentation = true;

        public DotGraphWriterRoot(DotTokenWriter tokenWriter, DotFormattingOptions formattingOptions)
        {
            _tokenWriter = tokenWriter;
            _formattingOptions = formattingOptions;
        }

        public virtual IDotGraphWriter BeginGraph(bool directed)
        {
            InitializeIndentation();
            return new DotGraphWriter(_tokenWriter, new DotEntityWriterConfiguration(directed, _formattingOptions));
        }

        public virtual void EndGraph()
        {
        }

        public virtual IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            InitializeIndentation();
            return new DotCommentWriter(_tokenWriter, preferBlockComment);
        }

        public virtual void EndComment()
        {
            _tokenWriter.LineBreak()
               .Indentation(linger: true);
        }

        protected virtual void InitializeIndentation()
        {
            if (_initializeIndentation)
            {
                _tokenWriter.Indentation(linger: true);
                _initializeIndentation = false;
            }
        }
    }
}