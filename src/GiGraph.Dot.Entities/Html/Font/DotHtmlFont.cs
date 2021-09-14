using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Font.Attributes;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML &lt;font&gt; element. Supports <see cref="DotHtmlTable" />, text and text styling elements as the content.
    /// </summary>
    public partial class DotHtmlFont : DotHtmlElement, IDotHtmlFontAttributes
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
        public DotHtmlFont(string name = null, double? size = null, DotColor color = null)
            : this(new DotHtmlAttributeCollection())
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

        /// <summary>
        ///     Initializes a new font element instance.
        /// </summary>
        /// <param name="font">
        ///     The font to set.
        /// </param>
        public DotHtmlFont(DotFont font)
            : this(font.Name, font.Size, font.Color)
        {
        }

        /// <summary>
        ///     Initializes a new font element instance.
        /// </summary>
        /// <param name="source">
        ///     The font to set.
        /// </param>
        public DotHtmlFont(IDotHtmlFontAttributes source)
            : this(source.Name, source.Size, source.Color)
        {
        }

        private DotHtmlFont(DotHtmlAttributeCollection attributes)
            : this(new DotHtmlFontAttributes(attributes))
        {
        }

        private DotHtmlFont(DotHtmlFontAttributes attributes)
            : base("font", attributes.Collection)
        {
            Attributes = new DotHtmlElementRootAttributes<IDotHtmlFontAttributes, DotHtmlFontAttributes>(attributes);
        }

        /// <summary>
        ///     The attributes of the font.
        /// </summary>
        public new virtual DotHtmlElementRootAttributes<IDotHtmlFontAttributes, DotHtmlFontAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Name" />
        public virtual string Name
        {
            get => Attributes.Implementation.Name;
            set => Attributes.Implementation.Name = value;
        }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Size" />
        public virtual double? Size
        {
            get => Attributes.Implementation.Size;
            set => Attributes.Implementation.Size = value;
        }

        /// <inheritdoc cref="IDotHtmlFontAttributes.Color" />
        public virtual DotColor Color
        {
            get => Attributes.Implementation.Color;
            set => Attributes.Implementation.Color = value;
        }

        /// <summary>
        ///     Sets font attributes.
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
        ///     Sets font attributes.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to set.
        /// </param>
        public virtual void Set(DotFont attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }

        /// <summary>
        ///     Copies font attributes from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the attributes from.
        /// </param>
        public virtual void Set(IDotHtmlFontAttributes attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }

        /// <summary>
        ///     Creates an appropriate nested structure of HTML tags based on the specified font and style.
        /// </summary>
        /// <param name="font">
        ///     The font and/or style to apply.
        /// </param>
        /// <param name="contentElement">
        ///     The bottom-level element to embed content in.
        /// </param>
        public static DotHtmlFont FromStyledFont(DotStyledFont font, out DotHtmlElement contentElement)
        {
            var fontElement = new DotHtmlFont(font);
            contentElement = fontElement;

            if (font.Style.HasValue && DotHtmlFontStyle.FromStyle(font.Style.Value, out var styleContentElement) is { } styleRoot)
            {
                fontElement.SetContent(styleRoot);
                contentElement = styleContentElement;
            }

            return fontElement;
        }
    }
}