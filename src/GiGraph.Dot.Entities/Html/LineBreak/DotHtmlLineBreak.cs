using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.LineBreak.Attributes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Html.LineBreak
{
    /// <summary>
    ///     An HTML line break element (&lt;br/&gt;).
    /// </summary>
    public partial class DotHtmlLineBreak : DotHtmlVoidElement
    {
        protected static readonly DotHtmlEntity Default = new DotHtmlReadOnlyEntity<DotHtmlLineBreak>(new DotHtmlLineBreak());
        protected static readonly Dictionary<DotHorizontalAlignment, DotHtmlEntity> AlignedLineBreaks;

        static DotHtmlLineBreak()
        {
            AlignedLineBreaks = Enum.GetValues(typeof(DotHorizontalAlignment))
               .Cast<DotHorizontalAlignment>()
               .ToDictionary(
                    key => key,
                    value => (DotHtmlEntity) new DotHtmlReadOnlyEntity<DotHtmlLineBreak>(new DotHtmlLineBreak(value))
                );
        }

        /// <summary>
        ///     Initializes a new line break instance.
        /// </summary>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of the line.
        /// </param>
        public DotHtmlLineBreak(DotHorizontalAlignment? lineAlignment = null)
            : this(new DotHtmlAttributeCollection())
        {
            if (lineAlignment.HasValue)
            {
                LineAlignment = lineAlignment;
            }
        }

        protected DotHtmlLineBreak(DotHtmlAttributeCollection attributes)
            : this(new DotHtmlLineBreakAttributes(attributes))
        {
        }

        protected DotHtmlLineBreak(DotHtmlLineBreakAttributes attributes)
            : base("br", attributes.Collection)
        {
            Attributes = new DotHtmlElementRootAttributesAccessor<IDotHtmlLineBreakAttributes, DotHtmlLineBreakAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the line break element.
        /// </summary>
        public new DotHtmlElementRootAttributesAccessor<IDotHtmlLineBreakAttributes, DotHtmlLineBreakAttributes> Attributes { get; }

        /// <summary>
        ///     Returns a &lt;br/&gt; HTML tag string according to the default syntax options and rules.
        /// </summary>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of the line.
        /// </param>
        public static DotHtmlString Html(DotHorizontalAlignment? lineAlignment = null)
        {
            return Html(lineAlignment, DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }

        internal static string Html(DotHorizontalAlignment? lineAlignment, DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Instance(lineAlignment).ToHtml(options, syntaxRules);
        }

        /// <summary>
        ///     Gets a static instance of a line break with the specified alignment. Use for memory optimization.
        /// </summary>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of the line.
        /// </param>
        public static DotHtmlEntity Instance(DotHorizontalAlignment? lineAlignment = null)
        {
            if (lineAlignment.HasValue)
            {
                return AlignedLineBreaks.TryGetValue(lineAlignment.Value, out var result)
                    ? result
                    : throw new ArgumentException($"The specified HTML line break alignment '{lineAlignment}' is invalid.", nameof(lineAlignment));
            }

            return Default;
        }
    }
}