using GiGraph.Dot.Entities.Attributes.Collections.Lookup;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterAttributeCollection : DotEntityAttributeCollection<IDotClusterAttributes>, IDotClusterAttributeCollection
    {
        private static readonly DotMemberAttributeKeyLookup ExposedEntityAttributesKeyLookup;

        static DotClusterAttributeCollection()
        {
            var type = typeof(DotClusterAttributeCollection);
            UpdatePropertyAccessorsAttributeKeyLookupFor(type);
            ExposedEntityAttributesKeyLookup = CreateAttributeKeyLookupForExposedEntityAttributesOf(type);
        }

        public DotClusterAttributeCollection()
            : base(ExposedEntityAttributesKeyLookup)
        {
        }
    }
}