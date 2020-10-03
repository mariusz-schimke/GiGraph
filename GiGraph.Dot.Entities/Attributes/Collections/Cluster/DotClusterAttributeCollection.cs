using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterAttributeCollection : DotEntityAttributeCollection<IDotClusterAttributes>, IDotClusterAttributeCollection
    {
        protected static readonly DotMemberAttributeKeyLookup EntityAttributePropertiesInterfaceKeyLookup;

        static DotClusterAttributeCollection()
        {
            var type = typeof(DotClusterAttributeCollection);
            UpdateAttributeKeyLookupForDeclaredPropertyAccessorsOf(type);
            EntityAttributePropertiesInterfaceKeyLookup = CreateAttributeKeyLookupForEntityAttributePropertiesOf(type).ToReadOnly();
        }

        protected DotClusterAttributeCollection(DotMemberAttributeKeyLookup entityAttributePropertiesInterfaceKeyLookup)
            : base(entityAttributePropertiesInterfaceKeyLookup)
        {
        }

        public DotClusterAttributeCollection()
            : base(EntityAttributePropertiesInterfaceKeyLookup)
        {
        }
    }
}