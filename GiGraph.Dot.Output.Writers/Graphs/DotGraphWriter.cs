namespace GiGraph.Dot.Output.Writers.Graphs
{
    public class DotGraphWriter : DotGraphBlockWriter, IDotGraphWriter
    {
        public DotGraphWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration)
        {
        }

        public virtual void WriteGraphDeclaration(string id, bool strict, bool quoteId)
        {
            if (strict)
            {
                _tokenWriter.Keyword("strict")
                   .Space();
            }

            if (_configuration.IsDirectedGraph)
            {
                _tokenWriter.Keyword("digraph");
            }
            else
            {
                _tokenWriter.Keyword("graph");
            }

            if (id != null)
            {
                _tokenWriter.Space()
                   .Identifier(id, quoteId);
            }

            _tokenWriter.LineBreak()
               .Indentation();
        }
    }
}