using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Types.Fonts
{
    /// <summary>
    ///     SVG output font conventions.
    /// </summary>
    public enum DotFontConvention
    {
        /// <summary>
        ///     When specified, the output will try to use known SVG font names. For example, the default font, Times-Roman, will be mapped
        ///     to the basic SVG font serif.
        /// </summary>
        [DotAttributeValue("svg")]
        Svg,

        /// <summary>
        ///     When specified, the output will try to use known PostScript font names such as Times-Roman. Useful with SVG viewers that
        ///     support this richer font name space.
        /// </summary>
        [DotAttributeValue("ps")]
        PostScript,

        /// <summary>
        ///     When specified, the output will try to use Fontconfig font conventions. For example, Times-Roman would be treated as Nimbus
        ///     Roman No9 L. Useful with SVG viewers that support this richer font name space.
        /// </summary>
        [DotAttributeValue("hd")]
        Fontconfig
    }
}