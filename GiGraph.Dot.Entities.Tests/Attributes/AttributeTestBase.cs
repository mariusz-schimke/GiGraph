using System;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public abstract class AttributesTestBase
    {
        protected const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        protected (MethodInfo Accessor, PropertyInfo Property)[] GetInterfacePropertyAndAccessorPairs(Type @interface)
        {
            // get all setters and getters of the interface
            var interfaceProps = @interface.GetProperties(Flags);

            return interfaceProps
               .Select(prop => (Method: prop.GetMethod, Property: prop))
               .Concat
                (
                    interfaceProps.Select(prop => (Method: prop.SetMethod, Property: prop))
                )
               .Where(p => p.Method is {})
               .ToArray();
        }
    }
}