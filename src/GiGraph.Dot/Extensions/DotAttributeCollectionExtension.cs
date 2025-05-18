using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Graphs.Canvas.Scaling;
using GiGraph.Dot.Types.Graphs.Layout.Packing;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;
using GiGraph.Dot.Types.Identifiers;

namespace GiGraph.Dot.Extensions;

public static class DotAttributeCollectionExtension
{
    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="double"/>. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetNumberValue(this DotAttributeCollection attributes, string key, out double value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotColor"/>. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotColor value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotColorDefinition"/>. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotColorDefinition value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotEscapeString"/>. If the attribute is found, but its value cannot be cast nor converted to the returned type, an
    ///     exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotEscapeString value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotLabel"/>. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotLabel value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotArrowheadDefinition"/>. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotArrowheadDefinition value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotPackingDefinition"/>. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotPackingDefinition value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotPackingModeDefinition"/>. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotPackingModeDefinition value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotRankSeparationDefinition"/>. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotRankSeparationDefinition value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotGraphScalingDefinition"/>. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotGraphScalingDefinition value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     <see cref="DotEndpointPort"/>. If the attribute is found, but its value cannot be cast nor converted to the returned type, an
    ///     exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotEndpointPort value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotId"/>. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotId value)
    {
        if (attributes.Get(key) is not { } attribute)
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
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotClusterId"/>.
    ///     If the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetComplexValue(this DotAttributeCollection attributes, string key, [MaybeNullWhen(false)] out DotClusterId value)
    {
        if (attributes.Get(key) is not { } attribute)
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