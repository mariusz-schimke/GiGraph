using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    /// <summary>
    ///     Common attributes of the root graph, clusters, nodes, and edges.
    /// </summary>
    /// <remarks>
    ///     When adding new properties, override them in all descendant classes to set adequate XML documentation comments.
    /// </remarks>
    public abstract class DotEntityRootCommonAttributes<TIEntityAttributeProperties> : DotEntityRootAttributes<TIEntityAttributeProperties>
    {
        protected DotEntityRootCommonAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup, DotHyperlinkAttributes hyperlinkAttributes)
            : base(attributes, attributeKeyLookup)
        {
            Hyperlink = hyperlinkAttributes;
        }

        /// <summary>
        ///     Hyperlink attributes.
        /// </summary>
        public virtual DotHyperlinkAttributes Hyperlink { get; }

        [DotAttributeKey(DotAttributeKeys.Label)]
        public virtual DotLabel Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.ColorScheme)]
        public virtual string ColorScheme
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Id)]
        public virtual DotEscapeString ObjectId
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }
    }
}