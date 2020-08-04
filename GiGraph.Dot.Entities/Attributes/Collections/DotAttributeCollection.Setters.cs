using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.AspectRatio;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public partial class DotAttributeCollection
    {
        public virtual T Set<T>(T attribute)
            where T : DotAttribute
        {
            this[attribute.Key] = attribute;
            return attribute;
        }

        public virtual void SetRange(IEnumerable<DotAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                Set(attribute);
            }
        }

        public virtual DotNullAttribute SetNull(string key)
        {
            return Set(new DotNullAttribute(key));
        }

        public virtual DotStringAttribute Set(string key, string value)
        {
            return Set(new DotStringAttribute(key, value));
        }

        public virtual DotEscapeStringAttribute Set(string key, DotEscapeString value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        public virtual DotEscapeStringAttribute Set(string key, DotEscapedString value)
        {
            return Set(new DotEscapeStringAttribute(key, value));
        }

        public virtual DotLabelAttribute Set(string key, DotLabel value)
        {
            return Set(new DotLabelAttribute(key, value));
        }

        public virtual DotLabelAttribute Set(string key, DotTextLabel value)
        {
            return Set(new DotLabelAttribute(key, value));
        }

        public virtual DotLabelAttribute Set(string key, DotHtmlLabel value)
        {
            return Set(new DotLabelAttribute(key, value));
        }

        public virtual DotLabelAttribute Set(string key, DotRecordLabel value)
        {
            return Set(new DotLabelAttribute(key, value));
        }

        public virtual DotHorizontalAlignmentAttribute Set(string key, DotHorizontalAlignment value)
        {
            return Set(new DotHorizontalAlignmentAttribute(key, value));
        }

        public virtual DotVerticalAlignmentAttribute Set(string key, DotVerticalAlignment value)
        {
            return Set(new DotVerticalAlignmentAttribute(key, value));
        }

        public virtual DotIntAttribute Set(string key, int value)
        {
            return Set(new DotIntAttribute(key, value));
        }

        public virtual DotDoubleAttribute Set(string key, double value)
        {
            return Set(new DotDoubleAttribute(key, value));
        }

        public virtual DotDoubleListAttribute Set(string key, params double[] value)
        {
            return Set(new DotDoubleListAttribute(key, value));
        }

        public virtual DotDoubleListAttribute Set(string key, IEnumerable<double> value)
        {
            return Set(new DotDoubleListAttribute(key, value));
        }

        public virtual DotBoolAttribute Set(string key, bool value)
        {
            return Set(new DotBoolAttribute(key, value));
        }

        public virtual DotColorAttribute Set(string key, Color value)
        {
            return Set(new DotColorAttribute(key, value));
        }

        public virtual DotColorDefinitionAttribute Set(string key, DotColorDefinition value)
        {
            return Set(new DotColorDefinitionAttribute(key, value));
        }

        public virtual DotNodeShapeAttribute Set(string key, DotNodeShape value)
        {
            return Set(new DotNodeShapeAttribute(key, value));
        }

        public virtual DotEdgeShapeAttribute Set(string key, DotEdgeShape value)
        {
            return Set(new DotEdgeShapeAttribute(key, value));
        }

        public virtual DotNodeFixedSizeAttribute Set(string key, DotNodeSizing value)
        {
            return Set(new DotNodeFixedSizeAttribute(key, value));
        }

        public virtual DotStyleAttribute Set(string key, DotStyle value)
        {
            return Set(new DotStyleAttribute(key, value));
        }

        public virtual DotArrowheadShapeAttribute Set(string key, DotArrowheadShape value)
        {
            return Set(new DotArrowheadShapeAttribute(key, value));
        }

        public virtual DotArrowDirectionAttribute Set(string key, DotArrowDirection value)
        {
            return Set(new DotArrowDirectionAttribute(key, value));
        }

        public virtual DotRankAttribute Set(string key, DotRank value)
        {
            return Set(new DotRankAttribute(key, value));
        }

        public virtual DotRankDirectionAttribute Set(string key, DotRankDirection value)
        {
            return Set(new DotRankDirectionAttribute(key, value));
        }

        public virtual DotClusterModeAttribute Set(string key, DotClusterMode value)
        {
            return Set(new DotClusterModeAttribute(key, value));
        }

        public virtual DotEdgeOrderingModeAttribute Set(string key, DotEdgeOrderingMode value)
        {
            return Set(new DotEdgeOrderingModeAttribute(key, value));
        }

        public virtual DotRankSeparationAttribute Set(string key, DotRankSeparationDefinition value)
        {
            return Set(new DotRankSeparationAttribute(key, value));
        }

        public virtual DotEndpointPortAttribute Set(string key, DotEndpointPort value)
        {
            return Set(new DotEndpointPortAttribute(key, value));
        }

        public virtual DotCompassPointAttribute Set(string key, DotCompassPoint value)
        {
            return Set(new DotCompassPointAttribute(key, value));
        }

        public virtual DotAlignmentAttribute Set(string key, DotAlignment value)
        {
            return Set(new DotAlignmentAttribute(key, value));
        }

        public virtual DotPointAttribute Set(string key, DotPoint value)
        {
            return Set(new DotPointAttribute(key, value));
        }

        public virtual DotAspectRatioDefinitionAttribute Set(string key, DotAspectRatioDefinition value)
        {
            return Set(new DotAspectRatioDefinitionAttribute(key, value));
        }

        public virtual DotAspectRatioAttribute Set(string key, DotAspectRatio value)
        {
            return Set(new DotAspectRatioAttribute(key, value));
        }

        public virtual DotArrowheadDefinitionAttribute Set(string key, DotArrowheadDefinition value)
        {
            return Set(new DotArrowheadDefinitionAttribute(key, value));
        }
    }
}