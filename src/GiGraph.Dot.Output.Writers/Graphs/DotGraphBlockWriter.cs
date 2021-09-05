using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Graphs
{
    public abstract class DotGraphBlockWriter : DotEntityWriter
    {
        protected DotGraphBlockWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, enforceBlockComment: false)
        {
        }

        public virtual IDotGraphBodyWriter BeginBody()
        {
            var tokenWriter = _tokenWriter.NextIndentationLevel();
            tokenWriter.BlockStart()
               .NewLine(linger: true, enforceLineBreak: true);

            return new DotGraphBodyWriter(tokenWriter, _configuration);
        }

        public virtual void EndBody()
        {
            _tokenWriter.ClearLingerBuffer();
            _tokenWriter.Indentation()
               .BlockEnd();
        }
    }
}