using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
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
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }
    }
}