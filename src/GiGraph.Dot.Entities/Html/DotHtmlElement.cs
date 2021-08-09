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
    public class DotHtmlElement : DotHtmlTag
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

        protected DotHtmlElement(string name, DotAttributeCollection attributes, DotHtmlEntityCollection children)
            : base(name, attributes)
        {
            Children = children;
        }

        /// <summary>
        ///     Gets the children of the element.
        /// </summary>
        public virtual DotHtmlEntityCollection Children { get; }

        protected sealed override bool IsVoid => false;

        protected override IEnumerable<IDotHtmlEntity> GetChildren()
        {
            return Children;
        }

        /// <summary>
        ///     Uses the specified HTML entity as the content of the current element.
        /// </summary>
        /// <param name="entity">
        ///     The element to set as the content.
        /// </param>
        public virtual void SetContent(IDotHtmlEntity entity)
        {
            Children.Clear();
            Children.Add(entity);
        }

        /// <summary>
        ///     Uses the builder to build a HTML entity to use as the content of the current element.
        /// </summary>
        /// <param name="build">
        ///     The HTML builder delegate.
        /// </param>
        public virtual void SetContent(Action<DotHtmlBuilder> build)
        {
            var builder = new DotHtmlBuilder();
            build(builder);

            Children.Clear();

            if (builder.Count > 0)
            {
                Children.Add(builder.Build());
            }
        }
    }
}