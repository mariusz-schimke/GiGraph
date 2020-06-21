using System.Collections.Generic;
using System.IO;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Writers
{
    public class DotTokenWriter
    {
        protected readonly StreamWriter _writer;
        protected readonly Queue<string> _lingerBuffer;

        protected readonly DotFormattingOptions _options;

        protected DotTokenWriter(StreamWriter writer, DotFormattingOptions options, Queue<string> lingerBuffer)
        {
            _writer = writer;
            _options = options;
            _lingerBuffer = lingerBuffer;
        }

        public DotTokenWriter(StreamWriter writer, DotFormattingOptions options)
            : this(writer, options, new Queue<string>())
        {
        }

        public virtual DotTokenWriter SingleLine()
        {
            var singleLineOutputOptions = _options.Clone();
            singleLineOutputOptions.SingleLineOutput = true;

            return new DotTokenWriter(_writer, singleLineOutputOptions, _lingerBuffer);
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

        public virtual DotTokenWriter SectionStart(bool linger = false)
        {
            return Token("{", linger);
        }

        public virtual DotTokenWriter SectionEnd(bool linger = false)
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
            return directed ? DirectedEdge(linger) : Token("--", linger);
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

        public virtual DotTokenWriter Comment(string comment, int indentationLevel, bool linger = false)
        {
            var lines = _options.SplitMultilineText(comment);

            if (_options.SingleLineOutput)
            {
                return BlockComment(lines, indentationLevel, linger);
            }
            else
            {
                return Comment(lines, indentationLevel, linger);
            }
        }

        protected virtual DotTokenWriter Comment(string[] commentLines, int indentationLevel, bool linger)
        {
            for (int i = 0; i < commentLines.Length; i++)
            {
                CommentStart(linger);
                Space(linger);

                Append(commentLines[i], linger);

                if (i < commentLines.Length - 1)
                {
                    LineBreak(linger);
                    Indentation(indentationLevel, linger);
                }
            }

            return this;
        }

        public virtual DotTokenWriter BlockComment(string comment, int indentationLevel, bool linger = false)
        {
            var lines = _options.SplitMultilineText(comment);
            return BlockComment(lines, indentationLevel, linger);
        }

        protected virtual DotTokenWriter BlockComment(string[] commentLines, int indentationLevel, bool linger)
        {
            BlockCommentStart(linger);
            Space(linger);

            for (int i = 0; i < commentLines.Length; i++)
            {
                Append(commentLines[i], linger);

                if (i < commentLines.Length - 1)
                {
                    LineBreak(linger);
                    Indentation(indentationLevel, linger);
                }
            }

            Space(linger);
            BlockCommentEnd(linger);

            return this;
        }

        public virtual DotTokenWriter LineBreak(bool linger = false)
        {
            Append(_options.LineBreak(), linger);
            return this;
        }

        public virtual DotTokenWriter Space(bool linger = false)
        {
            Append(_options.Space(), linger);
            return this;
        }

        public virtual DotTokenWriter Indentation(int level, bool linger = false)
        {
            Append(_options.Indentation(level), linger);
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
            _writer.Write(_options.TextEncoder?.Invoke(value) ?? value);
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