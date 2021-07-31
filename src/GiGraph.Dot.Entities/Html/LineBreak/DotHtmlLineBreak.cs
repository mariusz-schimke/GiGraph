using GiGraph.Dot.Entities.Html.LineBreak.Attributes;
using GiGraph.Dot.Output.Metadata.Html;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html.LineBreak
{
    /// <summary>
    ///     An HTML line break element (&lt;br/&gt;).
    /// </summary>
    public class DotHtmlLineBreak : DotHtmlTag, IDotHtmlLineBreakAttributes
    {
        protected static readonly DotHtmlLineBreak Default = new();

        /// <summary>
        ///     Initializes a new line break instance.
        /// </summary>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of the line.
        /// </param>
        public DotHtmlLineBreak(DotHorizontalAlignment? horizontalAlignment = null)
            : this(new DotHtmlLineBreakAttributes())
        {
            if (horizontalAlignment.HasValue)
            {
                HorizontalAlignment = horizontalAlignment;
            }
        }

        protected DotHtmlLineBreak(DotHtmlLineBreakAttributes attributes)
            : base("br", isVoid: true, attributes.Collection)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the line break element.
        /// </summary>
        public new virtual DotHtmlLineBreakAttributes Attributes { get; }

        /// <summary>
        ///     Returns a &lt;br/&gt; HTML tag string according to the default syntax options and rules.
        /// </summary>
        public static DotHtmlString Html => Default.ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);

        /// <inheritdoc cref="IDotHtmlLineBreakAttributes.HorizontalAlignment" />
        [DotHtmlElementAttributeKey("align")]
        public virtual DotHorizontalAlignment? HorizontalAlignment
        {
            get => ((IDotHtmlLineBreakAttributes) Attributes).HorizontalAlignment;
            set => ((IDotHtmlLineBreakAttributes) Attributes).HorizontalAlignment = value;
        }

        internal static string AsHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Default.ToHtml(options, syntaxRules);
        }
    }
}