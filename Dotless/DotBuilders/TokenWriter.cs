using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless.DotBuilders
{
    public class TokenWriter
    {
        private readonly IToken[] _tokens;

        public TokenWriter(ICollection<IToken> tokens)
        {
            _tokens = tokens.ToArray();
        }

        public void Write(StringBuilder sb, TokenWriterOptions options)
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

        protected virtual void HandleTokenPair(StringBuilder sb, TokenWriterOptions o, IToken curr, IToken? next, ref int level)
        {
            switch ((curr, next))
            {
                case (Keyword _, Keyword _): // strict graph
                case (Keyword _, Identifier _): // graph name
                case (Keyword _, QuoteStart _): // graph "name"
                    sb.Append(curr.ToString());
                    sb.Append(o.MandatoryTokenSpace());
                    break;

                // multiline items
                case (Identifier _, _):
                case (Html _, _):
                    sb.Append(o.String(curr.ToString()));
                    break;

                // increase indentation of block items
                case (GraphBlockStart _, _):
                case (AttributeBlockStart _, _):
                case (HtmlBlockStart _, _):
                    sb.Append(curr.ToString());
                    sb.Append(o.NewLine(++level));
                    break;

                // statements and attribute list items separated into lines
                case (StatementSeparator _, _):
                case (AttributeSeparator _, _):
                    sb.Append(curr.ToString());
                    sb.Append(o.NewLine(level));
                    break;

                // no space after quotation mark, before quotation mark and before a semicolon
                case (QuoteStart _, _):
                case (_, QuoteEnd _):
                case (_, StatementSeparator _):
                    sb.Append(curr.ToString());
                    break;

                // decrease indentation when block ends
                case (IToken _, GraphBlockEnd _):
                case (IToken _, AttributeBlockEnd _):
                case (IToken _, HtmlBlockEnd _):
                    sb.Append(curr.ToString());
                    sb.Append(o.NewLine(--level));
                    break;

                default:
                    sb.Append(curr.ToString());
                    sb.Append(o.TokenSpace());
                    break;
            }
        }
    }
}
