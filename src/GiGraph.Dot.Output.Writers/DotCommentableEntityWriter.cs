using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers
{
    public class DotCommentableEntityWriter
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected bool? _isCommented;
        protected bool _prependIndentation;

        public DotCommentableEntityWriter(DotTokenWriter tokenWriter)
        {
            _tokenWriter = tokenWriter;
        }

        public virtual DotTokenWriter BeginEntity()
        {
            return _tokenWriter.CloneWith(
                tw => tw.OnBeforeAppendToken = (sender, e) =>
                {
                    tw.OnBeforeAppendToken = null;

                    if (false == _isCommented && e.IsCommentStartToken)
                    {
                        tw.NewLine();
                    }
                    else if (_prependIndentation)
                    {
                        tw.Indentation();
                    }

                    _isCommented = e.IsCommentStartToken;
                });
        }

        public virtual void EndEntity(bool linger = true, bool enforceLineBreak = true)
        {
            // the assumption is that a commented attribute needs to have an empty line above and below
            if (true == _isCommented)
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