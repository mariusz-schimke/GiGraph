using System.Reflection;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphStyleSheetAttributes : DotStyleSheetAttributes<IDotGraphStyleSheetAttributes>, IDotGraphStyleSheetAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EntityStyleSheetAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphStyleSheetAttributes, IDotGraphStyleSheetAttributes>().Build();

        protected DotGraphStyleSheetAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphStyleSheetAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityStyleSheetAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphStyleSheetAttributes.Url" />
        [DotAttributeKey(DotAttributeKeys.StyleSheet)]
        public virtual string Url
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <summary>
        ///     Sets style sheet properties.
        /// </summary>
        /// <param name="url">
        ///     The URL or pathname specifying an XML style sheet.
        /// </param>
        /// <param name="class">
        ///     The CSS class to set.
        /// </param>
        public virtual void Set(string url, string @class)
        {
            Url = url;
            Class = @class;
        }

        /// <summary>
        ///     Copies style sheet properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotGraphStyleSheetAttributes attributes)
        {
            Set(attributes.Url, attributes.Class);
        }
    }
}