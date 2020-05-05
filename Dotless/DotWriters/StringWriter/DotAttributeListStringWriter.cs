using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotAttributeListStringWriter : DotEntityStringWriter, IDotAttributeCollectionWriter
    {
        public DotAttributeListStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeStringWriter(_writer, _options, _level);
        }

        public virtual void EndAttribute()
        {
            _writer.AttributeSeparator(linger: true)
                   .LineBreak(linger: true)
                   .Indentation(_level, linger: true);
        }
    }
}
