using GiGraph.Dot.Entities.Html.LineBreak.Attributes;
using GiGraph.Dot.Output.Metadata.Html;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak
{
    /// <summary>
    ///     An HTML line break element (&lt;br/&gt;).
    /// </summary>
    public class DotHtmlLineBreak : DotHtmlTag, IDotHtmlLineBreakAttributes
    {
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

        /// <inheritdoc cref="IDotHtmlLineBreakAttributes.HorizontalAlignment" />
        [DotHtmlElementAttributeKey("align")]
        public virtual DotHorizontalAlignment? HorizontalAlignment
        {
            get => ((IDotHtmlLineBreakAttributes) Attributes).HorizontalAlignment;
            set => ((IDotHtmlLineBreakAttributes) Attributes).HorizontalAlignment = value;
        }
    }
}