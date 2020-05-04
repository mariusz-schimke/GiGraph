using Dotless.DotWriters.Options;
using System;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    // TODO: dać możliwość przekazania strumienia, żeby do niego zapisywało
    // TODO: uściślić, gdzie mają być dodawane w poniżych metodach separatory za tokenem, a gdzie nie (gdzie ma być odpowiedzialność za to)
    // TODO: czy te metody powinny być publiczne? Może jednak prywatne, z dostępem tylko z poziomu kontekstów?
    // TODO: bazując na punkcie wyżej, sprawdzić, czy dostępność wszystkich metod jest spójna
    public abstract partial class DotStringWriter
    {
        protected readonly StreamWriter _writer;
        protected readonly DotFormattingOptions _options;
        protected readonly int _level;
        protected string _separator = string.Empty;

        protected DotStringWriter(StreamWriter writer, DotFormattingOptions options, int level = 0)
        {
            _writer = writer;
            _options = options;
            _level = level;
        }

        public virtual DotStringWriter WriteToken(string token)
        {
            return Append(token);
        }

        public virtual DotStringWriter WriteKeyword(string keyword)
        {
            return WriteToken(keyword).PushTokenSpace();
        }

        public virtual DotStringWriter WriteIdentifier(string id, bool quote = false)
        {
            if (quote)
            {
                WriteQuotationStart().WriteToken(id).WriteQuotationEnd();
            }
            else
            {
                WriteToken(id);
            }

            return PushTokenSpace();
        }

        public virtual DotStringWriter WriteValueAssignmentOperator()
        {
            return WriteToken("=").PushTokenSpace();
        }

        public virtual DotStringWriter WriteBlockStart()
        {
            return WriteToken("{").PushLineBreak();
        }

        public virtual DotStringWriter WriteBlockEnd()
        {
            return PushLineBreak().WriteToken("}");
        }

        public virtual DotStringWriter WriteListStart()
        {
            return WriteToken("[").PushLineBreak();
        }

        public virtual DotStringWriter WriteListEnd()
        {
            return PushLineBreak().WriteToken("]");
        }

        public virtual DotStringWriter WriteListItemDelimiter()
        {
            return ClearSeparator().WriteToken(",").PushTokenSpace();
        }

        public virtual DotStringWriter WriteTextValue(string text, bool quote = true)
        {
            if (quote)
            {
                WriteQuotationStart().WriteToken(text).WriteQuotationEnd();
            }
            else
            {
                WriteToken(text);
            }

            return PushTokenSpace();
        }

        public virtual DotStringWriter WriteHtmlValue(string html, bool brace = true)
        {
            if (brace)
            {
                WriteHtmlStart().WriteToken(html).WriteHtmlEnd();
            }
            else
            {
                WriteToken(html);
            }

            return PushTokenSpace();
        }

        public virtual DotStringWriter WriteQuotationStart()
        {
            return WriteToken("\"");
        }

        public virtual DotStringWriter WriteQuotationEnd()
        {
            return WriteToken("\"");
        }

        public virtual DotStringWriter WriteHtmlStart()
        {
            return WriteToken("<");
        }

        public virtual DotStringWriter WriteHtmlEnd()
        {
            return WriteToken(">");
        }

        public virtual DotStringWriter WriteStatementEnd()
        {
            return ClearSeparator().WriteToken(";");
        }

        public virtual TContext AssertContext<TContext>()
            where TContext : DotWriterContext
        {
            return this as TContext
                ?? throw new InvalidCastException($"The current DOT writer context {GetType().Name} cannot be accessed as {typeof(TContext).Name}.");
        }

        protected virtual DotStringWriter Append(string value)
        {
            FlushSeparator();
            _writer.Write(value);

            return this;
        }

        protected virtual DotStringWriter PushSeparator(string separator)
        {
            _separator = separator;
            return this;
        }

        protected virtual DotStringWriter FlushSeparator()
        {
            _writer.Write(_separator);
            return ClearSeparator();
        }

        protected virtual DotStringWriter ClearSeparator()
        {
            _separator = string.Empty;
            return this;
        }

        protected virtual DotStringWriter PushLineBreak()
        {
            PushSeparator(_options.LineBreak());
            return this;
        }

        protected virtual DotStringWriter PushTokenSpace()
        {
            PushSeparator(_options.TokenSpace());
            return this;
        }
    }
}
