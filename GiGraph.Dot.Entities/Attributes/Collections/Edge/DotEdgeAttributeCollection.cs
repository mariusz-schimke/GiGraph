using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeAttributeCollection : DotEntityAttributeCollection<IDotEdgeAttributes>,
        IDotEntityAttributes<IDotEdgeAttributes>,
        IDotEdgeAttributeCollection
    {
        protected readonly DotEdgeAttributes _attributes;

        public DotEdgeAttributeCollection(DotMemberAttributeKeyLookup entityAttributePropertiesInterfaceKeyLookup)
            : base(entityAttributePropertiesInterfaceKeyLookup)
        {
        }

        // TODO: provide a font instance (through _attributes?)

        /// <summary>
        ///     Font properties.
        /// </summary>
        public virtual DotEntityFontAttributes Font => _attributes.Font;

        // TODO: comments
        public virtual DotEdgeHeadAttributes Head => _attributes.Head;
        public virtual DotEdgeTailAttributes Tail => _attributes.Tail;

        public virtual DotEdgeEndpointLabelAttributes EndpointLabels => _attributes.EndpointLabels;

        public virtual double? Weight
        {
            get => _attributes.Weight;
            set => _attributes.Weight = value;
        }

        public virtual double? Length
        {
            get => _attributes.Length;
            set => _attributes.Length = value;
        }

        public virtual int? MinLength
        {
            get => _attributes.MinLength;
            set => _attributes.MinLength = value;
        }

        public virtual DotEscapeString LabelUrl
        {
            get => _attributes.LabelUrl;
            set => _attributes.LabelUrl = value;
        }

        public virtual DotEscapeString LabelHref
        {
            get => _attributes.LabelHref;
            set => _attributes.LabelHref = value;
        }

        public virtual DotEscapeString LabelUrlTarget
        {
            get => _attributes.LabelUrlTarget;
            set => _attributes.LabelUrlTarget = value;
        }

        public virtual DotEscapeString LabelUrlTooltip
        {
            get => _attributes.LabelUrlTooltip;
            set => _attributes.LabelUrlTooltip = value;
        }

        public virtual DotEscapeString EdgeUrl
        {
            get => _attributes.EdgeUrl;
            set => _attributes.EdgeUrl = value;
        }

        public virtual DotEscapeString EdgeHref
        {
            get => _attributes.EdgeHref;
            set => _attributes.EdgeHref = value;
        }

        public virtual DotEscapeString EdgeUrlTarget
        {
            get => _attributes.EdgeUrlTarget;
            set => _attributes.EdgeUrlTarget = value;
        }

        public virtual DotEscapeString EdgeUrlTooltip
        {
            get => _attributes.EdgeUrlTooltip;
            set => _attributes.EdgeUrlTooltip = value;
        }

        public virtual double? ArrowheadScale
        {
            get => _attributes.ArrowheadScale;
            set => _attributes.ArrowheadScale = value;
        }

        public virtual DotArrowDirections? ArrowDirections
        {
            get => _attributes.ArrowDirections;
            set => _attributes.ArrowDirections = value;
        }

        public virtual bool? AttachLabel
        {
            get => _attributes.AttachLabel;
            set => _attributes.AttachLabel = value;
        }

        public virtual bool? AllowLabelFloat
        {
            get => _attributes.AllowLabelFloat;
            set => _attributes.AllowLabelFloat = value;
        }

        public virtual bool? Constrain
        {
            get => _attributes.Constrain;
            set => _attributes.Constrain = value;
        }

        public override void SetFilled(DotColorDefinition value)
        {
            FillColor = value;
        }
    }
}