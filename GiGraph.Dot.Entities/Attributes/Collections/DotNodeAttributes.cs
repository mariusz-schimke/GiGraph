using System;
using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotNodeAttributes : DotEntityAttributes, IDotNodeAttributes
    {
        public virtual DotNodeShape? Shape
        {
            get => TryGetValueAs<DotNodeShape>("shape", out var result) ? result : (DotNodeShape?) null;
            set => AddOrRemove("shape", value, (k, v) => new DotNodeShapeAttribute(k, v.Value));
        }

        public virtual int? Sides
        {
            get => TryGetValueAs<int>("sides", out var result) ? result : (int?) null;
            set => AddOrRemove("sides", value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Sides), v.Value, "The number of sides must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }

        public virtual bool? Regular
        {
            get => TryGetValueAs<bool>("regular", out var result) ? result : (bool?) null;
            set => AddOrRemove("regular", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual double? Skew
        {
            get => TryGetValueAs<double>("skew", out var result) ? result : (double?) null;
            set => AddOrRemove("skew", value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        public virtual double? Distortion
        {
            get => TryGetValueAs<double>("distortion", out var result) ? result : (double?) null;
            set => AddOrRemove("distortion", value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        public virtual double? Orientation
        {
            get => TryGetValueAs<double>("orientation", out var result) ? result : (double?) null;
            set => AddOrRemove("orientation", value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        public virtual double? Width
        {
            get => TryGetValueAs<double>("width", out var result) ? result : (double?) null;
            set => AddOrRemove("width", value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Width), v.Value, "The width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual double? Height
        {
            get => TryGetValueAs<double>("height", out var result) ? result : (double?) null;
            set => AddOrRemove("height", value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Height), v.Value, "The height must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual DotNodeSizing? Sizing
        {
            get => TryGetValueAs<DotNodeSizing>("fixedsize", out var result) ? result : (DotNodeSizing?) null;
            set => AddOrRemove("fixedsize", value, (k, v) => new DotNodeFixedSizeAttribute(k, v.Value));
        }

        public virtual string ImagePath
        {
            get => TryGetValueAs<string>("image", out var result) ? result : null;
            set => AddOrRemove("image", value, (k, v) => new DotStringAttribute(k, v));
        }
    }
}