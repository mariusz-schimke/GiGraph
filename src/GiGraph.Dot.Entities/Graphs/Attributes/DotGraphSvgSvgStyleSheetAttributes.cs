using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphSvgSvgStyleSheetAttributes : DotSvgStyleSheetAttributes<IDotGraphSvgStyleSheetAttributes>, IDotGraphSvgStyleSheetAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphSvgStyleSheetAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphSvgSvgStyleSheetAttributes, IDotGraphSvgStyleSheetAttributes>().Build();

        protected DotGraphSvgSvgStyleSheetAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphSvgSvgStyleSheetAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphSvgStyleSheetAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphSvgStyleSheetAttributes.Url" />
        [DotAttributeKey(DotAttributeKeys.SvgStyleSheet)]
        public virtual string Url
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <summary>
        ///     Sets style sheet attributes.
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
        ///     Copies style sheet attributes from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the attributes from.
        /// </param>
        public virtual void Set(IDotGraphSvgStyleSheetAttributes attributes)
        {
            Set(attributes.Url, attributes.Class);
        }
    }
}