using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.AspectRatio;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotGraphAttributes : DotEntityAttributes, IDotGraphAttributes
    {
        public virtual DotRankDirection? LayoutDirection
        {
            get => TryGetValueAs<DotRankDirection>("rankdir", out var result) ? result : (DotRankDirection?) null;
            set => AddOrRemove("rankdir", value, (k, v) => new DotRankDirectionAttribute(k, v.Value));
        }

        public virtual DotEdgeShape? EdgeShape
        {
            get => TryGetValueAs<DotEdgeShape>("splines", out var result) ? result : (DotEdgeShape?) null;
            set => AddOrRemove("splines", value, (k, v) => new DotEdgeShapeAttribute(k, v.Value));
        }

        public virtual bool? ConcentrateEdges
        {
            get => TryGetValueAs<bool>("concentrate", out var result) ? result : (bool?) null;
            set => AddOrRemove("concentrate", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual bool? Compound
        {
            get => TryGetValueAs<bool>("compound", out var result) ? result : (bool?) null;
            set => AddOrRemove("compound", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual bool? ForceExternalLabels
        {
            get => TryGetValueAs<bool>("forcelabels", out var result) ? result : (bool?) null;
            set => AddOrRemove("forcelabels", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual string FontDirectories
        {
            get => TryGetValueAs<string>("fontpath", out var result) ? result : null;
            set => AddOrRemove("fontpath", value, (k, v) => new DotStringAttribute(k, v));
        }

        public virtual string Charset
        {
            get => TryGetValueAs<string>("charset", out var result) ? result : null;
            set => AddOrRemove("charset", value, (k, v) => new DotStringAttribute(k, v));
        }

        public virtual double? NodeSeparation
        {
            get => TryGetValueAs<double>("nodesep", out var result) ? result : (double?) null;
            set => AddOrRemove("nodesep", value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(NodeSeparation), v.Value, "Node separation must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual DotRankSeparationDefinition RankSeparation
        {
            get
            {
                const string key = "ranksep";

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
            set => AddOrRemove("ranksep", value, (k, v) => new DotRankSeparationAttribute(k, v));
        }

        public virtual int? RotateBy
        {
            get => TryGetValueAs<int>("rotate", out var result) ? result : (int?) null;
            set => AddOrRemove("rotate", value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        public virtual string ImageDirectories
        {
            get => TryGetValueAs<string>("imagepath", out var result) ? result : null;
            set => AddOrRemove("imagepath", value, (k, v) => new DotStringAttribute(k, v));
        }

        public virtual DotPoint Padding
        {
            get => TryGetValueAs<DotPoint>("pad", out var result) ? result : null;
            set => AddOrRemove("pad", value, (k, v) => new DotPointAttribute(k, v));
        }

        public virtual DotPoint Size
        {
            get => TryGetValueAs<DotPoint>("size", out var result) ? result : null;
            set => AddOrRemove("size", value, (k, v) => new DotPointAttribute(k, v));
        }

        public virtual DotAspectRatioDefinition AspectRatio
        {
            get
            {
                const string key = "ratio";

                if (TryGetValueAs<DotAspectRatioDefinition>(key, out var definition))
                {
                    return definition;
                }

                return TryGetValueAs<double>(key, out var number) ? number : (double?) null;
            }
            set => AddOrRemove("ratio", value, (k, v) => new DotAspectRatioDefinitionAttribute(k, v));
        }
    }
}