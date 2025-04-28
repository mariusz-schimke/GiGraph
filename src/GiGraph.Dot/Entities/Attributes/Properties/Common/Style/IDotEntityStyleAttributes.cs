using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

public interface IDotEntityStyleAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the style of the element (default: unset). See the descriptions of individual <see cref="DotStyles"/> values
    ///         to learn which styles are applicable to this type of element.
    ///     </para>
    ///     <para>
    ///         Multiple styles can be used at once, for example: <see cref="Style"/> = <see cref="DotStyles.Rounded"/> |
    ///         <see cref="DotStyles.Bold"/>;
    ///     </para>
    /// </summary>
    DotStyles? Style { get; set; }
}