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
        public DotHtmlFont()
            : this(new DotHtmlFontAttributes())
        {
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