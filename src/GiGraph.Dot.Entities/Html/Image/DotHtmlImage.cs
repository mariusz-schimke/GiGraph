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
        ///     Initializes a new image element instance.
        /// </summary>
        /// <param name="source">
        ///     Specifies the image file to be displayed in the cell.
        /// </param>
        /// <param name="scaling">
        ///     Specifies how the image will use any extra space available in its cell.
        /// </param>
        public DotHtmlImage(string source, DotImageScaling? scaling = null)
            : this(new DotHtmlImageAttributes())
        {
            Source = source;

            if (scaling.HasValue)
            {
                Scaling = scaling;
            }
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