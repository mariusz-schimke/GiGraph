﻿using System.Diagnostics.Contracts;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Graphs;

namespace GiGraph.Dot.Output.Generators.Graphs;

public class DotGraphGeneratorBuilder : IDotGraphGeneratorBuilder
{
    protected readonly IDotEntityGeneratorsProviderBuilder _dotEntityGeneratorsProviderBuilder;

    public DotGraphGeneratorBuilder(IDotEntityGeneratorsProviderBuilder dotEntityGeneratorsProviderBuilder)
    {
        _dotEntityGeneratorsProviderBuilder = dotEntityGeneratorsProviderBuilder;
    }

    /// <summary>
    ///     Builds a DOT graph generator initialized with entity generators provided to the current instance.
    /// </summary>
    /// <param name="syntaxRules">
    ///     The syntax rules to follow.
    /// </param>
    /// <param name="options">
    ///     The DOT language generation options to use for graph generation and its components.
    /// </param>
    [Pure]
    public virtual IDotEntityGenerator<IDotGraphWriterRoot> Build(DotSyntaxRules syntaxRules, DotSyntaxOptions options)
    {
        var providers = _dotEntityGeneratorsProviderBuilder.Build(syntaxRules, options);
        return providers.Get<DotGraphGenerator>();
    }
}