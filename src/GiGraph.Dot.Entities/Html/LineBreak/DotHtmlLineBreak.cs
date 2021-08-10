using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.LineBreak.Attributes;
using GiGraph.Dot.Output.Metadata.Html;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Html.LineBreak
{
    /// <summary>
    ///     An HTML line break element (&lt;br/&gt;).
    /// </summary>
    public class DotHtmlLineBreak : DotHtmlVoidElement, IDotHtmlLineBreakAttributes
    {
        protected static readonly DotHtmlLineBreak Default = new();
        protected static readonly Dictionary<DotHorizontalAlignment, DotHtmlLineBreak> AlignedLineBreaks;

        static DotHtmlLineBreak()
        {
            AlignedLineBreaks = Enum.GetValues(typeof(DotHorizontalAlignment))
               .Cast<DotHorizontalAlignment>()
               .ToDictionary(
                    key => key,
                    value => new DotHtmlLineBreak(value)
                );
        }

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
            : base("br", attributes.Collection)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the line break element.
        /// </summary>
        public new virtual DotHtmlLineBreakAttributes Attributes { get; }

        /// <inheritdoc cref="IDotHtmlLineBreakAttributes.HorizontalAlignment" />
        [DotHtmlAttributeKey("align")]
        public virtual DotHorizontalAlignment? HorizontalAlignment
        {
            get => ((IDotHtmlLineBreakAttributes) Attributes).HorizontalAlignment;
            set => ((IDotHtmlLineBreakAttributes) Attributes).HorizontalAlignment = value;
        }

        /// <summary>
        ///     Returns a &lt;br/&gt; HTML tag string according to the default syntax options and rules.
        /// </summary>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of the line.
        /// </param>
        public static DotHtmlString Html(DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Html(horizontalAlignment, DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }

        internal static string Html(DotHorizontalAlignment? horizontalAlignment, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return (horizontalAlignment.HasValue ? AlignedLineBreaks[horizontalAlignment.Value] : Default)
               .ToHtml(options, syntaxRules);
        }
    }
}