using GiGraph.Dot.Entities.Html.Font.Attributes;
using GiGraph.Dot.Types.Colors;

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
        public virtual int? Size
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
    }
}