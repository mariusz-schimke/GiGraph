using System;
using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Attributes.Collections;

public partial class DotAttributeCollection
{
    /// <summary>
    ///     Adds or replaces the specified attribute in the collection.
    /// </summary>
    /// <param name="attribute">
    ///     The attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(DotAttribute attribute)
    {
        this[attribute.Key] = attribute;
        return this;
    }

    protected internal virtual void SetOrRemove<TAttribute, TValue>(string key, TValue value, Func<string, TValue, TAttribute> newAttribute)
        where TAttribute : DotAttribute
    {
        SetOrRemove(key, value is null ? null : newAttribute(key, value));
    }

    protected internal virtual void SetOrRemove(string key, DotEscapeString value)
    {
        SetOrRemove(key, value, _attributeFactory.CreateEscapeString);
    }

    protected internal virtual void SetOrRemove(string key, string value)
    {
        SetOrRemove(key, value, _attributeFactory.CreateString);
    }

    protected internal virtual void SetOrRemove(string key, int? value)
    {
        SetOrRemove(key, value, (k, v) => _attributeFactory.CreateInt(k, v!.Value));
    }

    protected internal virtual void SetOrRemove(string key, double? value)
    {
        SetOrRemove(key, value, (k, v) => _attributeFactory.CreateDouble(k, v!.Value));
    }

    protected internal virtual void SetOrRemove(string key, double[] value)
    {
        SetOrRemove(key, value, _attributeFactory.CreateDoubleArray);
    }

    protected internal virtual void SetOrRemove(string key, bool? value)
    {
        SetOrRemove(key, value, (k, v) => _attributeFactory.CreateBool(k, v!.Value));
    }

    protected internal virtual void SetOrRemoveComplex<TComplex>(string key, TComplex value)
        where TComplex : IDotEncodable
    {
        SetOrRemove(key, value, _attributeFactory.CreateComplex);
    }

    protected internal virtual void SetOrRemoveComplex<TComplex>(string key, TComplex[] value)
        where TComplex : IDotEncodable
    {
        SetOrRemove(key, value, _attributeFactory.CreateComplexArray);
    }

    protected internal virtual void SetOrRemoveEnum<TEnum>(string key, bool hasValue, Func<TEnum> value)
        where TEnum : Enum
    {
        SetOrRemove(key, hasValue ? _attributeFactory.CreateEnum(key, value()) : null);
    }

    protected virtual void SetOrRemove<T>(string key, T attribute)
        where T : DotAttribute
    {
        if (attribute is not null)
        {
            Set(attribute);
        }
        else
        {
            Remove(key);
        }
    }

    /// <summary>
    ///     Adds or replaces the specified attributes in the collection.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to include in the collection.
    /// </param>
    public virtual void SetRange(IEnumerable<DotAttribute> attributes)
    {
        foreach (var attribute in attributes)
        {
            Set(attribute);
        }
    }

    /// <summary>
    ///     Sets a null value for the specified attribute key.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute whose value to set.
    /// </param>
    public virtual DotAttributeCollection Nullify(string key) => Set(_attributeFactory.CreateNull(key));

    /// <summary>
    ///     Adds or replaces the specified attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(string key, string value) => Set(_attributeFactory.CreateString(key, value));

    /// <summary>
    ///     Adds or replaces the specified escape string attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set<TEscapeString>(string key, TEscapeString value)
        where TEscapeString : DotEscapeString =>
        Set(_attributeFactory.CreateEscapeString(key, value));

    /// <summary>
    ///     Adds or replaces the specified integer value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(string key, int value) => Set(_attributeFactory.CreateInt(key, value));

    /// <summary>
    ///     Adds or replaces the specified double value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(string key, double value) => Set(_attributeFactory.CreateDouble(key, value));

    /// <summary>
    ///     Adds or replaces the specified double list value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(string key, double[] value) => Set(_attributeFactory.CreateDoubleArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified double list value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(string key, IEnumerable<double> value) => Set(_attributeFactory.CreateDoubleArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified boolean value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(string key, bool value) => Set(_attributeFactory.CreateBool(key, value));

    /// <summary>
    ///     Adds or replaces the specified color value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection Set(string key, Color value) => Set(_attributeFactory.CreateColor(key, value));

    /// <summary>
    ///     Adds or replaces the specified enumeration value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection SetEnum<TEnum>(string key, TEnum value)
        where TEnum : Enum =>
        Set(_attributeFactory.CreateEnum(key, value));

    /// <summary>
    ///     Adds or replaces the specified complex type value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection SetComplex<TComplex>(string key, TComplex value)
        where TComplex : IDotEncodable =>
        Set(_attributeFactory.CreateComplex(key, value));

    /// <summary>
    ///     Adds or replaces the specified complex type value array attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection SetComplex<TComplex>(string key, TComplex[] value)
        where TComplex : IDotEncodable =>
        Set(_attributeFactory.CreateComplexArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified complex type value array attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection SetComplex<TComplex>(string key, IEnumerable<TComplex> value)
        where TComplex : IDotEncodable =>
        Set(_attributeFactory.CreateComplexArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified attribute in the collection. The value is rendered AS IS in the output DOT script, so the
    ///     attribute can be used for any type of value, not only for strings. Make sure, however, that the value is escaped when
    ///     necessary, following the DOT syntax rules ( <see href="https://www.graphviz.org/doc/info/lang.html" />). If, for instance, it
    ///     contains an unescaped quotation mark, the output script will be syntactically incorrect.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotAttributeCollection SetRaw(string key, string value) => Set(_attributeFactory.CreateRaw(key, value));
}