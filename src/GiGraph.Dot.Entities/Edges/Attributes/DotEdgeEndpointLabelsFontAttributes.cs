using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeEndpointLabelsFontAttributes : DotFontAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> EdgeEndpointLabelFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeEndpointLabelsFontAttributes, IDotFontAttributes>().BuildLazy();

        protected DotEdgeEndpointLabelsFontAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeEndpointLabelsFontAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeEndpointLabelFontAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     Font used for labels specified for the head and the tail of the edge (default: "Times-Roman"). If not set, defaults to font
        ///     name specified for the edge.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.LabelFontName)]
        public override string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        /// <summary>
        ///     Color used for labels specified for the head and the tail of the edge (default: <see cref="System.Drawing.Color.Black" />).
        ///     If not set, defaults to font color specified for the edge.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.LabelFontColor)]
        public override DotColor Color
        {
            get => base.Color;
            set => base.Color = value;
        }

        /// <summary>
        ///     Font size, in points, used for labels specified for the head and the tail of the edge (default: 14.0). If not set, defaults
        ///     to font size specified for the edge.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.LabelFontSize)]
        public override double? Size
        {
            get => base.Size;
            set => base.Size = value;
        }
    }
}