﻿using System;
using System.Collections.Generic;
using System.IO;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Options;

namespace GiGraph.Dot.Output.Writers.TokenWriter;

public class DotTokenWriter
{
    protected readonly Queue<(string Token, DotTokenType Type)> _lingerBuffer;
    protected readonly TextWriter _writer;

    protected DotTokenWriter(TextWriter writer, Queue<(string, DotTokenType)> lingerBuffer, DotTokenWriterOptions options)
    {
        _writer = writer;
        _lingerBuffer = lingerBuffer;
        Options = options;
    }

    public DotTokenWriter(TextWriter writer, DotTokenWriterOptions options)
        : this(writer, new(), options)
    {
    }

    public EventHandler<DotAppendTokenEventArgs> OnBeforeAppendToken { get; set; }
    public EventHandler<DotAppendTokenEventArgs> OnAfterAppendToken { get; set; }

    public DotTokenWriterOptions Options { get; }

    public virtual DotTokenWriter SingleLine() => CloneWith(Options.ToSingleLine());

    public virtual DotTokenWriter NextIndentationLevel() => CloneWith(Options.IncreaseIndentation());

    public virtual DotTokenWriter CloneWith(Action<DotTokenWriter> init)
    {
        var result = CloneWith(Options);
        init?.Invoke(result);
        return result;
    }

    public virtual DotTokenWriter CloneWith(DotTokenWriterOptions options)
    {
        return new(_writer, _lingerBuffer, options)
        {
            OnBeforeAppendToken = (sender, e) => OnBeforeAppendToken?.Invoke(sender, e),
            OnAfterAppendToken = (sender, e) => OnAfterAppendToken?.Invoke(sender, e)
        };
    }

    public virtual DotTokenWriter Token(string token, DotTokenType type, bool linger = false) => Append(token, type, linger);

    public virtual DotTokenWriter Keyword(string keyword, bool linger = false) => Token(keyword, DotTokenType.Keyword, linger);

    public virtual DotTokenWriter Identifier(string id, bool quote, bool linger = false) => Identifier(id, DotTokenType.Identifier, quote, linger);

    public virtual DotTokenWriter Value(string value, bool quote, bool linger = false) => Identifier(value, DotTokenType.Value, quote, linger);

    protected virtual DotTokenWriter Identifier(string id, DotTokenType tokenType, bool quote, bool linger)
    {
        if (quote)
        {
            QuotationStart(linger);
            Token(id, tokenType, linger);
            QuotationEnd(linger);
        }
        else
        {
            Token(id, tokenType, linger);
        }

        return this;
    }

    public virtual DotTokenWriter ValueAssignmentOperator(bool linger = false) => Token("=", DotTokenType.ValueAssignmentOperator, linger);

    public virtual DotTokenWriter StringConcatenationOperator(bool linger = false) => Token("+", DotTokenType.StringConcatenationOperator, linger);

    public virtual DotTokenWriter BlockStart(bool linger = false) => Token("{", DotTokenType.BlockStart, linger);

    public virtual DotTokenWriter BlockEnd(bool linger = false) => Token("}", DotTokenType.BlockEnd, linger);

    public virtual DotTokenWriter AttributeListStart(bool linger = false) => Token("[", DotTokenType.AttributeListStart, linger);

    public virtual DotTokenWriter AttributeListEnd(bool linger = false) => Token("]", DotTokenType.AttributeListEnd, linger);

    public virtual DotTokenWriter AttributeSeparator(bool linger = false) => Token(",", DotTokenType.AttributeSeparator, linger);

    public virtual DotTokenWriter NodeSeparator(bool linger = false) => Token(",", DotTokenType.NodeSeparator, linger);

    public virtual DotTokenWriter NodePortSeparator(bool linger = false) => Token(":", DotTokenType.NodePortSeparator, linger);

    public virtual DotTokenWriter StatementDelimiter(bool linger = false) => Token(";", DotTokenType.StatementDelimiter, linger);

    public virtual DotTokenWriter QuotationStart(bool linger = false) => Token("\"", DotTokenType.QuotationStart, linger);

    public virtual DotTokenWriter QuotationEnd(bool linger = false) => Token("\"", DotTokenType.QuotationEnd, linger);

    public virtual DotTokenWriter HtmlValueStart(bool linger = false) => Token("<", DotTokenType.HtmlValueStart, linger);

    public virtual DotTokenWriter HtmlValueEnd(bool linger = false) => Token(">", DotTokenType.HtmlValueEnd, linger);

