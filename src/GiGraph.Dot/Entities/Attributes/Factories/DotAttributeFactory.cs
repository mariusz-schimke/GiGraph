using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Attributes.Factories;

/// <summary>
///     Attribute factory.
/// </summary>
public class DotAttributeFactory
{
    /// <summary>
    ///     A static factory instance.
    /// </summary>
    public static DotAttributeFactory Instance { get; } = new();

    /// <summary>
    ///     Creates a new boolean attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotBoolAttribute CreateBool(string key, bool value) => new(key, value);

    /// <summary>
    ///     Creates a new integer attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotIntAttribute CreateInt(string key, int value) => new(key, value);

    /// <summary>
    ///     Creates a new double attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotDoubleAttribute CreateDouble(string key, double value) => new(key, value);

    /// <summary>
    ///     Creates a new double array attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotDoubleArrayAttribute CreateDoubleArray(string key, double[] value) => new(key, value);

    /// <summary>
    ///     Creates a new double array attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotDoubleArrayAttribute CreateDoubleArray(string key, IEnumerable<double> value) => CreateDoubleArray(key, value.ToArray());

    /// <summary>
    ///     Creates a new color attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotColorAttribute CreateColor(string key, Color value) => new(key, value);

    /// <summary>
    ///     Creates a new string attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotStringAttribute CreateString(string key, string value) => new(key, value);

    /// <summary>
    ///     Creates a new escape string attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotEscapeStringAttribute CreateEscapeString<TEscapeString>(string key, TEscapeString? value)
        where TEscapeString : DotEscapeString => new(key, value);

    /// <summary>
    ///     Creates a new enumeration attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotEnumAttribute<TEnum> CreateEnum<TEnum>(string key, TEnum value)
        where TEnum : Enum => new(key, value);

    /// <summary>
    ///     Creates a new complex type attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotComplexTypeAttribute<TComplex> CreateComplex<TComplex>(string key, TComplex value)
        where TComplex : IDotEncodable => new(key, value);

    /// <summary>
    ///     Creates a new complex type array attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotComplexTypeArrayAttribute<TComplex> CreateComplexArray<TComplex>(string key, TComplex[] value)
        where TComplex : IDotEncodable => new(key, value);

    /// <summary>
    ///     Creates a new complex type array attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotComplexTypeArrayAttribute<TComplex> CreateComplexArray<TComplex>(string key, IEnumerable<TComplex> value)
        where TComplex : IDotEncodable => CreateComplexArray(key, value.ToArray());

    /// <summary>
    ///     Creates a new raw value attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public virtual DotRawAttribute CreateRaw(string key, string value) => new(key, value);

    /// <summary>
    ///     Creates a new null value attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    public virtual DotNullAttribute CreateNull(string key) => new(key);
}