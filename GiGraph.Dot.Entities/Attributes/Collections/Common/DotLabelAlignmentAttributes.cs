using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public class DotLabelAlignmentAttributes : DotEntityAttributes<IDotLabelAlignmentAttributes>, IDotLabelAlignmentAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup LabelAlignmentAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotLabelAlignmentAttributes, IDotLabelAlignmentAttributes>().Build();

        protected DotLabelAlignmentAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotLabelAlignmentAttributes(DotAttributeCollection attributes)
            : base(attributes, LabelAlignmentAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotLabelAlignmentAttributes.Horizontal" />
        [DotAttributeKey(DotAttributeKeys.LabelJust)]
        public virtual DotHorizontalAlignment? Horizontal
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotHorizontalAlignment?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotHorizontalAlignmentAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotLabelAlignmentAttributes.Vertical" />
        [DotAttributeKey(DotAttributeKeys.LabelLoc)]
        public virtual DotVerticalAlignment? Vertical
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotVerticalAlignment?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotVerticalAlignmentAttribute(k, v.Value));
        }

        /// <summary>
        ///     Sets layout properties.
        /// </summary>
        /// <param name="horizontal">
        ///     The horizontal label alignment to set.
        /// </param>
        /// <param name="vertical">
        ///     The vertical label alignment to set.
        /// </param>
        public virtual void Set(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        /// <summary>
        ///     Copies label alignment properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(IDotLabelAlignmentAttributes source)
        {
            Set(source.Horizontal, source.Vertical);
        }
    }
}