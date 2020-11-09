using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    // TODO: uzupełnić opisy właściwości na podstawie DotStyles

    public abstract class DotEntityCommonStyleAttributes : DotEntityStyleAttributes
    {
        protected DotEntityCommonStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a value indicating if the element is invisible.
        /// </summary>
        public virtual bool Invisible
        {
            get => HasOptions(DotStyles.Invisible);
            set => ApplyOption(DotStyles.Invisible, value);
        }
    }
}