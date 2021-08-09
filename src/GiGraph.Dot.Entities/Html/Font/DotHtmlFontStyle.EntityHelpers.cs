using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.EnumHelpers;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    public partial class DotHtmlFontStyle
    {
        /// <summary>
        ///     Embeds the entities in appropriate HTML tags each, based on the font styles specified for them.
        /// </summary>
        /// <param name="items">
        ///     The HTML entities to style.
        /// </param>
        public static DotHtmlEntity SetStyles(params (IDotHtmlEntity Entity, DotFontStyles Style)[] items)
        {
            return SetStyles((IEnumerable<(IDotHtmlEntity Entity, DotFontStyles Style)>) items);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags each, based on the font styles specified for them.
        /// </summary>
        /// <param name="style">
        ///     The common style to apply to the entities.
        /// </param>
        /// <param name="items">
        ///     The HTML entities to style.
        /// </param>
        public static DotHtmlEntity SetStyles(DotFontStyles style, params (IDotHtmlEntity Entity, DotFontStyles Style)[] items)
        {
            return SetStyles(items, style);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags each, based on the font styles specified for them.
        /// </summary>
        /// <param name="items">
        ///     The HTML entities to style.
        /// </param>
        /// <param name="style">
        ///     The common style to apply to the entities.
        /// </param>
        public static DotHtmlEntity SetStyles(IEnumerable<(IDotHtmlEntity Entity, DotFontStyles Style)> items, DotFontStyles? style = null)
        {
            return SetStyle(
                new DotHtmlEntityCollection(
                    items.Select(item => SetStyle(item.Entity, item.Style))
                ),
                style.GetValueOrDefault(DotFontStyles.Normal)
            );
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font style elements. Only text and table elements are supported (including collections of those). See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the entities.
        /// </param>
        public static DotHtmlEntity SetStyle(IDotHtmlEntity entity, DotFontStyles style)
        {
            var result = FromStyle(style, element => element.SetContent(entity));
            return (DotHtmlEntity) result ?? new DotHtmlEntity<IDotHtmlEntity>(entity);
        }

        /// <summary>
        ///     Creates an appropriate nested structure of HTML tags based on the specified font style. Returns null for the
        ///     <see cref="DotFontStyles.Normal" /> font style.
        /// </summary>
        /// <param name="style">
        ///     The style to apply to the entities.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate (called for the bottom-level element so that content can be added to it).
        /// </param>
        public static DotHtmlFontStyle FromStyle(DotFontStyles style, Action<DotHtmlFontStyle> init)
        {
            var rootElement = FromStyle(style, out var nestedElement);

            if (nestedElement is not null)
            {
                init?.Invoke(nestedElement);
            }

            return rootElement;
        }

        /// <summary>
        ///     Creates an appropriate nested structure of HTML tags based on the specified font style. Returns null for the
        ///     <see cref="DotFontStyles.Normal" /> font style.
        /// </summary>
        /// <param name="style">
        ///     The style to apply to the entities.
        /// </param>
        /// <param name="contentElement">
        ///     The bottom-level element to embed content in.
        /// </param>
        public static DotHtmlFontStyle FromStyle(DotFontStyles style, out DotHtmlFontStyle contentElement)
        {
            DotHtmlFontStyle result = null;
            contentElement = null;

            var metadata = new DotEnumMetadata(style.GetType());
            foreach (var styleFlag in metadata.GetSetFlags(style).Cast<DotFontStyles>())
            {
                DotHtmlFontStyle styleElement = styleFlag switch
                {
                    DotFontStyles.Bold => new DotHtmlBold(),
                    DotFontStyles.Italic => new DotHtmlItalic(),
                    DotFontStyles.Underline => new DotHtmlUnderline(),
                    DotFontStyles.Overline => new DotHtmlOverline(),
                    DotFontStyles.Subscript => new DotHtmlSubscript(),
                    DotFontStyles.Superscript => new DotHtmlSuperscript(),
                    DotFontStyles.Strikethrough => new DotHtmlStrikethrough(),
                    _ => throw new ArgumentOutOfRangeException(nameof(style), styleFlag, "Invalid font style flag")
                };

                contentElement?.Content.Add(styleElement);
                contentElement = styleElement;
                result ??= contentElement;
            }

            return result;
        }
    }
}