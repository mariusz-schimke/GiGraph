using System;
using System.Reflection;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public partial class DotEdgeAttributeCollection :
        IDotEdgeEndpointLabelAttributes,
        IDotEdgeEndpointLabelFontAttributes
    {
        public virtual IDotEdgeEndpointLabelAttributes EndpointLabels => this;
        IDotEdgeEndpointLabelFontAttributes IDotEdgeEndpointLabelAttributes.Font => this;

        [DotAttributeKey("labeldistance")]
        double? IDotEdgeEndpointLabelAttributes.Distance
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(IDotEdgeEndpointLabelAttributes.Distance), v.Value, "Endpoint label distance must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("labelangle")]
        double? IDotEdgeEndpointLabelAttributes.Angle
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("labelfontname")]
        string IDotEdgeEndpointLabelFontAttributes.Name
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("labelfontcolor")]
        DotColor IDotEdgeEndpointLabelFontAttributes.Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("labelfontsize")]
        double? IDotEdgeEndpointLabelFontAttributes.Size
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(IDotEdgeEndpointLabelFontAttributes.Size), v.Value, "Endpoint label font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }
    }
}