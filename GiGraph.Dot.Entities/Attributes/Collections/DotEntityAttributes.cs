using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityAttributes : DotCommonAttributeCollection,
        IDotGraphAttributes,
        IDotSubgraphAttributes,
        IDotClusterAttributes,
        IDotNodeAttributes,
        IDotEdgeAttributes
    {
        /// <summary>
        /// Gets or sets the color of the element.
        /// </summary>
        public virtual Color? Color
        {
            get => TryGetValueAs<Color>("color", out var result) ? result : (Color?)null;
            set => AddOrRemove("color", value, v => new DotColorAttribute("color", v.Value));
        }

        /// <summary>
        /// Gets or sets the background color of the element.
        /// </summary>
        public virtual Color? BackgroundColor
        {
            get => TryGetValueAs<Color>("bgcolor", out var result) ? result : (Color?)null;
            set => AddOrRemove("bgcolor", value, v => new DotColorAttribute("bgcolor", v.Value));
        }

        /// <summary>
        /// Gets or sets the color used to fill the background of a node or cluster, assuming that <see cref="Style"/> is <see cref="DotStyle.Filled"/>,
        /// or a filled arrowhead. If <see cref="FillColor"/> is not defined, <see cref="Color"/> is used. 
        /// For clusters, if <see cref="Color"/> is not defined, <see cref="BackgroundColor"/> is used.)
        /// If it is not defined too, the default is used, except for <see cref="Shape"/> of <see cref="DotShape.Point"/>,
        /// or when the output format is MIF, which use black by default.
        /// <para>
        ///     If the value is a color list, a gradient fill is used. By default, this is a linear fill; 
        ///     setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        ///     At present, only two colors are used. If the second color is missing, the default color is used for it.
        ///     See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        ///     Note that a cluster inherits the root graph's attributes if defined. 
        ///     Thus, if the root graph has defined a fillcolor, this will override a 
        ///     <see cref="Color"/> or <see cref="BackgroundColor"/> attribute set for the cluster.
        /// </para>
        /// </summary>
        public virtual Color? FillColor
        {
            get => TryGetValueAs<Color>("fillcolor", out var result) ? result : (Color?)null;
            set => AddOrRemove("fillcolor", value, v => new DotColorAttribute("fillcolor", v.Value));
        }

        public virtual int? GradientAngle
        {
            get => TryGetAs<DotIntAttribute>("gradientangle", out var result) ? result.Value : (int?)null;
            set => AddOrRemove("gradientangle", value, v => new DotIntAttribute("gradientangle", v.Value));
        }

        /// <summary>
        /// Gets or sets the label to display on the element.
        /// </summary>
        public virtual string Label
        {
            get => TryGetAs<DotStringAttribute>("label", out var result) ? result.Value : null;
            set => AddOrRemove("label", value, v => new DotStringAttribute("label", v));
        }

        /// <summary>
        /// Gets or sets the label in HTML format to display on the element.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        public virtual string LabelHtml
        {
            get => TryGetAs<DotHtmlAttribute>("label", out var result) ? result.Value : null;
            set => AddOrRemove("label", value, v => new DotHtmlAttribute("label", v));
        }

        public virtual DotShape? Shape
        {
            get => TryGetValueAs<DotShape>("shape", out var result) ? result : (DotShape?)null;
            set => AddOrRemove("shape", value, v => new DotShapeAttribute("shape", v.Value));
        }

        public virtual DotStyle? Style
        {
            get => TryGetAs<DotStyleAttribute>("style", out var result) ? result.Value : (DotStyle?)null;
            set => AddOrRemove("style", value, v => new DotStyleAttribute("style", v.Value));
        }

        public virtual double? ArrowSize
        {
            get => TryGetAs<DotDoubleAttribute>("arrowsize", out var result) ? result.Value : (double?)null;
            set => AddOrRemove("arrowsize", value, v => new DotDoubleAttribute("arrowsize", v.Value));
        }

        public virtual DotArrowType? ArrowHead
        {
            get => TryGetAs<DotArrowTypeAttribute>("arrowhead", out var result) ? result.Value : (DotArrowType?)null;
            set => AddOrRemove("arrowhead", value, v => new DotArrowTypeAttribute("arrowhead", v.Value));
        }

        public virtual DotArrowType? ArrowTail
        {
            get => TryGetAs<DotArrowTypeAttribute>("arrowtail", out var result) ? result.Value : (DotArrowType?)null;
            set => AddOrRemove("arrowtail", value, v => new DotArrowTypeAttribute("arrowtail", v.Value));
        }
        public virtual DotArrowDirection? ArrowDirection
        {
            get => TryGetAs<DotArrowDirectionAttribute>("dir", out var result) ? result.Value : (DotArrowDirection?)null;
            set => AddOrRemove("dir", value, v => new DotArrowDirectionAttribute("dir", v.Value));
        }
        
        public virtual string LogicalHead
        {
            get => TryGetAs<DotLogicalEndpointAttribute>("lhead", out var result) ? result.Value : null;
            set => AddOrRemove("lhead", value, v => new DotLogicalEndpointAttribute("lhead", v));
        }
        
        public virtual string LogicalTail
        {
            get => TryGetAs<DotLogicalEndpointAttribute>("ltail", out var result) ? result.Value : null;
            set => AddOrRemove("ltail", value, v => new DotLogicalEndpointAttribute("ltail", v));
        }

        public virtual bool? Decorate
        {
            get => TryGetAs<DotBoolAttribute>("decorate", out var result) ? result.Value : (bool?)null;
            set => AddOrRemove("decorate", value, v => new DotBoolAttribute("decorate", v.Value));
        }
        
        public virtual bool? Constraint
        {
            get => TryGetAs<DotBoolAttribute>("constraint", out var result) ? result.Value : (bool?)null;
            set => AddOrRemove("constraint", value, v => new DotBoolAttribute("constraint", v.Value));
        }

        public virtual DotRank? Rank
        {
            get => TryGetAs<DotRankAttribute>("rank", out var result) ? result.Value : (DotRank?)null;
            set => AddOrRemove("rank", value, v => new DotRankAttribute("rank", v.Value));
        }

        public virtual DotRankDirection? LayoutDirection
        {
            get => TryGetAs<DotRankDirectionAttribute>("rankdir", out var result) ? result.Value : (DotRankDirection?)null;
            set => AddOrRemove("rankdir", value, v => new DotRankDirectionAttribute("rankdir", v.Value));
        }

        public virtual bool? ConcentrateEdges
        {
            get => TryGetAs<DotBoolAttribute>("concentrate", out var result) ? result.Value : (bool?)null;
            set => AddOrRemove("concentrate", value, v => new DotBoolAttribute("concentrate", v.Value));
        }        
        
        public virtual bool? Compound
        {
            get => TryGetAs<DotBoolAttribute>("compound", out var result) ? result.Value : (bool?)null;
            set => AddOrRemove("compound", value, v => new DotBoolAttribute("compound", v.Value));
        }
    }
}
