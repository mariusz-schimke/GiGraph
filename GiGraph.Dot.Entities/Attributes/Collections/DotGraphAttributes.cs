using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotGraphAttributes : DotEntityAttributes, IDotGraphAttributes
    {
        public virtual DotRankDirection? LayoutDirection
        {
            get => TryGetValueAs<DotRankDirection>("rankdir", out var result) ? result : (DotRankDirection?) null;
            set => AddOrRemove("rankdir", value, v => new DotRankDirectionAttribute("rankdir", v.Value));
        }

        public virtual DotEdgeShape? EdgeShape
        {
            get => TryGetValueAs<DotEdgeShape>("splines", out var result) ? result : (DotEdgeShape?) null;
            set => AddOrRemove("splines", value, v => new DotEdgeShapeAttribute("splines", v.Value));
        }

        public virtual bool? ConcentrateEdges
        {
            get => TryGetValueAs<bool>("concentrate", out var result) ? result : (bool?) null;
            set => AddOrRemove("concentrate", value, v => new DotBoolAttribute("concentrate", v.Value));
        }

        public virtual bool? Compound
        {
            get => TryGetValueAs<bool>("compound", out var result) ? result : (bool?) null;
            set => AddOrRemove("compound", value, v => new DotBoolAttribute("compound", v.Value));
        }

        public virtual bool? ForceExternalLabels
        {
            get => TryGetValueAs<bool>("forcelabels", out var result) ? result : (bool?) null;
            set => AddOrRemove("forcelabels", value, v => new DotBoolAttribute("forcelabels", v.Value));
        }

        public virtual string FontPath
        {
            get => TryGetValueAs<string>("fontpath", out var result) ? result : null;
            set => AddOrRemove("fontpath", value, v => new DotStringAttribute("fontpath", v));
        }

        public virtual string Charset
        {
            get => TryGetValueAs<string>("charset", out var result) ? result : null;
            set => AddOrRemove("charset", value, v => new DotStringAttribute("charset", v));
        }

        public virtual double? NodeSpacing
        {
            get => TryGetValueAs<double>("nodesep", out var result) ? result : (double?) null;
            set => AddOrRemove("nodesep", value, v => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(NodeSpacing), v.Value, "Node spacing must be greater than or equal to 0.")
                : new DotDoubleAttribute("nodesep", v.Value));
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

                if (TryGetValueAs<double>(key, out var value))
                {
                    return value;
                }

                return TryGetValueAs<double[]>(key, out var values) ? values : null;
            }
            set => AddOrRemove("ranksep", value, v => new DotRankSeparationAttribute("ranksep", v));
        }
    }
}