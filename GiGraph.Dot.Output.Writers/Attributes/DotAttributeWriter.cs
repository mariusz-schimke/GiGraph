namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotAttributeWriter : DotEntityWriter, IDotAttributeWriter
    {
        public DotAttributeWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool enforceBlockComment)
            : base(tokenWriter, configuration, enforceBlockComment)
        {
        }

        public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
        {
            _tokenWriter.Identifier(key, quoteKey)
               .Space()
               .ValueAssignmentOperator()
               .Space()
               .Identifier(value, quoteValue);
        }

        public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool writeInBrackets)
        {
            _tokenWriter.Identifier(key, quoteKey)
               .Space()
               .ValueAssignmentOperator()
               .Space()
               .Html(value, writeInBrackets);
        }

        public override void EndComment()
        {
            if (_enforceBlockComment)
            {
                _tokenWriter.Space();
            }
            else
            {
                base.EndComment();
            }
        }
    }
}