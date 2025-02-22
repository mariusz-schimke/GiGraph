using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections;

public static class DotAttributeCollectionExtension
{
    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="double" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetNumber(this DotAttributeCollection @this, string key, out double value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = 0;
            return false;
        }

        if (attribute.TryGetValueAs<int>(out var integer))
        {
            value = integer;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotColor" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotColor value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<Color>(out var color))
        {
            value = color;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotColorDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotColorDefinition value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<Color>(out var color))
        {
            value = color;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEscapeString" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotEscapeString value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<string>(out var s))
        {
            value = (DotEscapedString) s;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotLabel" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotLabel value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<string>(out var s))
        {
            value = (DotEscapedString) s;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotArrowheadDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotArrowheadDefinition value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<DotArrowheadShape>(out var shape))
        {
            value = shape;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotPackingDefinition value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<bool>(out var toggle))
        {
            value = toggle;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingModeDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotPackingModeDefinition value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<DotPackingGranularity>(out var toggle))
        {
            value = toggle;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotRankSeparationDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotRankSeparationDefinition value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<int>(out var rankSeparationInt))
        {
            value = rankSeparationInt;
            return true;
        }

        if (attribute.TryGetValueAs<double>(out var rankSeparationDouble))
        {
            value = rankSeparationDouble;
            return true;
        }

        if (attribute.TryGetValueAs<double[]>(out var radialRankSeparation))
        {
            value = radialRankSeparation;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotGraphScalingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotGraphScalingDefinition value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<int>(out var scalingAspectRatioInt))
        {
            value = scalingAspectRatioInt;
            return true;
        }

        if (attribute.TryGetValueAs<double>(out var scalingAspectRatioDouble))
        {
            value = scalingAspectRatioDouble;
            return true;
        }

        if (attribute.TryGetValueAs<DotGraphScaling>(out var scalingOption))
        {
            value = scalingOption;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEndpointPort" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotEndpointPort value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<DotCompassPoint>(out var compassPoint))
        {
            value = compassPoint;
            return true;
        }

        if (attribute.TryGetValueAs<string>(out var s))
        {
            value = s;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotId" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotId value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<string>(out var s))
        {
            value = s;
            return true;
        }

        return attribute.GetValueAs(out value);
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotClusterId" />.
    ///     If the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplex(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotClusterId value)
    {
        if (@this.Get(key) is not { } attribute)
        {
            value = null;
            return false;
        }

        if (attribute.TryGetValueAs<string>(out var s))
        {
            value = s;
            return true;
        }

        return attribute.GetValueAs(out value);
    }
}