﻿namespace GiGraph.Dot.Output.Writers.Attributes.Node
{
    public class DotGlobalNodeAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalNodeAttributesWriter
    {
        public DotGlobalNodeAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, configuration.Formatting.GlobalAttributes.SingleLineNodeAttributeList)
        {
        }

        public virtual void WriteNodeKeyword()
        {
            _tokenWriter.Keyword("node")
               .Space(linger: true);
        }
    }
}