using System;
using System.Collections.Generic;

namespace Dotless.GraphElements
{
    public abstract class GraphElement
    {
        public IDictionary<Type, Attribute> Attributes { get; } = new Dictionary<Type, Attribute>();
    }
}