    public virtual DotTokenWriter HtmlValue(string html, bool writeInBrackets = true, bool linger = false)
    {
        if (writeInBrackets)
        {
            HtmlValueStart(linger);
            Token(html, DotTokenType.HtmlValue, linger);
            HtmlValueEnd(linger);
        }
        else
        {
            Token(html, DotTokenType.HtmlValue, linger);
        }

        return this;
    }

    public virtual DotTokenWriter Edge(bool directed = false, bool linger = false) => directed ? DirectedEdge(linger) : UndirectedEdge(linger);

    public virtual DotTokenWriter UndirectedEdge(bool linger = false) => Token("--", DotTokenType.UndirectedEdge, linger);

    public virtual DotTokenWriter DirectedEdge(bool linger = false) => Token("->", DotTokenType.DirectedEdge, linger);

    public virtual DotTokenWriter CommentStart(bool linger = false) => Token("//", DotTokenType.CommentStart, linger);

    public virtual DotTokenWriter DiscardedLineStart(bool linger = false) =>
        // based on https://www.graphviz.org/doc/info/lang.html
        // The language supports C++-style comments: /* */ and //. In addition, a line beginning with a '#' character
        // is considered a line output from a C preprocessor (e.g., # 34 to indicate line 34 ) and discarded
        Token("#", DotTokenType.DiscardedLineStart, linger);

    public virtual DotTokenWriter BlockCommentStart(bool linger = false) => Token("/*", DotTokenType.BlockCommentStart, linger);

    public virtual DotTokenWriter BlockCommentEnd(bool linger = false) => Token("*/", DotTokenType.BlockCommentEnd, linger);

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
            if (Options.HashForSingleLineComments)
            {
                DiscardedLineStart(linger);
            }
            else
            {
                CommentStart(linger);
            }

            Space(linger);

            Append(commentLines[i], DotTokenType.CommentText, linger);

            if (i < commentLines.Length - 1)
            {
                NewLine(linger);
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

        for (var i = 0; i < commentLines.Length; i++)
        {
            var line = commentLines[i];
            var isLastLine = i == commentLines.Length - 1;

            if (!isLastLine || !string.IsNullOrEmpty(line))
            {
                if (i == 0)
                {
                    Space(linger);
                }
                else
                {
                    // alignment is not written in single-line mode (as opposed to space)
                    Alignment(width: 3, linger);
                }
            }

            Append(line, DotTokenType.BlockCommentText, linger);

            if (!isLastLine)
            {
                NewLine(linger);
            }
        }

        Space(linger);
        return BlockCommentEnd(linger);
    }

    public virtual DotTokenWriter LineBreak(bool linger = false) => Append(Options.LineBreak(), DotTokenType.LineBreak, linger);

    public virtual DotTokenWriter NewLine(bool linger = false, bool enforceLineBreak = false)
    {
        LineBreak(linger && !enforceLineBreak);
        return Indentation(linger);
    }

    public virtual DotTokenWriter EmptyLine(bool linger = false, bool enforceLineBreak = false)
    {
        LineBreak(linger && !enforceLineBreak);
        return NewLine(linger, enforceLineBreak: false);
    }

    public virtual DotTokenWriter Space(bool linger = false) => Space(1, linger);

    public virtual DotTokenWriter Space(int count, bool linger = false) => Append(Options.Space(count), DotTokenType.Space, linger);

    public virtual DotTokenWriter Indentation(bool linger = false) => Append(Options.Indentation(), DotTokenType.Indentation, linger);

    protected virtual DotTokenWriter Alignment(int width, bool linger = false) => Append(Options.Alignment(width), DotTokenType.Space, linger);

    protected virtual DotTokenWriter Append(string token, DotTokenType tokenType, bool linger = false)
    {
        var eventArgs = new DotAppendTokenEventArgs(token, tokenType, linger);
        OnBeforeAppendToken?.Invoke(this, eventArgs);

        if (linger)
        {
            _lingerBuffer.Enqueue((token, tokenType));
        }
        else
        {
            FlushLingerBuffer();
            Write(token, tokenType);
        }

        OnAfterAppendToken?.Invoke(this, eventArgs);
        return this;
    }

    protected virtual void Write(string token, DotTokenType type)
    {
        if (Options.TextEncoder is { } encode)
        {
            token = encode(token, type);
        }

        _writer.Write(token);
    }

    public virtual DotTokenWriter FlushLingerBuffer()
    {
        while (_lingerBuffer.Count > 0)
        {
            var (token, type) = _lingerBuffer.Dequeue();
            Write(token, type);
        }

        return this;
    }

    public virtual DotTokenWriter ClearLingerBuffer()
    {
        _lingerBuffer.Clear();
        return this;
    }
}