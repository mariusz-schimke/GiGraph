using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

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
            get => TryGetValueAs<int>("gradientangle", out var result) ? result : (int?) null;
            set => AddOrRemove("gradientangle", value, v => new DotIntAttribute("gradientangle", v.Value));
        }

        public virtual int? Peripheries
        {
            get => TryGetValueAs<int>("peripheries", out var result) ? result : (int?) null;
            set
            {
                const string key = "peripheries";
                AddOrRemove(key, value, v =>
                {
                    if (v.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Peripheries), v.Value,
                            "The number of peripheries must be greater than or equal to 0.");
                    }

                    return new DotIntAttribute(key, v.Value);
                });
            }
        }

        public virtual int? Sides
        {
            get => TryGetValueAs<int>("sides", out var result) ? result : (int?) null;
            set
            {
                const string key = "sides";
                AddOrRemove(key, value, v =>
                {
                    if (v.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Sides), v.Value,
                            "The number of sides must be greater than or equal to 0.");
                    }

                    return new DotIntAttribute(key, v.Value);
                });
            }
        }

        public virtual double? Skew
        {
            get => TryGetValueAs<double>("skew", out var result) ? result : (double?) null;
            set
            {
                const string key = "skew";
                AddOrRemove(key, value, v =>
                {
                    if (v.Value < -100.0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Skew), v.Value, "Skew must be greater than or equal to -100.");
                    }

                    return new DotDoubleAttribute(key, v.Value);
                });
            }
        }

        public virtual double? PenWidth
        {
            get => TryGetValueAs<double>("penwidth", out var result) ? result : (double?) null;
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

        public virtual Color? FontColor
        {
            get => TryGetValueAs<Color>("fontcolor", out var result) ? result : (Color?) null;
            set => AddOrRemove("fontcolor", value, v => new DotColorAttribute("fontcolor", v.Value));
        }

        public virtual string FontName
        {
            get => TryGetValueAs<string>("fontname", out var result) ? result : null;
            set => AddOrRemove("fontname", value, v => new DotStringAttribute("fontname", v));
        }

        public virtual string FontPath
        {
            get => TryGetValueAs<string>("fontpath", out var result) ? result : null;
            set => AddOrRemove("fontpath", value, v => new DotStringAttribute("fontpath", v));
        }

        public virtual double? FontSize
        {
            get => TryGetValueAs<double>("fontsize", out var result) ? result : (double?) null;
            set
            {
                const string key = "fontsize";
                AddOrRemove(key, value, v =>
                {
                    if (v.Value < 1.0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(FontSize), v.Value, "Font size must be greater than or equal to 1.");
                    }

                    return new DotDoubleAttribute(key, v.Value);
                });
            }
        }

        public virtual DotLabel Label
        {
            get => TryGetValueAsLabel("label");
            set => AddOrRemove("label", value, v => new DotLabelAttribute("label", v));
        }

        public virtual DotShape? Shape
        {
            get => TryGetValueAs<DotShape>("shape", out var result) ? result : (DotShape?) null;
            set => AddOrRemove("shape", value, v => new DotShapeAttribute("shape", v.Value));
        }

        public virtual DotStyle? Style
        {
            get => TryGetValueAs<DotStyle>("style", out var result) ? result : (DotStyle?) null;
            set => AddOrRemove("style", value, v => new DotStyleAttribute("style", v.Value));
        }

        public virtual double? ArrowSize
        {
            get => TryGetValueAs<double>("arrowsize", out var result) ? result : (double?) null;
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
            get => TryGetValueAs<DotArrowType>("arrowhead", out var result) ? result : (DotArrowType?) null;
            set => AddOrRemove("arrowhead", value, v => new DotArrowTypeAttribute("arrowhead", v.Value));
        }

        public virtual DotArrowType? ArrowTail
        {
            get => TryGetValueAs<DotArrowType>("arrowtail", out var result) ? result : (DotArrowType?) null;
            set => AddOrRemove("arrowtail", value, v => new DotArrowTypeAttribute("arrowtail", v.Value));
        }

        public virtual DotArrowDirection? ArrowDirection
        {
            get => TryGetValueAs<DotArrowDirection>("dir", out var result) ? result : (DotArrowDirection?) null;
            set => AddOrRemove("dir", value, v => new DotArrowDirectionAttribute("dir", v.Value));
        }

        public virtual DotEndpointPort HeadPort
        {
            get => TryGetValueAs<DotEndpointPort>("headport", out var result) ? result : null;
            set => AddOrRemove("headport", value, v => new DotEndpointPortAttribute("headport", v));
        }

        public virtual DotEndpointPort TailPort
        {
            get => TryGetValueAs<DotEndpointPort>("tailport", out var result) ? result : null;
            set => AddOrRemove("tailport", value, v => new DotEndpointPortAttribute("tailport", v));
        }

        public virtual string LogicalHeadId
        {
            get => TryGetValueAs<string>("lhead", out var result) ? result : null;
            set => AddOrRemove("lhead", value, v => new DotLogicalEndpointAttribute("lhead", v));
        }

        public virtual string LogicalTailId
        {
            get => TryGetValueAs<string>("ltail", out var result) ? result : null;
            set => AddOrRemove("ltail", value, v => new DotLogicalEndpointAttribute("ltail", v));
        }

        public virtual bool? Decorate
        {
            get => TryGetValueAs<bool>("decorate", out var result) ? result : (bool?) null;
            set => AddOrRemove("decorate", value, v => new DotBoolAttribute("decorate", v.Value));
        }

        public virtual bool? Constraint
        {
            get => TryGetValueAs<bool>("constraint", out var result) ? result : (bool?) null;
            set => AddOrRemove("constraint", value, v => new DotBoolAttribute("constraint", v.Value));
        }

        public virtual DotRank? Rank
        {
            get => TryGetValueAs<DotRank>("rank", out var result) ? result : (DotRank?) null;
            set => AddOrRemove("rank", value, v => new DotRankAttribute("rank", v.Value));
        }

        public virtual DotRankDirection? LayoutDirection
        {
            get => TryGetValueAs<DotRankDirection>("rankdir", out var result) ? result : (DotRankDirection?) null;
            set => AddOrRemove("rankdir", value, v => new DotRankDirectionAttribute("rankdir", v.Value));
        }

        public virtual bool? ConcentrateEdges
        {
            get => TryGetValueAs<bool>("concentrate", out var result) ? result : (bool?) null;
            set => AddOrRemove("concentrate", value, v => new DotBoolAttribute("concentrate", v.Value));
        }

        public virtual bool? Compound
        {
            get => TryGetValueAs<bool>("compound", out var result) ? result : (bool?) null;
            set => AddOrRemove("compound", value, v => new DotBoolAttribute("compound", v.Value));
        }

        public virtual string Comment
        {
            get => TryGetValueAs<string>("comment", out var result) ? result : null;
            set => AddOrRemove("comment", value, v => new DotStringAttribute("comment", v));
        }

        public virtual bool? Regular
        {
            get => TryGetValueAs<bool>("regular", out var result) ? result : (bool?) null;
            set => AddOrRemove("regular", value, v => new DotBoolAttribute("regular", v.Value));
        }

        protected virtual DotColorDefinition TryGetValueAsColorDefinition(string key)
        {
            if (TryGetValueAs<DotColorDefinition>(key, out var colorDefinition))
            {
                return colorDefinition;
            }

            return TryGetValueAs<Color>(key, out var color) ? new DotColor(color) : null;
        }

        protected virtual DotLabel TryGetValueAsLabel(string key)
        {
            if (TryGetValueAs<DotLabel>(key, out var label))
            {
                return label;
            }

            if (TryGetValueAs<DotEscapableString>(key, out var dotEscapableString))
            {
                return dotEscapableString;
            }

            return TryGetValueAs<string>(key, out var value) ? (DotEscapedString) value : null;
        }
    }
}