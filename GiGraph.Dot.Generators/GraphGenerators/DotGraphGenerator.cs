﻿using GiGraph.Dot.Core;
using GiGraph.Dot.Core.TextEscaping;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.GraphWriters;

namespace GiGraph.Dot.Generators.GraphGenerators
{
    public class DotGraphGenerator : DotCommonGraphGenerator<DotGraph, IDotGraphWriterRoot>
    {
        protected DotGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotGraph graph, IDotGraphWriterRoot writerRoot)
        {
            var writer = writerRoot.BeginGraph(graph.IsDirected);

            WriteDeclaration(graph.Id, graph.IsStrict, writer);
            WriteBody(graph, writer);

            writerRoot.EndGraph();
        }

        protected virtual void WriteDeclaration(string id, bool isStrict, IDotGraphWriter writer)
        {
            id = EscapeIdentifier(id);

            // whether the graph and its edges will be directed, is decided by the writer instance
            writer.WriteGraphDeclaration
            (
                id,
                isStrict,
                quoteId: IdentifierRequiresQuoting(id)
            );
        }
    }
}
