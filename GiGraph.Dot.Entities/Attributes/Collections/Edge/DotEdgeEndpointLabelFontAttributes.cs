using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeEndpointLabelFontAttributes : DotEntityAttributes<IDotEdgeEndpointLabelFontAttributes>, IDotEdgeEndpointLabelFontAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup MemberAttributeKeyLookup = CreateMemberAttributeKeyLookupFor(typeof(DotEdgeEndpointLabelFontAttributes));

        public DotEdgeEndpointLabelFontAttributes(DotAttributeCollection attributes)
            : base(attributes, MemberAttributeKeyLookup)
        {
        }

        /// <summary>
        ///     Font used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail <see cref="IDotEdgeTailAttributes.Label" />
        ///     of the edge. If not set, defaults to the edge's font name (<see cref="IDotEntityFontAttributes.Name" />).
        /// </summary>
        [DotAttributeKey("labelfontname")]
        public virtual string Name
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <summary>
        ///     Color used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail <see cref="IDotEdgeTailAttributes.Label" />
        ///     of the edge. If not set, defaults to the edge's font color (<see cref="IDotEntityFontAttributes.Color" />).
        /// </summary>
        [DotAttributeKey("labelfontcolor")]
        public virtual DotColor Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <summary>
        ///     Font size, in points, used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail
        ///     <see cref="IDotEdgeTailAttributes.Label" /> of the edge. If not set, defaults to the edge's font size (
        ///     <see cref="IDotEntityFontAttributes.Size" />).
        /// </summary>
        [DotAttributeKey("labelfontsize")]
        public virtual double? Size
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(IDotEdgeEndpointLabelFontAttributes.Size), v.Value, "Endpoint label font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }
    }
}