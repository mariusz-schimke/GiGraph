using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Writers
{
    public abstract class DotEntityWithAttributeListWriter : DotEntityWriter, IDotEntityWithAttributeListWriter
    {
        protected readonly bool _singleLineAttributeList;

        protected DotEntityWithAttributeListWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool singleLineAttributeList)
            : base(tokenWriter, configuration, enforceBlockComment: false)
        {
            _singleLineAttributeList = singleLineAttributeList;
        }

        public virtual IDotAttributeListItemWriter BeginAttributeList(bool useAttributeSeparator)
        {
            var tokenWriter = PrepareTokenWriter()
               .NewLine()
               .AttributeListStart()
               .NextIndentationLevel()
               .NewLine(linger: true);

            return new DotAttributeListItemWriter(tokenWriter, _configuration, useAttributeSeparator);
        }

        public virtual void EndAttributeList()
        {
            PrepareTokenWriter()
               .NewLine()
               .AttributeListEnd();
        }

        protected virtual DotTokenWriter PrepareTokenWriter()
        {
            var tokenWriter = _tokenWriter.ClearLingerBuffer();

            if (_singleLineAttributeList)
            {
                tokenWriter = tokenWriter.SingleLine();
            }

            return tokenWriter;
        }
    }
}