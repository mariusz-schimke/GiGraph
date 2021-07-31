using System;
using System.Reflection;
using GiGraph.Dot.Output;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract partial class DotEntityAttributes
    {
        protected virtual void SetOrRemove<TAttribute, TValue>(MethodBase propertyAccessor, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            _attributes.SetOrRemove(GetKey(propertyAccessor), value, newAttribute);
        }

        protected void SetOrRemove<TComplex>(MethodBase propertyAccessor, TComplex value)
            where TComplex : IDotEncodable
        {
            _attributes.SetOrRemoveComplex(GetKey(propertyAccessor), value);
        }

        protected void SetOrRemove(MethodBase propertyAccessor, DotEscapeString value)
        {
            _attributes.SetOrRemove(GetKey(propertyAccessor), value);
        }

        protected void SetOrRemove(MethodBase propertyAccessor, string value)
        {
            _attributes.SetOrRemove(GetKey(propertyAccessor), value);
        }

        protected void SetOrRemove(MethodBase propertyAccessor, int? value)
        {
            _attributes.SetOrRemove(GetKey(propertyAccessor), value);
        }

        protected void SetOrRemove(MethodBase propertyAccessor, double? value)
        {
            _attributes.SetOrRemove(GetKey(propertyAccessor), value);
        }

        protected void SetOrRemove(MethodBase propertyAccessor, bool? value)
        {
            _attributes.SetOrRemove(GetKey(propertyAccessor), value);
        }

        protected void SetOrRemove<TEnum>(MethodBase propertyAccessor, bool hasValue, Func<TEnum> value)
            where TEnum : Enum
        {
            _attributes.SetOrRemoveEnum(GetKey(propertyAccessor), hasValue, value);
        }
    }
}