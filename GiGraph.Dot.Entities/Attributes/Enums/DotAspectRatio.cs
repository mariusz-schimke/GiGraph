using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Graph;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The graph aspect ratio (drawing height/drawing width) for the drawing.
    /// </summary>
    public enum DotAspectRatio
    {
        /// <summary>
        ///     If the graph page attribute is set and the graph cannot be drawn on a single page, then
        ///     <see cref="IDotGraphAttributes.Size" /> is set to an "ideal" value. In particular, the size in a given dimension will be the
        ///     smallest integral multiple of the page size in that dimension which is at least half the current size. The two dimensions are
        ///     then scaled independently to the new size. This feature only works in dot.
        /// </summary>
        Auto,

        /// <summary>
        ///     If the <see cref="IDotGraphAttributes.Size" /> attribute is set on the graph, node positions are scaled, separately in both x
        ///     and y, so that the final drawing exactly fills the specified size. If both <see cref="IDotGraphAttributes.Size" /> values
        ///     exceed the width and height of the drawing, then both coordinate values of each node are scaled up accordingly. However, if
        ///     either size dimension is smaller than the corresponding dimension in the drawing, one dimension is scaled up so that the
        ///     final drawing has the same aspect ratio as specified by <see cref="IDotGraphAttributes.Size" />. Then, when rendered, the
        ///     layout will be scaled down uniformly in both dimensions to fit the given <see cref="IDotGraphAttributes.Size" />, which may
        ///     cause nodes and text to shrink as well. This may not be what the user wants, but it avoids the hard problem of how to
        ///     reposition the nodes in an acceptable fashion to reduce the drawing size.
        /// </summary>
        Fill,

        /// <summary>
        ///     If the <see cref="IDotGraphAttributes.Size" /> attribute is set on the graph, dot attempts to compress the initial layout to
        ///     fit in the given size. This achieves a tighter packing of nodes but reduces the balance and symmetry. This feature only works
        ///     in dot.
        /// </summary>
        Compress,

        /// <summary>
        ///     If the <see cref="IDotGraphAttributes.Size" /> attribute is set on the graph, and both the width and the height of the graph
        ///     are less than the value in <see cref="IDotGraphAttributes.Size" />, node positions are scaled uniformly until at least one
        ///     dimension fits <see cref="IDotGraphAttributes.Size" /> exactly. Note that this is distinct from using
        ///     <see cref="IDotGraphAttributes.Size" /> as the desired size, as here the drawing is expanded before edges are generated and
        ///     all node and text sizes remain unchanged.
        /// </summary>
        Expand
    }
}