using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers
{
    public class DotSeparableEntityWriter
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected bool? _isSeparated;
        protected bool _prependIndentation;

        public DotSeparableEntityWriter(DotTokenWriter tokenWriter)
        {
            _tokenWriter = tokenWriter;
        }

        public virtual DotTokenWriter BeginEntity(bool enforceSeparation = false)
        {
            return _tokenWriter.CloneWith(
                tw => tw.OnBeforeAppendToken = (sender, e) =>
                {
                    tw.OnBeforeAppendToken = null;
                    enforceSeparation |= e.IsCommentStartToken;

                    if (false == _isSeparated && enforceSeparation)
                    {
                        tw.NewLine();
                    }
                    else if (_prependIndentation)
                    {
                        tw.Indentation();
                    }

                    _isSeparated = enforceSeparation;
                });
        }

        public virtual void EndEntity(bool linger = true, bool enforceLineBreak = true)
        {
            // the assumption is that a commented attribute needs to have an empty line above and below
            if (true == _isSeparated)
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
}