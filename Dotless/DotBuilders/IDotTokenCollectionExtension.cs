using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.DotBuilders
{
    public static class IDotTokenCollectionExtension
    {
        public static ICollection<IDotToken> Token(this ICollection<IDotToken> collection, IDotToken token)
        {
            collection.Add(token);
            return collection;
        }

        public static ICollection<IDotToken> Tokens(this ICollection<IDotToken> @this, ICollection<IDotToken> tokens)
        {
            foreach (var token in tokens)
            {
                @this.Add(token);
            }

            return @this;
        }

        public static ICollection<IDotToken> Keyword(this ICollection<IDotToken> @this, string keyword)
        {
            return @this.Token(new DotKeyword(keyword));
        }

        public static ICollection<IDotToken> Identifier(this ICollection<IDotToken> @this, string name)
        {
            return @this.Token(new DotIdentifier(name));
        }

        public static ICollection<IDotToken> QuotedIdentifier(this ICollection<IDotToken> @this, string name)
        {
            return @this
                .QuotationStart()
                .Identifier(name)
                .QuotationEnd();
        }

        public static ICollection<IDotToken> GraphBlockStart(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotGraphBlockStart());
        }

        public static ICollection<IDotToken> GraphBlockEnd(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotGraphBlockEnd());
        }

        public static ICollection<IDotToken> HtmlText(this ICollection<IDotToken> @this, string html)
        {
            return @this.Token(new DotHtmlText(html));
        }

        public static ICollection<IDotToken> BracedHtmlText(this ICollection<IDotToken> @this, string html)
        {
            return @this.HtmlTextStart()
                .HtmlText(html)
                .HtmlTextEnd();
        }

        public static ICollection<IDotToken> HtmlTextStart(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotHtmlTextStart());
        }

        public static ICollection<IDotToken> HtmlTextEnd(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotHtmlTextEnd());
        }

        public static ICollection<IDotToken> AttributeKey(this ICollection<IDotToken> @this, string name)
        {
            return @this.Token(new DotAttributeKey(name));
        }

        public static ICollection<IDotToken> AttributeCollectionStart(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotAttributeCollectionStart());
        }

        public static ICollection<IDotToken> AttributeCollectionEnd(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotAttributeCollectionEnd());
        }

        public static ICollection<IDotToken> AttributeSeparator(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotAttributeSeparator());
        }

        public static ICollection<IDotToken> NodePort(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotNodePort());
        }

        public static ICollection<IDotToken> Text(this ICollection<IDotToken> @this, string text)
        {
            return @this.Token(new DotText(text));
        }

        public static ICollection<IDotToken> QuotedText(this ICollection<IDotToken> @this, string text)
        {
            return @this
                .QuotationStart()
                .Text(text)
                .QuotationEnd();
        }

        public static ICollection<IDotToken> QuotationStart(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotQuotationStart());
        }

        public static ICollection<IDotToken> QuotationEnd(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotQuotationEnd());
        }

        public static ICollection<IDotToken> StatementSeparator(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotStatementSeparator());
        }

        public static ICollection<IDotToken> AssignmentOperator(this ICollection<IDotToken> @this)
        {
            return @this.Token(new DotAssignmentOperator());
        }
    }
}
