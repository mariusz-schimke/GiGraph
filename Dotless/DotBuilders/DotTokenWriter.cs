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

        public void Write(StringBuilder sb, DotTokenWriterOptions options)
        {
            if (!_tokens.Any())
            {
                return;
            }

            var level = 0;

            sb.Append(options.Indentation(level));

            for (int i = 0; i < _tokens.Length; i++)
            {
                var curr = _tokens[i];
                var next = i < _tokens.Length - 1 ? _tokens[i + 1] : null;

                HandleTokenPair(sb, options, curr, next, ref level);
            }
        }

        protected virtual void HandleTokenPair(StringBuilder sb, DotTokenWriterOptions o, IDotToken curr, IDotToken? next, ref int level)
        {
            switch ((curr, next))
            {
                case (DotKeyword _, DotKeyword _): // strict graph
                case (DotKeyword _, DotIdentifier _): // graph name
                case (DotKeyword _, DotQuotationStart _): // graph "name"
                    sb.Append(curr.ToString());
                    sb.Append(o.MandatoryTokenSpace());
                    break;

                // multiline items
                case (DotIdentifier _, _):
                case (DotHtmlText _, _):
                    sb.Append(o.String(curr.ToString()));
                    break;

                // increase indentation of block items
                case (DotGraphBlockStart _, _):
                case (DotAttributeCollectionStart _, _):
                case (DotHtmlTextStart _, _):
                    sb.Append(curr.ToString());
                    sb.Append(o.NewLine(++level));
                    break;

                // decrease indentation when block ends
                case (IDotToken _, DotGraphBlockEnd _):
                case (IDotToken _, DotAttributeCollectionEnd _):
                case (IDotToken _, DotHtmlTextEnd _):
                    sb.Append(curr.ToString());
                    sb.Append(o.NewLine(--level));
                    break;

                // statements and attribute list items separated into lines
                case (DotStatementSeparator _, _):
                case (DotAttributeSeparator _, _):
                    sb.Append(curr.ToString());
                    sb.Append(o.NewLine(level));
                    break;

                // no space after quotation mark, before quotation mark and before a semicolon
                case (DotQuotationStart _, _):
                case (_, DotQuotationEnd _):
                case (_, DotStatementSeparator _):
                    sb.Append(curr.ToString());
                    break;

                default:
                    sb.Append(curr.ToString());
                    sb.Append(o.TokenSpace());
                    break;
            }
        }
    }
}
