using Dotless.DotBuilders.Tokens;
using System.Collections.Generic;

namespace Dotless.DotBuilders
{
    public static class DotTokenCollectionExtension
    {
        public static void Keyword(this ICollection<IDotToken> @this, string keyword)
        {
            @this.Add(new DotKeyword(keyword));
        }

        public static void Identifier(this ICollection<IDotToken> @this, string name)
        {
            @this.Add(new DotIdentifier(name));
        }

        public static void QuotedIdentifier(this ICollection<IDotToken> @this, string name)
        {
            @this.QuotationStart();
            @this.Identifier(name);
            @this.QuotationEnd();
        }

        public static void GraphBlockStart(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotGraphBlockStart());
        }

        public static void GraphBlockEnd(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotGraphBlockEnd());
        }

        public static void HtmlText(this ICollection<IDotToken> @this, string html)
        {
            @this.Add(new DotHtmlText(html));
        }

        public static void BracedHtmlText(this ICollection<IDotToken> @this, string html)
        {
            @this.HtmlTextStart();
            @this.HtmlText(html);
            @this.HtmlTextEnd();
        }

        public static void HtmlTextStart(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotHtmlTextStart());
        }

        public static void HtmlTextEnd(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotHtmlTextEnd());
        }

        public static void AttributeKey(this ICollection<IDotToken> @this, string name)
        {
            @this.Add(new DotAttributeKey(name));
        }

        public static void AttributeCollectionStart(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotAttributeCollectionStart());
        }

        public static void AttributeCollectionEnd(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotAttributeCollectionEnd());
        }

        public static void AttributeSeparator(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotAttributeSeparator());
        }

        public static void NodePort(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotNodePort());
        }

        public static void Text(this ICollection<IDotToken> @this, string text)
        {
            @this.Add(new DotText(text));
        }

        public static void QuotedText(this ICollection<IDotToken> @this, string text)
        {
            @this.QuotationStart();
            @this.Text(text);
            @this.QuotationEnd();
        }

        public static void QuotationStart(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotQuotationStart());
        }

        public static void QuotationEnd(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotQuotationEnd());
        }

        public static void StatementSeparator(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotStatementSeparator());
        }

        public static void AssignmentOperator(this ICollection<IDotToken> @this)
        {
            @this.Add(new DotAssignmentOperator());
        }
    }
}
