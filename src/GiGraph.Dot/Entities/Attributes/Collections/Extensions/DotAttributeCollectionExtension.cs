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

namespace GiGraph.Dot.Entities.Attributes.Collections.Extensions;

public static class DotAttributeCollectionExtension
{
    // todo: tu zmieniłem zachowanie, bo wcześniej rzucało wyjątek, a teraz zwraca false.
    // albo to zmienić albo zaktualizować komentarz

    // todo: sprawdzić, czy dla wszystkich typów deklarujących implicit operator są tu konwersje

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="double" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, out double value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<int>(key, out var integer))
        {
            value = integer;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotColor" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotColor value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<Color>(key, out var color))
        {
            value = new(color);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotColorDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotColorDefinition value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<Color>(key, out var color))
        {
            value = new DotColor(color);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEscapeString" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotEscapeString value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<string>(key, out var s))
        {
            value = (DotEscapedString) s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotLabel" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotLabel value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<string>(key, out var s))
        {
            value = (DotEscapedString) s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotArrowheadDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotArrowheadDefinition value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<DotArrowheadShape>(key, out var shape))
        {
            value = shape;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotPackingDefinition value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<bool>(key, out var toggle))
        {
            value = toggle;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingModeDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotPackingModeDefinition value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<DotPackingGranularity>(key, out var toggle))
        {
            value = toggle;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotRankSeparationDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotRankSeparationDefinition value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<int>(key, out var rankSeparationInt))
        {
            value = rankSeparationInt;
            return true;
        }

        if (@this.TryGetValueAs<double>(key, out var rankSeparationDouble))
        {
            value = rankSeparationDouble;
            return true;
        }

        if (@this.TryGetValueAs<double[]>(key, out var radialRankSeparation))
        {
            value = radialRankSeparation;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotGraphScalingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotGraphScalingDefinition value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<int>(key, out var scalingAspectRatioInt))
        {
            value = scalingAspectRatioInt;
            return true;
        }

        if (@this.TryGetValueAs<double>(key, out var scalingAspectRatioDouble))
        {
            value = scalingAspectRatioDouble;
            return true;
        }

        if (@this.TryGetValueAs<DotGraphScaling>(key, out var scalingOption))
        {
            value = scalingOption;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEndpointPort" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotEndpointPort value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<DotCompassPoint>(key, out var compassPoint))
        {
            value = compassPoint;
            return true;
        }

        if (@this.TryGetValueAs<string>(key, out var s))
        {
            value = s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotId" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotId value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<string>(key, out var s))
        {
            value = s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotClusterId" />.
    ///     If the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public static bool GetMultiTypedValue(this DotAttributeCollection @this, string key, [MaybeNullWhen(false)] out DotClusterId value)
    {
        if (@this.TryGetValueAs(key, out value))
        {
            return true;
        }

        if (@this.TryGetValueAs<string>(key, out var s))
        {
            value = s;
            return true;
        }

        return false;
    }
}