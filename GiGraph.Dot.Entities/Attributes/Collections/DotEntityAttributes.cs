using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityAttributes : DotAttributeCollection,
        IDotGraphAttributes,
        IDotSubgraphAttributes,
        IDotClusterAttributes,
        IDotNodeAttributes,
        IDotEdgeAttributes
    {
        public virtual DotColorDefinition Color
        {
            get => TryGetValueAsColorDefinition("color");
            set => AddOrRemove("color", value, v => new DotColorDefinitionAttribute("color", v));
        }

        public virtual DotColorDefinition BackgroundColor
        {
            get => TryGetValueAsColorDefinition("bgcolor");
            set => AddOrRemove("bgcolor", value, v => new DotColorDefinitionAttribute("bgcolor", v));
        }

        public virtual DotColorDefinition FillColor
        {
            get => TryGetValueAsColorDefinition("fillcolor");
            set => AddOrRemove("fillcolor", value, v => new DotColorDefinitionAttribute("fillcolor", v));
        }

        public virtual int? GradientAngle
        {
            get => TryGetAs<DotIntAttribute>("gradientangle", out var result) ? result.Value : (int?) null;
            set => AddOrRemove("gradientangle", value, v => new DotIntAttribute("gradientangle", v.Value));
        }

        public virtual double? PenWidth
        {
            get => TryGetAs<DotDoubleAttribute>("penwidth", out var result) ? result.Value : (double?) null;
            set
            {
                const string key = "penwidth";
                AddOrRemove(key, value, v =>
                {
                    if (v.Value < 0.0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(PenWidth), v.Value, "Pen width must be greater than or equal to 0.");
                    }

                    return new DotDoubleAttribute(key, v.Value);
                });
            }
        }

        public virtual Color? PenColor
        {
            get => TryGetValueAs<Color>("pencolor", out var result) ? result : (Color?) null;
            set => AddOrRemove("pencolor", value, v => new DotColorAttribute("pencolor", v.Value));
        }

        public virtual string Label
        {
            get => TryGetAs<DotStringAttribute>("label", out var result) ? result.Value : null;
            set => AddOrRemove("label", value, v => new DotStringAttribute("label", v));
        }

        public virtual string LabelHtml
        {
            get => TryGetAs<DotHtmlAttribute>("label", out var result) ? result.Value : null;
            set => AddOrRemove("label", value, v => new DotHtmlAttribute("label", v));
        }

        public virtual DotShape? Shape
        {
            get => TryGetValueAs<DotShape>("shape", out var result) ? result : (DotShape?) null;
            set => AddOrRemove("shape", value, v => new DotShapeAttribute("shape", v.Value));
        }

        public virtual DotStyle? Style
        {
            get => TryGetAs<DotStyleAttribute>("style", out var result) ? result.Value : (DotStyle?) null;
            set => AddOrRemove("style", value, v => new DotStyleAttribute("style", v.Value));
        }

        public virtual double? ArrowSize
        {
            get => TryGetAs<DotDoubleAttribute>("arrowsize", out var result) ? result.Value : (double?) null;
            set
            {
                const string key = "arrowsize";
                AddOrRemove(key, value, v =>
                {
                    if (v.Value < 0.0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(ArrowSize), v.Value, "Arrow size must be greater than or equal to 0.");
                    }

                    return new DotDoubleAttribute(key, v.Value);
                });
            }
        }

        public virtual DotArrowType? ArrowHead
        {
            get => TryGetAs<DotArrowTypeAttribute>("arrowhead", out var result) ? result.Value : (DotArrowType?) null;
            set => AddOrRemove("arrowhead", value, v => new DotArrowTypeAttribute("arrowhead", v.Value));
        }

        public virtual DotArrowType? ArrowTail
        {
            get => TryGetAs<DotArrowTypeAttribute>("arrowtail", out var result) ? result.Value : (DotArrowType?) null;
            set => AddOrRemove("arrowtail", value, v => new DotArrowTypeAttribute("arrowtail", v.Value));
        }

        public virtual DotArrowDirection? ArrowDirection
        {
            get => TryGetAs<DotArrowDirectionAttribute>("dir", out var result) ? result.Value : (DotArrowDirection?) null;
            set => AddOrRemove("dir", value, v => new DotArrowDirectionAttribute("dir", v.Value));
        }

        public virtual string LogicalHeadId
        {
            get => TryGetAs<DotLogicalEndpointAttribute>("lhead", out var result) ? result.Value : null;
            set => AddOrRemove("lhead", value, v => new DotLogicalEndpointAttribute("lhead", v));
        }

        public virtual string LogicalTailId
        {
            get => TryGetAs<DotLogicalEndpointAttribute>("ltail", out var result) ? result.Value : null;
            set => AddOrRemove("ltail", value, v => new DotLogicalEndpointAttribute("ltail", v));
        }

        public virtual bool? Decorate
        {
            get => TryGetAs<DotBoolAttribute>("decorate", out var result) ? result.Value : (bool?) null;
            set => AddOrRemove("decorate", value, v => new DotBoolAttribute("decorate", v.Value));
        }

        public virtual bool? Constraint
        {
            get => TryGetAs<DotBoolAttribute>("constraint", out var result) ? result.Value : (bool?) null;
            set => AddOrRemove("constraint", value, v => new DotBoolAttribute("constraint", v.Value));
        }

        public virtual DotRank? Rank
        {
            get => TryGetAs<DotRankAttribute>("rank", out var result) ? result.Value : (DotRank?) null;
            set => AddOrRemove("rank", value, v => new DotRankAttribute("rank", v.Value));
        }

        public virtual DotRankDirection? LayoutDirection
        {
            get => TryGetAs<DotRankDirectionAttribute>("rankdir", out var result) ? result.Value : (DotRankDirection?) null;
            set => AddOrRemove("rankdir", value, v => new DotRankDirectionAttribute("rankdir", v.Value));
        }

        public virtual bool? ConcentrateEdges
        {
            get => TryGetAs<DotBoolAttribute>("concentrate", out var result) ? result.Value : (bool?) null;
            set => AddOrRemove("concentrate", value, v => new DotBoolAttribute("concentrate", v.Value));
        }

        public virtual bool? Compound
        {
            get => TryGetAs<DotBoolAttribute>("compound", out var result) ? result.Value : (bool?) null;
            set => AddOrRemove("compound", value, v => new DotBoolAttribute("compound", v.Value));
        }

        protected virtual DotColorDefinition TryGetValueAsColorDefinition(string key)
        {
            if (TryGetValueAs<DotColorDefinition>(key, out var colorDefinition))
            {
                return colorDefinition;
            }

            return TryGetValueAs<Color>(key, out var color) ? new DotColor(color) : null;
        }
    }
}