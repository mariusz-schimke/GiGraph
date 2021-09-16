using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public interface IDotEntityAttributes
    {
        string GetPropertyKey(PropertyInfo property);
    }
}