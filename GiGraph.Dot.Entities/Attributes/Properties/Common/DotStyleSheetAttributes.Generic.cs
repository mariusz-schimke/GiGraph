using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public abstract class DotStyleSheetAttributes<TIEntityStyleSheetAttributes> : DotEntityAttributes<TIEntityStyleSheetAttributes>, IDotStyleSheetAttributes
        where TIEntityStyleSheetAttributes : IDotStyleSheetAttributes
    {
        protected DotStyleSheetAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotStyleSheetAttributes.Class" />
        [DotAttributeKey(DotAttributeKeys.Class)]
        public virtual string Class
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemoveStringAttribute(MethodBase.GetCurrentMethod(), value);
        }
    }
}