using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet
{
    public abstract class DotSvgStyleSheetAttributes<TIEntitySvgStyleSheetAttributes> : DotNestedEntityAttributes<TIEntitySvgStyleSheetAttributes>, IDotSvgStyleSheetAttributes
        where TIEntitySvgStyleSheetAttributes : IDotSvgStyleSheetAttributes
    {
        protected DotSvgStyleSheetAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotSvgStyleSheetAttributes.Class" />
        [DotAttributeKey(DotAttributeKeys.Class)]
        public virtual string Class
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}