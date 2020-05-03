using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Nodes;
using Dotless.Writers.Options;

namespace Dotless.Writers.NodeWriters
{
    public class DotGraphNodesWriter : DotEntityWriter<DotGraphNodes>
    {
        public DotGraphNodesWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotGraphNodes nodes, DotStringWriter writer)
        {
            var nodesContext = writer.AssertContext<DotStringWriter.GraphNodesContext>();

            foreach (var node in nodes)
            {
                _entityGenerators.GetForTypeOrForAnyBaseType(node).Write(node, nodesContext);
            }
        }
    }
}
