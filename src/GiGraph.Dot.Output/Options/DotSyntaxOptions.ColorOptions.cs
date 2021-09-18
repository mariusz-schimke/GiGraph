using System.Drawing;

namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxOptions
    {
        public class ColorOptions
        {
            /// <summary>
            ///     When true, <see cref="Color.Name" /> is always used instead of the actual color value. Note that not all known colors
            ///     recognized by the <see cref="Color" /> class are supported by DOT visualization tools, and even if they are, they may differ
            ///     is some cases by the actual colors they represent. What's more, some color names may have different interpretations depending
            ///     on the color scheme used for the graph. If you want to be sure a color is interpreted exactly the way it is provided by the
            ///     <see cref="Color" /> instance, set the current property to false, in which case the actual color value will always be used
            ///     instead of its name.
            /// </summary>
            public bool PreferName { get; set; } = true;
        }
    }
}