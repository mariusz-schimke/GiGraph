using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotAttributeListItemWriter : DotEntityWriter, IDotAttributeListItemWriter
    {
        protected readonly bool _useAttributeSeparator;
        protected bool _prependIndentation;
        protected bool? _wasAttributeCommented;

        public DotAttributeListItemWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useAttributeSeparator)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            var tokenWriterClone = _tokenWriter.CloneWith(
                tw => tw.OnBeforeAppendToken = (sender, e) =>
                {
                    tw.OnBeforeAppendToken = null;

                    if (false == _wasAttributeCommented && e.IsCommentStartToken)
                    {
                        tw.NewLine();
                    }
                    else if (_prependIndentation)
                    {
                        tw.Indentation();
                    }

                    _wasAttributeCommented = e.IsCommentStartToken;
                });

            return new DotAttributeWriter(tokenWriterClone, _configuration);
        }

        public virtual void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _tokenWriter.AttributeSeparator(linger: true);
            }

            // the assumption is that a commented attribute has an empty line above and below
            if (true == _wasAttributeCommented)
            {
                _tokenWriter.EmptyLine(linger: true);
                _prependIndentation = false;
            }
            else
            {
                _tokenWriter.LineBreak(linger: true);
                _prependIndentation = true;
            }
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}