using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Attributes;

public class DotAttributeListItemWriter : DotEntityWriter, IDotAttributeListItemWriter
{
    protected readonly DotPaddedEntityWriter _paddedEntityWriter;
    protected readonly bool _useAttributeSeparator;

    public DotAttributeListItemWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useAttributeSeparator)
        : base(tokenWriter, configuration, enforceBlockComment: true)
    {
        _useAttributeSeparator = useAttributeSeparator;
        _paddedEntityWriter = new DotPaddedEntityWriter(tokenWriter);
    }

    public virtual IDotAttributeWriter BeginAttribute() => new DotAttributeWriter(_paddedEntityWriter.BeginEntity(), _configuration);

    public virtual void EndAttribute()
    {
        if (_useAttributeSeparator)
        {
            _tokenWriter.AttributeSeparator(linger: true);
        }

        _paddedEntityWriter.EndEntity(linger: true, enforceLineBreak: false);
    }

    public override void EndComment()
    {
        EmptyLine();
    }
}