using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Properties;

public abstract partial class DotEntityAttributes
{
    protected virtual bool GetValueAs<T>(MethodBase propertyAccessor, [MaybeNullWhen(false)] out T value) =>
        _attributes.GetValueAs(GetKey(propertyAccessor), out value);

    protected virtual bool GetValueAs<T>(MethodBase propertyAccessor, [MaybeNullWhen(false)] out T value, params Func<object, (bool IsValid, T Result)>[]? converters) =>
        _attributes.GetValueAs(GetKey(propertyAccessor), out value, converters);

    protected virtual int? GetValueAsInt(MethodBase propertyAccessor) =>
        _attributes.GetValueAsInt(GetKey(propertyAccessor));

    protected virtual double? GetValueAsDouble(MethodBase propertyAccessor) =>
        _attributes.GetValueAsDouble(GetKey(propertyAccessor));

    protected virtual bool? GetValueAsBool(MethodBase propertyAccessor) =>
        _attributes.GetValueAsBool(GetKey(propertyAccessor));

    protected virtual DotColor? GetValueAsColor(MethodBase propertyAccessor) =>
        _attributes.GetValueAsColor(GetKey(propertyAccessor));

    protected virtual DotPoint? GetValueAsPoint(MethodBase propertyAccessor) =>
        _attributes.GetValueAsPoint(GetKey(propertyAccessor));

    protected virtual DotColorDefinition? GetValueAsColorDefinition(MethodBase propertyAccessor) =>
        _attributes.GetValueAsColorDefinition(GetKey(propertyAccessor));

    protected virtual DotLabel? GetValueAsLabel(MethodBase propertyAccessor) =>
        _attributes.GetValueAsLabel(GetKey(propertyAccessor));

    protected virtual string? GetValueAsString(MethodBase propertyAccessor) =>
        _attributes.GetValueAsString(GetKey(propertyAccessor));

    protected virtual DotEscapeString? GetValueAsEscapeString(MethodBase propertyAccessor) =>
        _attributes.GetValueAsEscapeString(GetKey(propertyAccessor));

    protected virtual DotArrowheadDefinition? GetValueAsArrowheadDefinition(MethodBase propertyAccessor) =>
        _attributes.GetValueAsArrowheadDefinition(GetKey(propertyAccessor));

    protected virtual DotPackingDefinition? GetValueAsPackingDefinition(MethodBase propertyAccessor) =>
        _attributes.GetValueAsPackingDefinition(GetKey(propertyAccessor));

    protected virtual DotPackingModeDefinition? GetValueAsPackingModeDefinition(MethodBase propertyAccessor) =>
        _attributes.GetValueAsPackingModeDefinition(GetKey(propertyAccessor));

    protected virtual DotRankSeparationDefinition? GetValueAsRankSeparationDefinition(MethodBase propertyAccessor) =>
        _attributes.GetValueAsRankSeparationDefinition(GetKey(propertyAccessor));

    protected virtual DotGraphScalingDefinition? GetValueAsGraphScalingDefinition(MethodBase propertyAccessor) =>
        _attributes.GetValueAsGraphScalingDefinition(GetKey(propertyAccessor));

    protected virtual DotEndpointPort? GetValueAsEndpointPort(MethodBase propertyAccessor) =>
        _attributes.GetValueAsEndpointPort(GetKey(propertyAccessor));

    protected virtual DotId? GetValueAsId(MethodBase propertyAccessor) =>
        _attributes.GetValueAsId(GetKey(propertyAccessor));

    protected virtual DotClusterId? GetValueAsClusterId(MethodBase propertyAccessor) =>
        _attributes.GetValueAsClusterId(GetKey(propertyAccessor));
}