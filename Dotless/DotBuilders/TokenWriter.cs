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
            sb.Append(curr.ToString());

            switch (curr)
            {
                case Keyword k1 when next is Keyword:
                case Keyword k2 when next is Identifier:
                    sb.Append(o.MandatoryTokenSpace());
                    break;

                case GraphBlockStart gbs:
                case AttributeBlockStart abs:
                case HtmlBlockStart hbs:
                    sb.Append(o.NewLine(++level));
                    break;

                case IToken t1 when next is GraphBlockEnd:
                case IToken t2 when next is AttributeBlockEnd:
                case IToken t3 when next is HtmlBlockEnd:
                    sb.Append(o.NewLine(--level));
                    break;

                case StatementSeparator ssep:
                case AttributeSeparator asep:
                    sb.Append(o.NewLine(level));
                    break;

                case QuoteStart qs:
                case IToken t1 when next is QuoteEnd:
                case IToken t2 when next is StatementSeparator:
                    break;

                default:
                    sb.Append(o.TokenSpace());
                    break;
            }
        }
    }
}
