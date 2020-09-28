using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterAttributeCollection : DotEntityAttributeCollection<IDotClusterAttributes>, IDotClusterAttributeCollection
    {
        protected static readonly DotMemberAttributeKeyLookup ExposedEntityAttributesKeyLookup;

        static DotClusterAttributeCollection()
        {
            var type = typeof(DotClusterAttributeCollection);
            UpdatePropertyAccessorsAttributeKeyLookupFor(type);
            ExposedEntityAttributesKeyLookup = CreateAttributeKeyLookupForExposedEntityAttributesOf(type).ToReadOnly();
        }

        protected DotClusterAttributeCollection(DotMemberAttributeKeyLookup exposedEntityAttributesKeyLookup)
            : base(exposedEntityAttributesKeyLookup)
        {
        }

        public DotClusterAttributeCollection()
            : base(ExposedEntityAttributesKeyLookup)
        {
        }
    }
}