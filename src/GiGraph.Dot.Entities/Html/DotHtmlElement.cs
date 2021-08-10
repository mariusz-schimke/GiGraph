using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Builder;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     An HTML element with optional attributes and child elements.
    /// </summary>
    public class DotHtmlElement : DotHtmlTag, IDotHtmlContentEntity
    {
        /// <summary>
        ///     Initializes an HTML element with the given name.
        /// </summary>
        /// <param name="name">
        ///     The tag name to use for the element.
        /// </param>
        public DotHtmlElement(string name)
            : this(name, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlElement(string name, DotAttributeCollection attributes)
            : this(name, attributes, new DotHtmlEntityCollection())
        {
        }

        protected DotHtmlElement(string name, DotAttributeCollection attributes, DotHtmlEntityCollection content)
            : base(name, attributes)
        {
            Content = content;
        }

        protected sealed override bool IsVoid => false;

        /// <summary>
        ///     Gets the content items of the element.
        /// </summary>
        public virtual DotHtmlEntityCollection Content { get; }

        /// <inheritdoc cref="IDotHtmlContentEntity.SetContent(GiGraph.Dot.Entities.Html.IDotHtmlEntity)" />
        public virtual void SetContent(IDotHtmlEntity entity)
        {
            ((IDotHtmlContentEntity) Content).SetContent(entity);
        }

        /// <inheritdoc cref="IDotHtmlContentEntity.SetContent(string)" />
        public virtual void SetContent(string text)
        {
            ((IDotHtmlContentEntity) Content).SetContent(text);
        }

        /// <inheritdoc cref="IDotHtmlContentEntity.SetContent(System.Action{GiGraph.Dot.Entities.Html.Builder.DotHtmlBuilder})" />
        public virtual void SetContent(Action<DotHtmlBuilder> build)
        {
            ((IDotHtmlContentEntity) Content).SetContent(build);
        }

        protected override IEnumerable<IDotHtmlEntity> GetContent()
        {
            return Content;
        }
    }
}