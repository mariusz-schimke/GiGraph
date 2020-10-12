using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeAttributeCollection : DotEntityAttributeCollection<IDotEdgeAttributes>, IDotEdgeAttributeCollection
    {
        public DotEdgeAttributeCollection(DotMemberAttributeKeyLookup entityAttributePropertiesInterfaceKeyLookup)
            : base(entityAttributePropertiesInterfaceKeyLookup)
        {
        }

        protected virtual DotEdgeAttributes Attributes => (DotEdgeAttributes) _attributes;

        // TODO: provide a font instance (through _attributes?)

        /// <summary>
        ///     Font properties.
        /// </summary>
        public virtual DotEntityFontAttributes Font => Attributes.Font;

        // TODO: comments
        public virtual DotEdgeHeadAttributes Head => Attributes.Head;
        public virtual DotEdgeTailAttributes Tail => Attributes.Tail;

        public virtual DotEdgeEndpointLabelAttributes EndpointLabels => Attributes.EndpointLabels;

        public virtual double? Weight
        {
            get => Attributes.Weight;
            set => Attributes.Weight = value;
        }

        public virtual double? Length
        {
            get => Attributes.Length;
            set => Attributes.Length = value;
        }

        public virtual int? MinLength
        {
            get => Attributes.MinLength;
            set => Attributes.MinLength = value;
        }

        public virtual DotEscapeString LabelUrl
        {
            get => Attributes.LabelUrl;
            set => Attributes.LabelUrl = value;
        }

        public virtual DotEscapeString LabelHref
        {
            get => Attributes.LabelHref;
            set => Attributes.LabelHref = value;
        }

        public virtual DotEscapeString LabelUrlTarget
        {
            get => Attributes.LabelUrlTarget;
            set => Attributes.LabelUrlTarget = value;
        }

        public virtual DotEscapeString LabelUrlTooltip
        {
            get => Attributes.LabelUrlTooltip;
            set => Attributes.LabelUrlTooltip = value;
        }

        public virtual DotEscapeString EdgeUrl
        {
            get => Attributes.EdgeUrl;
            set => Attributes.EdgeUrl = value;
        }

        public virtual DotEscapeString EdgeHref
        {
            get => Attributes.EdgeHref;
            set => Attributes.EdgeHref = value;
        }

        public virtual DotEscapeString EdgeUrlTarget
        {
            get => Attributes.EdgeUrlTarget;
            set => Attributes.EdgeUrlTarget = value;
        }

        public virtual DotEscapeString EdgeUrlTooltip
        {
            get => Attributes.EdgeUrlTooltip;
            set => Attributes.EdgeUrlTooltip = value;
        }

        public virtual double? ArrowheadScale
        {
            get => Attributes.ArrowheadScale;
            set => Attributes.ArrowheadScale = value;
        }

        public virtual DotArrowDirections? ArrowDirections
        {
            get => Attributes.ArrowDirections;
            set => Attributes.ArrowDirections = value;
        }

        public virtual bool? AttachLabel
        {
            get => Attributes.AttachLabel;
            set => Attributes.AttachLabel = value;
        }

        public virtual bool? AllowLabelFloat
        {
            get => Attributes.AllowLabelFloat;
            set => Attributes.AllowLabelFloat = value;
        }

        public virtual bool? Constrain
        {
            get => Attributes.Constrain;
            set => Attributes.Constrain = value;
        }

        public override void SetFilled(DotColorDefinition value)
        {
            FillColor = value;
        }
    }
}