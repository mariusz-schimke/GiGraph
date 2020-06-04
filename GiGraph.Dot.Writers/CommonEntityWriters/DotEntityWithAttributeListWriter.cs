﻿using GiGraph.Dot.Writers.AttributeWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.CommonEntityWriters
{
    public abstract class DotEntityWithAttributeListWriter : DotEntityWriter, IDotEntityWithAttributeListWriter
    {
        public DotEntityWithAttributeListWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual IDotAttributeListItemWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.AttributeListStart(linger: true)
                        .Space(linger: true);

            return new DotAttributeListItemWriter(_tokenWriter, _context.NextLevel(), useAttributeSeparator);
        }

        public virtual void EndAttributeList()
        {
            _tokenWriter.ClearLingerBuffer()
                        .Space()
                        .AttributeListEnd();
        }
    }
}