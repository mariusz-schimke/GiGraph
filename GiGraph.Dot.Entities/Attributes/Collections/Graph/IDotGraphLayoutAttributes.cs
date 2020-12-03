using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.LayoutEngines;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphLayoutAttributes
    {
        /// <summary>
        ///     <para>
        ///         Specifies the name of the layout algorithm to use, such as dot or neato (see <see cref="DotLayoutEngines" /> for a list
        ///         of available layout engines).
        ///     </para>
        ///     <para>
        ///         Normally, graphs should be kept independent of a type of layout. In some cases, however, it can be convenient to embed
        ///         the type of layout desired within the graph. For example, a graph containing position information from a layout might
        ///         want to record what the associated layout algorithm was. This attribute takes precedence over the -K flag or the actual
        ///         command name used.
        ///     </para>
        /// </summary>
        string Engine { get; set; }

        /// <summary>
        ///     Gets or sets the direction of graph layout (dot only, default: <see cref="DotLayoutDirection.TopToBottom" />).
        /// </summary>
        DotLayoutDirection? Direction { get; set; }
    }
}