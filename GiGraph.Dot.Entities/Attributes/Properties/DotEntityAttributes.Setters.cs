using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract partial class DotEntityAttributes
    {
        protected virtual void SetOrRemove<TAttribute, TValue>(MethodBase propertyAccessor, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            _attributes.SetOrRemove(GetKey(propertyAccessor), value, newAttribute);
        }

        protected void SetOrRemoveComplexAttribute<TComplexType>(MethodBase propertyAccessor, TComplexType value)
            where TComplexType : IDotEncodable
        {
            SetOrRemove(propertyAccessor, value, (k, v) => new DotComplexAttribute<TComplexType>(k, v));
        }

        protected void SetOrRemoveBorderWidth(MethodBase propertyAccessor, double? value, [CallerMemberName] string propertyName = null)
        {
            SetOrRemove(propertyAccessor, value, (k, v) => v!.Value < 0.0
                ? throw new ArgumentOutOfRangeException(propertyName, v!.Value, "Border width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v!.Value));
        }

        protected void SetOrRemovePeripheries(MethodBase propertyAccessor, int? value, [CallerMemberName] string propertyName = null)
        {
            SetOrRemove(propertyAccessor, value, (k, v) => v!.Value < 0
                ? throw new ArgumentOutOfRangeException(propertyName, v!.Value, "The number of peripheries must be greater than or equal to 0.")
                : new DotIntAttribute(k, v!.Value));
        }
    }
}