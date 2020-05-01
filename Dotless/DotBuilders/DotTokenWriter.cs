using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless.DotBuilders
{

    public class DotTokenWriter
    {
        private readonly IDotToken[] _tokens;

        public DotTokenWriter(ICollection<IDotToken> tokens)
        {
            _tokens = tokens.ToArray();
        }

        public virtual void Write(StringBuilder sb, DotTokenWriterOptions options)
        {
            if (!_tokens.Any())
            {
                return;
            }

            sb.Append(options.Indentation(level: 0));

            var reader = new DotTokenCollectionReader(_tokens);

            while (reader.Next(out var token))
            {
                HandleToken(token!, sb, options, reader, level: 0);
            }
        }

        protected virtual void HandleToken(IDotToken token, StringBuilder sb, DotTokenWriterOptions o, DotTokenCollectionReader reader, int level)
        {
            switch (reader.Current)
            {
                case DotKeyword kw:
                    Keyword(kw, sb, o, reader, ref level);
                    break;

                case DotIdentifier id:
                    Identifier(id, sb, o, reader, ref level);
                    break;

                case DotGraphBlockStart gb:
                    GraphBlock(gb, sb, o, reader, level);
                    break;

                case DotAttributeCollectionStart ac:
                    AttributeCollection(ac, sb, o, reader, level);
                    break;
            }

            return;

            switch (reader.Current)
            {
                // required space between tokens
                //case DotKeyword _ when reader.Peek<DotKeyword>(): // e.g. strict graph
                //case DotKeyword _ when reader.Peek<DotIdentifier>(): // e.g. graph name
                //case DotKeyword _ when reader.Peek<DotQuotationStart>(): // e.g. graph "name"
                //    sb.Append(reader.Current);
                //    sb.Append(o.MandatoryTokenSpace());
                //    break;

                // multiline items
                case DotIdentifier _:
                case DotHtmlText _:
                    sb.Append(o.String(reader.Current.ToString()));

                    if (!reader.IsLast)
                    {
                        sb.Append(o.TokenSpace());
                    }
                    break;

                // increase indentation of block items
                case DotGraphBlockStart _:
                    sb.Append(reader.Current);
                    sb.Append(o.NewLine(++level));
                    break;

                // decrease indentation when block ends
                case DotGraphBlockEnd _:
                    sb.Append(o.Indentation(--level));
                    sb.Append(reader.Current);
                    break;

                // increase indentation of attributes if more than one
                case DotAttributeCollectionStart _:
                    sb.Append(reader.Current);
                    sb.Append(o.NewLine(++level));
                    break;

                // increase indentation of HTML text lines if more than one
                case DotHtmlTextStart _:
                    sb.Append(reader.Current);
                    sb.Append(o.NewLine(++level));
                    break;

                case IDotToken _ when reader.Peek<DotGraphBlockEnd>():
                case IDotToken _ when reader.Peek<DotAttributeCollectionEnd>():
                case IDotToken _ when reader.Peek<DotHtmlTextEnd>():
                    sb.Append(reader.Current);
                    sb.Append(o.LineBreak());
                    break;

                // statements and attribute list items separated into lines
                case DotStatementSeparator _:
                case DotAttributeSeparator _:
                    sb.Append(reader.Current);
                    sb.Append(o.NewLine(level));
                    break;

                // no space after quotation mark, before quotation mark, and before a semicolon
                case DotQuotationStart _:
                case IDotToken _ when reader.Peek<DotQuotationEnd>():
                case IDotToken _ when reader.Peek<DotStatementSeparator>():
                    sb.Append(reader.Current);
                    break;

                default:
                    sb.Append(reader.Current);
                    sb.Append(o.TokenSpace());
                    break;
            }
        }

        protected virtual void Keyword(DotKeyword kw, StringBuilder sb, DotTokenWriterOptions o, DotTokenCollectionReader reader, ref int level)
        {
            sb.Append(kw);

            // space required between tokens
            switch (reader.Peek())
            {
                case DotKeyword _:
                case DotIdentifier _:
                case DotQuotationStart _:
                    sb.Append(o.MandatoryTokenSpace());
                    break;
            }
        }

        protected virtual void Identifier(DotIdentifier id, StringBuilder sb, DotTokenWriterOptions o, DotTokenCollectionReader reader, ref int level)
        {
            sb.Append(o.String(id.ToString()));
        }

        protected virtual void GraphBlock(DotGraphBlockStart gb, StringBuilder sb, DotTokenWriterOptions o, DotTokenCollectionReader reader, int level)
        {
            sb.Append(gb);

            while (reader.NextUntil<DotGraphBlockEnd>(out var token))
            {
                HandleToken(token!, sb, o, reader, level + 1);
            }

            if (reader.CurrentIs<DotGraphBlockEnd>())
            {
                sb.Append(reader.Current);
            }
        }

        protected virtual void AttributeCollection(DotAttributeCollectionStart ac, StringBuilder sb, DotTokenWriterOptions o, DotTokenCollectionReader reader, int level)
        {
            sb.Append(ac);

            while (reader.NextUntil<DotAttributeCollectionEnd>(out var token))
            {
                HandleToken(token!, sb, o, reader, level + 1);
            }

            if (reader.CurrentIs<DotAttributeCollectionEnd>())
            {
                sb.Append(reader.Current);
            }
        }
    }
}
