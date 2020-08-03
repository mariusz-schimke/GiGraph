using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Entities;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.AspectRatio;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotGraphAttributeCollection : DotEntityAttributeCollection<IDotGraphAttributes>, IDotGraphAttributeCollection
    {
        [DotAttributeKey("rankdir")]
        public virtual DotRankDirection? LayoutDirection
        {
            get => GetValueAs<DotRankDirection>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotRankDirection?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankDirectionAttribute(k, v.Value));
        }

        [DotAttributeKey("splines")]
        public virtual DotEdgeShape? EdgeShape
        {
            get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeShape?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeShapeAttribute(k, v.Value));
        }

        [DotAttributeKey("clusterrank")]
        public virtual DotClusterMode? ClusterRank
        {
            get => GetValueAs<DotClusterMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotClusterMode?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotClusterModeAttribute(k, v.Value));
        }

        [DotAttributeKey("concentrate")]
        public virtual bool? ConcentrateEdges
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("compound")]
        public virtual bool? Compound
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("forcelabels")]
        public virtual bool? ForceExternalLabels
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("fontpath")]
        public virtual string FontDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("charset")]
        public virtual string Charset
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("nodesep")]
        public virtual double? NodeSeparation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(NodeSeparation), v.Value, "Node separation must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("ranksep")]
        public virtual DotRankSeparationDefinition RankSeparation
        {
            get
            {
                var key = GetKey(MethodBase.GetCurrentMethod());

                if (TryGetValueAs<DotRankSeparationDefinition>(key, out var definition))
                {
                    return definition;
                }

                if (TryGetValueAs<double>(key, out var number))
                {
                    return number;
                }

                return TryGetValueAs<double[]>(key, out var array) ? array : null;
            }
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankSeparationAttribute(k, v));
        }

        [DotAttributeKey("rotate")]
        public virtual int? RotateBy
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("imagepath")]
        public virtual string ImageDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("pad")]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey("size")]
        public virtual DotPoint Size
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey("ratio")]
        public virtual DotAspectRatioDefinition AspectRatio
        {
            get
            {
                var key = GetKey(MethodBase.GetCurrentMethod());

                if (TryGetValueAs<DotAspectRatioDefinition>(key, out var definition))
                {
                    return definition;
                }

                return TryGetValueAs<double>(key, out var number) ? number : (double?) null;
            }
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotAspectRatioDefinitionAttribute(k, v));
        }
    }
}