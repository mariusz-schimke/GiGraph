using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public interface IDotClusterAttributes : IDotGraphClusterCommonAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the style of the cluster (default: unset). See the descriptions of individual <see cref="DotStyles" />
        ///         values to learn which styles are applicable to this type of element.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example: <see cref="Style" /> = <see cref="DotStyles.Rounded" /> |
        ///         <see cref="DotStyles.Bold" />;
        ///     </para>
        /// </summary>
        DotStyles? Style { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the cluster. It may be plain text (<see cref="string" />) or HTML (
        ///         <see cref="DotHtmlLabel" />). See also <see cref="DotTextFormatter" /> for plain text label formatting if needed.
        ///     </para>
        ///     <para>
        ///         Examples:
        ///         <list type="bullet">
        ///             <item>
        ///                 <description>
        ///                     <see cref="Label" /> = "My label";
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     <see cref="Label" /> = new <see cref="DotHtmlLabel" />("&lt;TABLE&gt;...&lt;/TABLE&gt;");
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the cluster (svg, cmap only). If unset, Graphviz will use the <see cref="Label" /> attribute
        ///     if defined.
        /// </summary>
        DotEscapeString Tooltip { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the background color of the cluster (default: none). Used as the initial background for the cluster. If the
        ///         <see cref="DotClusterFillStyle.Normal" /> fill style is used for the cluster, its
        ///         <see cref="IDotGraphClusterCommonAttributes.FillColor" /> will overlay the background color.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; applying
        ///         the <see cref="DotClusterFillStyle.Radial" /> fill style to the cluster will cause a radial fill. If the second color is
        ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the <see cref="GradientAngle" />
        ///         attribute for setting a gradient angle.
        ///     </para>
        /// </summary>
        DotColorDefinition BackgroundColor { get; set; }

        /// <summary>
        ///     Specifies a color scheme namespace to use. If defined, specifies the context for interpreting color names. If no color scheme
        ///     is set, the standard <see cref="DotColorSchemes.X11" /> naming is used. For example, if
        ///     <see cref="DotColorSchemes.DotBrewerColorSchemes.BuGn9" /> Brewer color scheme is used, then a color named "7", e.g.
        ///     Color.FromName("7"), will be evaluated in the context of that specific color scheme. See <see cref="DotColorSchemes" /> for
        ///     supported scheme names.
        /// </summary>
        string ColorScheme { get; set; }

        /// <summary>
        ///     If a gradient fill is being used, this determines the angle of the fill. For linear fills, the colors transform along a line
        ///     specified by the angle and the center of the object. For radial fills, a value of zero causes the colors to transform
        ///     radially from the center; for non-zero values, the colors transform from a point near the object's periphery as specified by
        ///     the value. If unset, the default angle is 0.
        /// </summary>
        int? GradientAngle { get; set; }

        /// <summary>
        ///     Sets the number of peripheries used in cluster boundaries (default: 1, minimum: 0, maximum: 1). Setting peripheries to 0 will
        ///     remove the boundaries.
        /// </summary>
        int? Peripheries { get; set; }

        /// <summary>
        ///     Specifies the space between the nodes in the cluster and bounding box of the cluster. By default, this is 8 points.
        /// </summary>
        DotPoint Padding { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the cluster (default: 0). If <see cref="DotGraphAttributes.PackingMode" /> indicates an
        ///     array packing, this attribute specifies an insertion order among the components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }

        /// <summary>
        ///     <para>
        ///         Allows the graph author to provide an identifier for graph objects which is to be included in the output (svg,
        ///         postscript, map only).
        ///     </para>
        ///     <para>
        ///         Normal <see cref="DotEscapeString.NodeId" />, <see cref="DotEscapeString.EdgeDefinition" />,
        ///         <see cref="DotEscapeString.GraphId" /> substitutions can be applied (see <see cref="DotTextFormatter" />). Note, however,
        ///         that <see cref="DotEscapeString.EdgeDefinition" /> does not provide a unique ID for multi-edges.
        ///     </para>
        ///     <para>
        ///         If provided, it is the responsibility of the provider to keep ID values unique for its intended downstream use. If no ID
        ///         attribute is provided, then a unique internal ID is used. However, this value is unpredictable by the graph writer.
        ///     </para>
        ///     <para>
        ///         If the graph provides an ID attribute, this will be used as a prefix for internally generated attributes. By making
        ///         internally-used attributes distinct, the user can include multiple image maps in the same document.
        ///     </para>
        /// </summary>
        DotEscapeString Id { get; set; }
    }
}