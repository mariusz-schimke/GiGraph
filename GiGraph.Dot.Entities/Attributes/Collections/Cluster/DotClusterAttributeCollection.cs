namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterAttributeCollection : DotEntityAttributeCollection<IDotClusterAttributes>, IDotClusterAttributeCollection
    {
        static DotClusterAttributeCollection()
        {
            CacheAttributeKeys(typeof(DotClusterAttributeCollection));
        }
    }
}