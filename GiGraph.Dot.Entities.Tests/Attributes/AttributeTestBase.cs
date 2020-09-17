using System;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public abstract class AttributesTestBase
    {
        protected const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        protected const bool NonPublic = true;

        protected (MethodInfo Method, PropertyInfo Property)[] GetInterfacePropertyMethodPairs(Type @interface)
        {
            // get all setters and getters of the interface
            var interfaceProps = @interface.GetProperties(Flags);

            return interfaceProps
               .Select(prop => (Method: prop.GetGetMethod(NonPublic), Property: prop))
               .Concat
                (
                    interfaceProps.Select(prop => (Method: prop.GetSetMethod(NonPublic), Property: prop))
                )
               .Where(p => p.Method is {})
               .ToArray();
        }
    }
}