﻿using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeEndpointLabelFontAttributes : DotFontAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeEndpointLabelFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeEndpointLabelFontAttributes, IDotFontAttributes>().Build();

        protected DotEdgeEndpointLabelFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeEndpointLabelFontAttributes(DotAttributeCollection attributes)
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