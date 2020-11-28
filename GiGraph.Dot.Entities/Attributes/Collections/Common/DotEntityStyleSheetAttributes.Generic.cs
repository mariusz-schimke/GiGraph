using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotEntityStyleSheetAttributes<TIEntityStyleSheetAttributes> : DotEntityAttributes<TIEntityStyleSheetAttributes>, IDotEntityStyleSheetAttributes
        where TIEntityStyleSheetAttributes : IDotEntityStyleSheetAttributes
    {
        protected DotEntityStyleSheetAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotEntityStyleSheetAttributes.Class" />
        [DotAttributeKey(DotAttributeKeys.Class)]
        public virtual string Class
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }
    }
}