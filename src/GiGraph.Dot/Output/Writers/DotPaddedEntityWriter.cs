using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers;

public class DotPaddedEntityWriter
{
    protected readonly DotTokenWriter _tokenWriter;
    protected bool? _isPadded;
    protected bool _prependIndentation;

    public DotPaddedEntityWriter(DotTokenWriter tokenWriter)
    {
        _tokenWriter = tokenWriter;
    }

    public virtual DotTokenWriter BeginEntity(bool enforcePadding = false)
    {
        return _tokenWriter.CloneWith(
            tw => tw.OnBeforeAppendToken = (_, e) =>
            {
                tw.OnBeforeAppendToken = null;
                enforcePadding |= e.IsCommentStartToken;

                if (false == _isPadded && enforcePadding)
                {
                    tw.NewLine();
                }
                else if (_prependIndentation)
                {
                    tw.Indentation();
                }

                _isPadded = enforcePadding;
            });
    }

    public virtual void EndEntity(bool linger = true, bool enforceLineBreak = true)
    {
        // the assumption is that a commented attribute needs to have an empty line above and below
        if (true == _isPadded)
        {
            _tokenWriter.EmptyLine(linger, enforceLineBreak);
            _prependIndentation = false;
        }
        else
        {
            _tokenWriter.LineBreak(linger && !enforceLineBreak);
            _prependIndentation = true;
        }
    }
}