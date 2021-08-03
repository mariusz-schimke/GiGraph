using GiGraph.Dot.Entities.Html.Font.Attributes;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML &lt;font&gt; element.
    /// </summary>
    public class DotHtmlFont : DotHtmlElement, IDotHtmlFontAttributes
    {
        /// <summary>
        ///     Initializes a new font element instance.
        /// </summary>
        /// <param name="name">
        ///     Specifies the font to use within the scope of the current element.
        /// </param>
        /// <param name="size">
        ///     Specifies the size of the font, in points, to use within the scope of the current element.
        /// </param>
        /// <param name="color">
        ///     Sets the color of the font within the scope of the current element.
        /// </param>
        public DotHtmlFont(string name = null, int? size = null, DotColor color = null)
            : this(new DotHtmlFontAttributes())
        {
            if (name is not null)
            {
                Name = name;
            }

            if (size.HasValue)
            {
                Size = size;
            }

            if (color is not null)
            {
                Color = color;
            }
        }

        protected DotHtmlFont(DotHtmlFontAttributes attributes)
            : base("font", attributes.Collection)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the font.
        /// </summary>
        public new virtual DotHtmlFontAttributes Attributes { get; }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Name" />
        public virtual string Name
        {
            get => ((IDotHtmlFontAttributes) Attributes).Name;
            set => ((IDotHtmlFontAttributes) Attributes).Name = value;
        }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Size" />
        public virtual double? Size
        {
            get => ((IDotHtmlFontAttributes) Attributes).Size;
            set => ((IDotHtmlFontAttributes) Attributes).Size = value;
        }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Color" />
        public virtual DotColor Color
        {
            get => ((IDotHtmlFontAttributes) Attributes).Color;
            set => ((IDotHtmlFontAttributes) Attributes).Color = value;
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="name">
        ///     Font name.
        /// </param>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        public virtual void Set(string name = null, double? size = null, DotColor color = null)
        {
            Size = size;
            Color = color;
            Name = name;
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotFont attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }

        /// <summary>
        ///     Copies font properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotHtmlFontAttributes attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
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
        public static DotHtmlEntity StyleText(string text, string name = null, int? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return StyleEntity(new DotHtmlText(text), name, size, color, style);
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported. See
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
        public static DotHtmlEntity StyleEntity(DotHtmlEntity entity, string name = null, int? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return (DotHtmlEntity) StyleEntity((IDotHtmlEntity) entity, name, size, color, style);
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those). See
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
        public static IDotHtmlEntity StyleEntity(IDotHtmlEntity entity, string name = null, int? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            var result = style.HasValue
                ? DotHtmlFontStyle.StyleEntity(entity, style.Value)
                : entity;

            return name is not null || color is not null || size.HasValue
                ? new DotHtmlFont
                {
                    Name = name,
                    Size = size,
                    Color = color,
                    Children = { result }
                }
                : result;
        }
    }
}