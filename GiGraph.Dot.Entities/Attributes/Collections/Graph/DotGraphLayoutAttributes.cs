using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphLayoutAttributes : DotEntityAttributes<IDotGraphLayoutAttributes>, IDotGraphLayoutAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphLayoutAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphLayoutAttributes, IDotGraphLayoutAttributes>().Build();

        protected DotGraphLayoutAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphLayoutAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphLayoutAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.Direction" />
        [DotAttributeKey(DotAttributeKeys.RankDir)]
        public virtual DotLayoutDirection? Direction
        {
            get => GetValueAs<DotLayoutDirection>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotLayoutDirection?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLayoutDirectionAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.Engine" />
        [DotAttributeKey(DotAttributeKeys.Layout)]
        public virtual string Engine
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <summary>
        ///     Sets layout properties.
        /// </summary>
        /// <param name="direction">
        ///     The layout direction to apply.
        /// </param>
        /// <param name="engine">
        ///     The layout engine to use.
        /// </param>
        public virtual void Set(DotLayoutDirection? direction, string engine)
        {
            Engine = engine;
            Direction = direction;
        }

        /// <summary>
        ///     Copies layout properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(IDotGraphLayoutAttributes source)
        {
            Set(source.Direction, source.Engine);
        }
    }
}