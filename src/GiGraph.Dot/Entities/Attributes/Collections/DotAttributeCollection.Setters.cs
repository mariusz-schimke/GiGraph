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
    /// <typeparam name="TAttribute">
    ///     The type of attribute.
    /// </typeparam>
    public virtual TAttribute Put<TAttribute>(TAttribute attribute)
        where TAttribute : DotAttribute
    {
        _attributes[attribute.Key] = attribute ?? throw new ArgumentNullException(nameof(attribute), "Attribute must not be null.");
        return attribute;
    }

    /// <summary>
    ///     Adds or replaces the specified attributes in the collection.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to include in the collection.
    /// </param>
    public virtual void PutRange(IEnumerable<DotAttribute> attributes)
    {
        foreach (var attribute in attributes)
        {
            Put(attribute);
        }
    }

    /// <summary>
    ///     Adds or removes the specified attribute from the collection. The attribute is removed if it is null.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute used for removal.
    /// </param>
    /// <param name="attribute">
    ///     The attribute to add.
    /// </param>
    /// <typeparam name="TAttribute">
    ///     The type of attribute.
    /// </typeparam>
    protected virtual void PutOrRemove<TAttribute>(string key, TAttribute? attribute)
        where TAttribute : DotAttribute
    {
        if (attribute is not null)
        {
            Put(attribute);
        }
        else
        {
            _attributes.Remove(key);
        }
    }

    protected internal virtual void SetOrRemove(string key, string? value)
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateString(key, value));
    }

    protected internal virtual void SetOrRemove(string key, DotEscapeString? value)
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateEscapeString(key, value));
    }

    protected internal virtual void SetOrRemove(string key, int? value)
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateInt(key, value.Value));
    }

    protected internal virtual void SetOrRemove(string key, double? value)
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateDouble(key, value.Value));
    }

    protected internal virtual void SetOrRemove(string key, double[]? value)
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateDoubleArray(key, value));
    }

    protected internal virtual void SetOrRemove(string key, bool? value)
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateBool(key, value.Value));
    }

    protected internal virtual void SetOrRemove<TComplex>(string key, TComplex? value)
        where TComplex : IDotEncodable
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateComplex(key, value));
    }

    protected internal virtual void SetOrRemove<TComplex>(string key, TComplex[]? value)
        where TComplex : IDotEncodable
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateComplexArray(key, value));
    }

    protected internal virtual void SetOrRemove<TEnum>(string key, TEnum? value)
        where TEnum : struct, Enum
    {
        PutOrRemove(key, value is null ? null : _attributeFactory.CreateEnum(key, value.Value));
    }

    /// <summary>
    ///     Sets a null value for the specified attribute key.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute whose value to set.
    /// </param>
    public virtual DotNullAttribute Nullify(string key) => Put(_attributeFactory.CreateNull(key));

    /// <summary>
    ///     Adds or replaces the specified attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotStringAttribute Set(string key, string value) => Put(_attributeFactory.CreateString(key, value));

    /// <summary>
    ///     Adds or replaces the specified escape string attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotEscapeStringAttribute Set<TEscapeString>(string key, TEscapeString value)
        where TEscapeString : DotEscapeString =>
        Put(_attributeFactory.CreateEscapeString(key, value));

    /// <summary>
    ///     Adds or replaces the specified integer value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotIntAttribute Set(string key, int value) => Put(_attributeFactory.CreateInt(key, value));

    /// <summary>
    ///     Adds or replaces the specified double value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotDoubleAttribute Set(string key, double value) => Put(_attributeFactory.CreateDouble(key, value));

    /// <summary>
    ///     Adds or replaces the specified double list value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotDoubleArrayAttribute Set(string key, double[] value) => Put(_attributeFactory.CreateDoubleArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified double list value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotDoubleArrayAttribute Set(string key, IEnumerable<double> value) => Put(_attributeFactory.CreateDoubleArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified boolean value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotBoolAttribute Set(string key, bool value) => Put(_attributeFactory.CreateBool(key, value));

    /// <summary>
    ///     Adds or replaces the specified color value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotColorAttribute Set(string key, Color value) => Put(_attributeFactory.CreateColor(key, value));

    /// <summary>
    ///     Adds or replaces the specified enumeration value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotEnumAttribute<TEnum> SetEnum<TEnum>(string key, TEnum value)
        where TEnum : struct, Enum =>
        Put(_attributeFactory.CreateEnum(key, value));

    /// <summary>
    ///     Adds or replaces the specified complex type value attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotComplexTypeAttribute<TComplex> SetComplex<TComplex>(string key, TComplex value)
        where TComplex : IDotEncodable =>
        Put(_attributeFactory.CreateComplex(key, value));

    /// <summary>
    ///     Adds or replaces the specified complex type value array attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotComplexTypeArrayAttribute<TComplex> SetComplex<TComplex>(string key, TComplex[] value)
        where TComplex : IDotEncodable =>
        Put(_attributeFactory.CreateComplexArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified complex type value array attribute in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotComplexTypeArrayAttribute<TComplex> SetComplex<TComplex>(string key, IEnumerable<TComplex> value)
        where TComplex : IDotEncodable =>
        Put(_attributeFactory.CreateComplexArray(key, value));

    /// <summary>
    ///     Adds or replaces the specified attribute in the collection. The value is rendered AS IS in the output DOT script, so the
    ///     attribute can be used for any type of value, not only for strings. Make sure, however, that the value is escaped when
    ///     necessary, following the DOT syntax rules (see
    ///     <see href="https://www.graphviz.org/doc/info/lang.html">
    ///         documentation
    ///     </see>
    ///     ). If, for instance, it contains an unescaped quotation mark, the output script will be syntactically incorrect.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to include in the collection.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute to include in the collection.
    /// </param>
    public virtual DotRawAttribute SetRaw(string key, string value) => Put(_attributeFactory.CreateRaw(key, value));
}