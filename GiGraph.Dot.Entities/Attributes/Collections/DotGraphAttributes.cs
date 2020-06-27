using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotGraphAttributes : DotEntityAttributes, IDotGraphAttributes
    {
        public virtual DotRankDirection? LayoutDirection
        {
            get => TryGetValueAs<DotRankDirection>("rankdir", out var result) ? result : (DotRankDirection?) null;
            set => AddOrRemove("rankdir", value, v => new DotRankDirectionAttribute("rankdir", v.Value));
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

        public virtual string FontPath
        {
            get => TryGetValueAs<string>("fontpath", out var result) ? result : null;
            set => AddOrRemove("fontpath", value, v => new DotStringAttribute("fontpath", v));
        }

        public override void SetFilled(DotColorDefinition value) => BackgroundColor = value;
    }
}