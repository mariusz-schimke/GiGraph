using System.Collections.Generic;
using System.IO;
using GiGraph.Dot.Output.Writers.Options;

namespace GiGraph.Dot.Output.Writers
{
    public class DotTokenWriter
    {
        protected readonly Queue<string> _lingerBuffer;
        protected readonly StreamWriter _writer;

        protected DotTokenWriter(StreamWriter writer, Queue<string> lingerBuffer, DotTokenWriterOptions options)
        {
            _writer = writer;
            Options = options;
            _lingerBuffer = lingerBuffer;
        }

        public DotTokenWriter(StreamWriter writer, DotTokenWriterOptions options)
            : this(writer, new Queue<string>(), options)
        {
        }

        public DotTokenWriterOptions Options { get; }

        public virtual DotTokenWriter SingleLine()
        {
            return new DotTokenWriter(_writer, _lingerBuffer, Options.ToSingleLine());
        }

        public virtual DotTokenWriter NextIndentationLevel()
        {
            return new DotTokenWriter(_writer, _lingerBuffer, Options.IncreaseIndentation());
        }

        public virtual DotTokenWriter Token(string token, bool linger = false)
        {
            return Append(token, linger);
        }

        public virtual DotTokenWriter Keyword(string keyword, bool linger = false)
        {
            return Token(keyword, linger);
        }

        public virtual DotTokenWriter Identifier(string id, bool quote = false, bool linger = false)
        {
            if (quote)
            {
                QuotationStart(linger);
                Token(id, linger);
                QuotationEnd(linger);
            }
            else
            {
                Token(id, linger);
            }

            return this;
        }

        public virtual DotTokenWriter ValueAssignmentOperator(bool linger = false)
        {
            return Token("=", linger);
        }

        public virtual DotTokenWriter StringConcatenationOperator(bool linger = false)
        {
            return Token("+", linger);
        }

        public virtual DotTokenWriter BlockStart(bool linger = false)
        {
            return Token("{", linger);
        }

        public virtual DotTokenWriter BlockEnd(bool linger = false)
        {
            return Token("}", linger);
        }

        public virtual DotTokenWriter AttributeListStart(bool linger = false)
        {
            return Token("[", linger);
        }

        public virtual DotTokenWriter AttributeListEnd(bool linger = false)
        {
            return Token("]", linger);
        }

        public virtual DotTokenWriter AttributeSeparator(bool linger = false)
        {
            return Token(",", linger);
        }

        public virtual DotTokenWriter NodeSeparator(bool linger = false)
        {
            return Token(",", linger);
        }

        public virtual DotTokenWriter NodePortDelimiter(bool linger = false)
        {
            return Token(":", linger);
        }

        public virtual DotTokenWriter StatementEnd(bool linger = false)
        {
            return Token(";", linger);
        }

        public virtual DotTokenWriter QuotationStart(bool linger = false)
        {
            return Token("\"", linger);
        }

        public virtual DotTokenWriter QuotationEnd(bool linger = false)
        {
            return Token("\"", linger);
        }

        public virtual DotTokenWriter HtmlStartBracket(bool linger = false)
        {
            return Token("<", linger);
        }

        public virtual DotTokenWriter HtmlEndBracket(bool linger = false)
        {
            return Token(">", linger);
        }

        public virtual DotTokenWriter Html(string html, bool writeInBrackets = true, bool linger = false)
        {
            if (writeInBrackets)
            {
                HtmlStartBracket(linger);
                Token(html, linger);
                HtmlEndBracket(linger);
            }
            else
            {
                Token(html, linger);
            }

            return this;
        }

        public virtual DotTokenWriter Edge(bool directed = false, bool linger = false)
        {
            return directed ? DirectedEdge(linger) : UndirectedEdge(linger);
        }

        public virtual DotTokenWriter UndirectedEdge(bool linger = false)
        {
            return Token("--", linger);
        }

        public virtual DotTokenWriter DirectedEdge(bool linger = false)
        {
            return Token("->", linger);
        }

        public virtual DotTokenWriter CommentStart(bool linger = false)
        {
            return Token("//", linger);
        }

        public virtual DotTokenWriter BlockCommentStart(bool linger = false)
        {
            return Token("/*", linger);
        }

        public virtual DotTokenWriter BlockCommentEnd(bool linger = false)
        {
            return Token("*/", linger);
        }

        public virtual DotTokenWriter Comment(string comment, bool linger = false)
        {
            var lines = Options.SplitMultilineText(comment);

            return Options.SingleLine
                ? BlockComment(lines, linger)
                : Comment(lines, linger);
        }

        protected virtual DotTokenWriter Comment(string[] commentLines, bool linger)
        {
            for (var i = 0; i < commentLines.Length; i++)
            {
                CommentStart(linger);
                Space(linger);

                Append(commentLines[i], linger);

                if (i < commentLines.Length - 1)
                {
                    LineBreak(linger);
                    Indentation(linger);
                }
            }

            return this;
        }

        public virtual DotTokenWriter BlockComment(string comment, bool linger = false)
        {
            var lines = Options.SplitMultilineText(comment);
            return BlockComment(lines, linger);
        }

        protected virtual DotTokenWriter BlockComment(string[] commentLines, bool linger)
        {
            BlockCommentStart(linger);
            Space(linger);

            for (var i = 0; i < commentLines.Length; i++)
            {
                Append(commentLines[i], linger);

                if (i < commentLines.Length - 1)
                {
                    LineBreak(linger);
                    Indentation(linger);
                }
            }

            Space(linger);
            BlockCommentEnd(linger);

            return this;
        }

        public virtual DotTokenWriter LineBreak(bool linger = false)
        {
            Append(Options.LineBreak(), linger);
            return this;
        }

        public virtual DotTokenWriter NewLine(bool linger = false)
        {
            LineBreak(linger);
            Indentation(linger);
            return this;
        }

        public virtual DotTokenWriter Space(bool linger = false)
        {
            Append(Options.Space(), linger);
            return this;
        }

        public virtual DotTokenWriter Indentation(bool linger = false)
        {
            Append(Options.Indentation(), linger);
            return this;
        }

        protected virtual DotTokenWriter Append(string value, bool linger = false)
        {
            if (linger)
            {
                _lingerBuffer.Enqueue(value);
            }
            else
            {
                FlushLingerBuffer();
                Write(value);
            }

            return this;
        }

        protected virtual void Write(string value)
        {
            if (Options.TextEncoder is {} encode)
            {
                value = encode(value);
            }

            _writer.Write(value);
        }

        public virtual DotTokenWriter FlushLingerBuffer()
        {
            while (_lingerBuffer.Count > 0)
            {
                Write(_lingerBuffer.Dequeue());
            }

            return this;
        }

        public virtual DotTokenWriter ClearLingerBuffer()
        {
            _lingerBuffer.Clear();
            return this;
        }
    }
}