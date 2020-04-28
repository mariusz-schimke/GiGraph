using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.DotBuilders
{
    public static class TokenCollectionExtension
    {
        public static void Keyword(this ICollection<IToken> @this, string keyword)
        {
            @this.Add(new Keyword(keyword));
        }

        public static void Identifier(this ICollection<IToken> @this, string name)
        {
            @this.Add(new Identifier(name));
        }

        public static void QuotedIdentifier(this ICollection<IToken> @this, string name)
        {
            @this.QuoteStart();
            @this.Identifier(name);
            @this.QuoteEnd();
        }

        public static void GraphBlockStart(this ICollection<IToken> @this)
        {
            @this.Add(new GraphBlockStart());
        }

        public static void GraphBlockEnd(this ICollection<IToken> @this)
        {
            @this.Add(new GraphBlockEnd());
        }

        public static void Html(this ICollection<IToken> @this, string html)
        {
            @this.Add(new Html(html));
        }

        public static void HtmlBlock(this ICollection<IToken> @this, string html)
        {
            @this.HtmlBlockStart();
            @this.Html(html);
            @this.HtmlBlockEnd();
        }

        public static void HtmlBlockStart(this ICollection<IToken> @this)
        {
            @this.Add(new HtmlBlockStart());
        }

        public static void HtmlBlockEnd(this ICollection<IToken> @this)
        {
            @this.Add(new HtmlBlockEnd());
        }

        public static void AttributeKey(this ICollection<IToken> @this, string name)
        {
            @this.Add(new AttributeKey(name));
        }

        public static void AttributeBlockStart(this ICollection<IToken> @this)
        {
            @this.Add(new AttributeBlockStart());
        }

        public static void AttributeBlockEnd(this ICollection<IToken> @this)
        {
            @this.Add(new AttributeBlockEnd());
        }

        public static void AttributeSeparator(this ICollection<IToken> @this)
        {
            @this.Add(new AttributeSeparator());
        }

        public static void NodePort(this ICollection<IToken> @this)
        {
            @this.Add(new NodePort());
        }

        public static void Text(this ICollection<IToken> @this, string text)
        {
            @this.Add(new Text(text));
        }

        public static void QuotedText(this ICollection<IToken> @this, string text)
        {
            @this.QuoteStart();
            @this.Text(text);
            @this.QuoteEnd();
        }

        public static void QuoteStart(this ICollection<IToken> @this)
        {
            @this.Add(new QuoteStart());
        }

        public static void QuoteEnd(this ICollection<IToken> @this)
        {
            @this.Add(new QuoteEnd());
        }

        public static void StatementSeparator(this ICollection<IToken> @this)
        {
            @this.Add(new StatementSeparator());
        }

        public static void AssignmentOperator(this ICollection<IToken> @this)
        {
            @this.Add(new AssignmentOperator());
        }
    }
}
