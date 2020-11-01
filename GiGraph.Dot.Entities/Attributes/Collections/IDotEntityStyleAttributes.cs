using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEntityStyleAttributes
    {
        /// <summary>
        ///     <para>
        ///         Sets the style of the element (default: unset). See the descriptions of individual <see cref="DotStyles" /> values to
        ///         learn which styles are applicable to this element type.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example: <see cref="Options" /> = <see cref="DotStyles.Rounded" /> |
        ///         <see cref="DotStyles.Bold" />;
        ///     </para>
        /// </summary>
        DotStyles? Options { get; set; }
    }
}