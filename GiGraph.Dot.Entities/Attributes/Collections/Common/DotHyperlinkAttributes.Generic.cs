using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotHyperlinkAttributes<TIEntityHyperlinkAttributes> : DotEntityAttributes<TIEntityHyperlinkAttributes>, IDotHyperlinkAttributes
        where TIEntityHyperlinkAttributes : IDotHyperlinkAttributes
    {
        protected DotHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotHyperlinkAttributes.Url" />
        [DotAttributeKey(DotAttributeKeys.Url)]
        public virtual DotEscapeString Url
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotHyperlinkAttributes.Href" />
        [DotAttributeKey(DotAttributeKeys.Href)]
        public virtual DotEscapeString Href
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotHyperlinkAttributes.Target" />
        [DotAttributeKey(DotAttributeKeys.Target)]
        public virtual DotEscapeString Target
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        /// <summary>
        ///     Specifies hyperlink properties.
        /// </summary>
        /// <param name="url">
        ///     The URL of the hyperlink.
        /// </param>
        /// <param name="target">
        ///     The target of the hyperlink. See <see cref="DotHyperlinkTargets" /> for accepted values.
        /// </param>
        public virtual void Set(DotEscapeString url, DotEscapeString target = null)
        {
            Url = url;
            Target = target;
        }

        protected virtual void SetAll(DotEscapeString url, DotEscapeString target, DotEscapeString href)
        {
            Href = href;
            Set(url, target);
        }

        /// <summary>
        ///     Specifies hyperlink properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotHyperlink attributes)
        {
            SetAll(attributes.Url, attributes.Target, attributes.Href);
        }

        /// <summary>
        ///     Copies hyperlink properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotHyperlinkAttributes attributes)
        {
            SetAll(attributes.Url, attributes.Target, attributes.Href);
        }
    }
}