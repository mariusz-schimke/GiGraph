using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    /// <summary>
    ///     Common attributes of the root graph, clusters, nodes, and edges.
    /// </summary>
    /// <remarks>
    ///     When adding new properties, override them in all descendant classes to set adequate XML documentation comments.
    /// </remarks>
    public abstract class DotEntityRootCommonAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>
        where TEntityAttributeProperties : DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
    {
        protected DotEntityRootCommonAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup, DotHyperlinkAttributes hyperlinkAttributes)
            : base(attributes, attributeKeyLookup)
        {
            Hyperlink = hyperlinkAttributes;
        }

        public virtual DotHyperlinkAttributes Hyperlink { get; }

        [DotAttributeKey(DotAttributeKeys.Label)]
        public virtual DotLabel Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ColorScheme)]
        public virtual string ColorScheme
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Id)]
        public virtual DotEscapeString ObjectId
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}