﻿using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Html.Font.Attributes
{
    public class DotHtmlFontAttributes : DotHtmlElementAttributes<IDotHtmlFontAttributes, DotHtmlFontAttributes>, IDotHtmlFontAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> HtmlFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlFontAttributes, IDotHtmlFontAttributes>().BuildLazy();

        public DotHtmlFontAttributes(DotHtmlAttributeCollection attributes)
            : this(attributes, HtmlFontAttributesKeyLookup)
        {
        }

        protected DotHtmlFontAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        [DotAttributeKey("face")]
        public virtual string Name
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("point-size")]
        public virtual double? Size
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey("color")]
        public virtual DotColor Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}