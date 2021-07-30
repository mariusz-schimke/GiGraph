using GiGraph.Dot.Entities.Html.Image.Attributes;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image
{
    /// <summary>
    ///     An HTML &lt;img&gt; element.
    /// </summary>
    public class DotHtmlImage : DotHtmlElement, IDotHtmlImageAttributes
    {
        /// <summary>
        ///     Initializes a new font element instance.
        /// </summary>
        public DotHtmlImage()
            : this(new DotHtmlImageAttributes())
        {
        }

        protected DotHtmlImage(DotHtmlImageAttributes attributes)
            : base("img", attributes.Collection)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the font.
        /// </summary>
        public new virtual DotHtmlImageAttributes Attributes { get; }

        /// <inheritdoc cref="IDotHtmlImageAttributes.Source" />
        public virtual string Source
        {
            get => ((IDotHtmlImageAttributes) Attributes).Source;
            set => ((IDotHtmlImageAttributes) Attributes).Source = value;
        }

        /// <inheritdoc cref="IDotHtmlImageAttributes.Scaling" />
        public virtual DotImageScaling? Scaling
        {
            get => ((IDotHtmlImageAttributes) Attributes).Scaling;
            set => ((IDotHtmlImageAttributes) Attributes).Scaling = value;
        }
    }
}