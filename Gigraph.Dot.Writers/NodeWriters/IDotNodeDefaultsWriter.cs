﻿using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeDefaultsWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeKeyword();
    }
}