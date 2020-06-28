using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotNodeAttributes : DotEntityAttributes, IDotNodeAttributes
    {
        public virtual DotShape? Shape
        {
            get => TryGetValueAs<DotShape>("shape", out var result) ? result : (DotShape?) null;
            set => AddOrRemove("shape", value, v => new DotShapeAttribute("shape", v.Value));
        }

        public virtual int? Sides
        {
            get => TryGetValueAs<int>("sides", out var result) ? result : (int?) null;
            set => AddOrRemove("sides", value, v => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Sides), v.Value, "The number of sides must be greater than or equal to 0.")
                : new DotIntAttribute("sides", v.Value));
        }

        public virtual bool? Regular
        {
            get => TryGetValueAs<bool>("regular", out var result) ? result : (bool?) null;
            set => AddOrRemove("regular", value, v => new DotBoolAttribute("regular", v.Value));
        }

        public virtual double? Skew
        {
            get => TryGetValueAs<double>("skew", out var result) ? result : (double?) null;
            set => AddOrRemove("skew", value, v => new DotDoubleAttribute("skew", v.Value));
        }

        public virtual double? Distortion
        {
            get => TryGetValueAs<double>("distortion", out var result) ? result : (double?) null;
            set => AddOrRemove("distortion", value, v => new DotDoubleAttribute("distortion", v.Value));
        }

        public virtual double? Orientation
        {
            get => TryGetValueAs<double>("orientation", out var result) ? result : (double?) null;
            set => AddOrRemove("orientation", value, v => new DotDoubleAttribute("orientation", v.Value));
        }

        public virtual double? Width
        {
            get => TryGetValueAs<double>("width", out var result) ? result : (double?) null;
            set => AddOrRemove("width", value, v => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Width), v.Value, "The width must be greater than or equal to 0.")
                : new DotDoubleAttribute("width", v.Value));
        }

        public virtual double? Height
        {
            get => TryGetValueAs<double>("height", out var result) ? result : (double?) null;
            set => AddOrRemove("height", value, v => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Height), v.Value, "The height must be greater than or equal to 0.")
                : new DotDoubleAttribute("height", v.Value));
        }

        public virtual DotFixedSize? FixedSize
        {
            get => TryGetValueAs<DotFixedSize>("fixedsize", out var result) ? result : (DotFixedSize?) null;
            set => AddOrRemove("fixedsize", value, v => new DotFixedSizeAttribute("fixedsize", v.Value));
        }

        public override void SetFilled(DotColorDefinition value)
        {
            Style = Style.GetValueOrDefault(DotStyle.Filled) | DotStyle.Filled;
            FillColor = value;
        }
    }
}