using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Image.Attributes;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image
{
    /// <summary>
    ///     An HTML &lt;img&gt; element.
    /// </summary>
    public class DotHtmlImage : DotHtmlVoidElement, IDotHtmlImageAttributes
    {
        /// <summary>
        ///     Initializes a new image element instance.
        /// </summary>
        /// <param name="source">
        ///     Specifies the image file to be displayed.
        /// </param>
        /// <param name="scaling">
        ///     Specifies how the image will use any extra space available in its cell.
        /// </param>
        public DotHtmlImage(string source, DotImageScaling? scaling = null)
            : this(new DotHtmlAttributeCollection())
        {
            Source = source;

            if (scaling.HasValue)
            {
                Scaling = scaling;
            }
        }

        private DotHtmlImage(DotHtmlAttributeCollection attributes)
            : this(new DotHtmlImageAttributes(attributes))
        {
        }

        private DotHtmlImage(DotHtmlImageAttributes attributes)
            : base("img", attributes.Collection)
        {
            Attributes = new DotHtmlElementRootAttributesAccessor<IDotHtmlImageAttributes, DotHtmlImageAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the image.
        /// </summary>
        public new DotHtmlElementRootAttributesAccessor<IDotHtmlImageAttributes, DotHtmlImageAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotHtmlImageAttributes.Source" />
        public virtual string Source
        {
            get => Attributes.Implementation.Source;
            set => Attributes.Implementation.Source = value;
        }

        /// <inheritdoc cref="IDotHtmlImageAttributes.Scaling" />
        public virtual DotImageScaling? Scaling
        {
            get => Attributes.Implementation.Scaling;
            set => Attributes.Implementation.Scaling = value;
        }
    }
}