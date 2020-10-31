using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes
    {
        protected void AddOrRemoveBorderWidth(MethodBase propertyAccessor, double? value, [CallerMemberName] string propertyName = null)
        {
            AddOrRemove(propertyAccessor, value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(propertyName, v.Value, "Border width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }
        
        protected void AddOrRemovePeripheries(MethodBase propertyAccessor, int? value, [CallerMemberName] string propertyName = null)
        {
            AddOrRemove(propertyAccessor, value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(propertyName, v.Value, "The number of peripheries must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }
    }
}