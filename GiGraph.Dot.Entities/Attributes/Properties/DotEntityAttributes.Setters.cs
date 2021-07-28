using System;
using System.Reflection;
using System.Runtime.CompilerServices;
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

        protected void SetOrRemoveComplexAttribute<TComplex>(MethodBase propertyAccessor, TComplex value)
            where TComplex : IDotEncodable
        {
            SetOrRemove(propertyAccessor, value, (k, v) => new DotComplexAttribute<TComplex>(k, v));
        }

        protected void SetOrRemoveEscapeStringAttribute(MethodBase propertyAccessor, DotEscapeString value)
        {
            SetOrRemove(propertyAccessor, value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        protected void SetOrRemoveStringAttribute(MethodBase propertyAccessor, string value)
        {
            SetOrRemove(propertyAccessor, value, (k, v) => new DotStringAttribute(k, v));
        }

        protected void SetOrRemoveEnumAttribute<TEnum>(MethodBase propertyAccessor, bool hasValue, Func<TEnum> value)
            where TEnum : Enum
        {
            var key = GetKey(propertyAccessor);

            if (hasValue)
            {
                _attributes.Set(new DotEnumAttribute<TEnum>(key, value()));
            }
            else
            {
                _attributes.Remove(key);
            }
        }

        protected void SetOrRemoveNumericAttribute(MethodBase propertyAccessor, int? value)
        {
            SetOrRemove(propertyAccessor, value, (k, v) => new DotIntAttribute(k, v!.Value));
        }

        protected void SetOrRemoveNumericAttribute(MethodBase propertyAccessor, double? value)
        {
            SetOrRemove(propertyAccessor, value, (k, v) => new DotDoubleAttribute(k, v!.Value));
        }

        protected void SetOrRemoveBoolAttribute(MethodBase propertyAccessor, bool? value)
        {
            SetOrRemove(propertyAccessor, value, (k, v) => new DotBoolAttribute(k, v!.Value));
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