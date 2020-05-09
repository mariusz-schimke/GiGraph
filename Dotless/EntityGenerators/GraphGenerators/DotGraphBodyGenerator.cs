using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Edges;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;
using Dotless.Nodes;
using System.Linq;

namespace Dotless.EntityGenerators.GraphGenerators
{
    public class DotGraphBodyGenerator : DotEntityGenerator<DotGraphBody, IDotGraphBodyWriter>
    {
        public DotGraphBodyGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotGraphBody graphBody, IDotGraphBodyWriter writer)
        {
            WriteAttributes(graphBody.Attributes, writer);
            WriteNodes(graphBody.Nodes, writer);
            WriteEdges(graphBody.Edges, writer);
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotGraphBodyWriter writer)
        {
            var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Write(attributes, attributesWriter);
            writer.EndAttributesSection(attributes.Count());
        }

        protected virtual void WriteNodes(DotNodeCollection nodes, IDotGraphBodyWriter writer)
        {
            var nodesWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotNodeCollectionWriter>(nodes).Write(nodes, nodesWriter);
            writer.EndNodesSection(nodes.Count());
        }

        protected virtual void WriteEdges(DotEdgeCollection edges, IDotGraphBodyWriter writer)
        {
            var nodesWriter = writer.BeginEdgesSection(_options.PreferStatementDelimiter);
            _entityGenerators.GetForEntity<IDotEdgeCollectionWriter>(edges).Write(edges, nodesWriter);
            writer.EndEdgesSection(edges.Count());
        }
    }
}
