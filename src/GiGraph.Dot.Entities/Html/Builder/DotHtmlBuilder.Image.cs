using System;
using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends an image.
        /// </summary>
        /// <param name="source">
        ///     Specifies the image file to be displayed.
        /// </param>
        /// <param name="scaling">
        ///     Specifies how the image will use any extra space available in its cell.
        /// </param>
        /// <param name="init">
        ///     An optional image initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendImage(string source, DotImageScaling? scaling = null, Action<DotHtmlImage> init = null)
        {
            return Append(new DotHtmlImage(source, scaling), init);
        }
    }
}