using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    public partial class DotHtmlFont
    {
        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
        ///     See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(IDotHtmlEntity entity, DotStyledFont font)
        {
            return SetFont(entity, font.Name, font.Size, font.Color, font.Style);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The entities to style.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        public static DotHtmlEntity SetFont(IEnumerable<(IDotHtmlEntity Entity, DotFontStyles Style)> items, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return SetFont(DotHtmlFontStyle.SetStyles(items), name, size, color, style);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The entities to style.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(DotStyledFont font, params (IDotHtmlEntity Entity, DotFontStyles Style)[] items)
        {
            return SetFont(items, font);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The entities to style.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(IEnumerable<(IDotHtmlEntity Entity, DotFontStyles Style)> items, DotStyledFont font)
        {
            return SetFont(DotHtmlFontStyle.SetStyles(items), font);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The entities to style.
        /// </param>
        public static DotHtmlEntityCollection SetFonts(params (IDotHtmlEntity Entity, DotStyledFont Font)[] items)
        {
            return SetFonts((IEnumerable<(IDotHtmlEntity Entity, DotStyledFont Font)>) items);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="font">
        ///     The common font to apply to all specified entities.
        /// </param>
        /// <param name="items">
        ///     The entities to style.
        /// </param>
        public static DotHtmlEntity SetFonts(DotStyledFont font, params (IDotHtmlEntity Entity, DotStyledFont Font)[] items)
        {
            return SetFonts(items, font);
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The entities to style.
        /// </param>
        public static DotHtmlEntityCollection SetFonts(IEnumerable<(IDotHtmlEntity Entity, DotStyledFont Font)> items)
        {
            return new DotHtmlEntityCollection(
                items.Select(item => SetFont(item.Entity, item.Font))
            );
        }

        /// <summary>
        ///     Embeds the entities in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The entities to style.
        /// </param>
        /// <param name="font">
        ///     The common font to apply to all specified entities.
        /// </param>
        public static DotHtmlEntity SetFonts(IEnumerable<(IDotHtmlEntity Entity, DotStyledFont Font)> items, DotStyledFont font)
        {
            return SetFont(SetFonts(items), font);
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
        ///     See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        public static DotHtmlEntity SetFont(IDotHtmlEntity entity, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            var result = style.HasValue
                ? DotHtmlFontStyle.SetStyle(entity, style.Value)
                : entity;

            result = name is not null || color is not null || size.HasValue
                ? new DotHtmlFont
                {
                    Name = name,
                    Size = size,
                    Color = color,
                    Children = { result }
                }
                : result;

            return new DotHtmlEntity<IDotHtmlEntity>(result);
        }
    }
}