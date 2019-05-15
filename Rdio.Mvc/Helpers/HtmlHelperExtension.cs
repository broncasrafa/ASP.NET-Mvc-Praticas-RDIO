using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Rdio.Mvc.Helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString DivStatusGeralFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string genero, object htmlAttributes = null)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            string propertyName = metaData.PropertyName;

            var div = new MultiLevelHtmlTag("div");
            div.Attributes.Add("name", propertyName);
            div.Attributes.Add("class", "easypie margin-b-50");
            div.Attributes.Add("data-percent", metaData.Model.ToString());

            var span = new MultiLevelHtmlTag("span");
            span.InnerHtml = metaData.Model.ToString() + "%";
            div.InnerTags.Add(span);
            div.InnerHtml = genero;

            var canvas = new MultiLevelHtmlTag("canvas");
            canvas.Attributes.Add("height", "110");
            canvas.Attributes.Add("width", "110");

            div.InnerTags.Add(canvas);

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                div.MergeAttributes(attributes);
            }

            return new MvcHtmlString(div.ToString());
        }

        public static string ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string url = "";//UrlHelper.Action(actionName);

            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            tagBuilder.MergeAttribute("href", url);

            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        public static MvcHtmlString BotaoComImagemFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string tipoCorBotaoClass, string tamanhoBotaoClass, string fontAwesomeIcon, string textoBotao, object htmlAttributes = null)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string propertyName = metaData.PropertyName;

            string colorButton = String.IsNullOrWhiteSpace(tipoCorBotaoClass) ? "" : tipoCorBotaoClass;
            string buttonSize = String.IsNullOrWhiteSpace(tamanhoBotaoClass) ? "" : tamanhoBotaoClass;
            string fa_icon = String.IsNullOrWhiteSpace(fontAwesomeIcon) ? "" : fontAwesomeIcon;
            string text = String.IsNullOrWhiteSpace(textoBotao) ? "" : textoBotao;

            var anchorTag = new MultiLevelHtmlTag("a");
            anchorTag.Attributes.Add("name", propertyName);
            anchorTag.Attributes.Add("class", "btn " + colorButton + " " + buttonSize);

            var image = new MultiLevelHtmlTag("i");
            image.Attributes.Add("class", "fa " + fa_icon);
            anchorTag.InnerTags.Add(image);

            anchorTag.InnerHtml = text;

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                anchorTag.MergeAttributes(attributes);
            }

            return new MvcHtmlString(anchorTag.ToString());
        }

        public static MvcHtmlString ActionImage(this HtmlHelper helper, String action, String controller, Object parameters, string tipoCorBotaoClass, string tamanhoBotaoClass, string fontAwesomeIcon, string textoBotao, object htmlAttributes = null)
        {
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            String href = urlHelper.Action(action, controller, parameters);

            string colorButton = String.IsNullOrWhiteSpace(tipoCorBotaoClass) ? "" : tipoCorBotaoClass;
            string buttonSize = String.IsNullOrWhiteSpace(tamanhoBotaoClass) ? "" : tamanhoBotaoClass;
            string fa_icon = String.IsNullOrWhiteSpace(fontAwesomeIcon) ? "" : fontAwesomeIcon;
            string text = String.IsNullOrWhiteSpace(textoBotao) ? "" : textoBotao;

            var anchorTag = new MultiLevelHtmlTag("a");
            anchorTag.Attributes.Add("href", href);
            anchorTag.Attributes.Add("class", "btn " + colorButton + " " + buttonSize);

            var image = new MultiLevelHtmlTag("i");
            image.Attributes.Add("class", "pull-left fa " + fa_icon);
            anchorTag.InnerTags.Add(image);

            anchorTag.InnerHtml = text;

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                anchorTag.MergeAttributes(attributes);
            }

            return new MvcHtmlString(anchorTag.ToString());
        }


        //public static MvcHtmlString ActionImage(this HtmlHelper helper, String controller, String action, Object parameters, String src, String alt = "", String title = "")
        //{
        //    TagBuilder tagBuilder = new TagBuilder("img");
        //    UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
        //    String url = urlHelper.Action(action, controller, parameters);
        //    String imgUrl = urlHelper.Content(src);
        //    String image = "";
        //    StringBuilder html = new StringBuilder();

        //    // build the image tag.
        //    tagBuilder.MergeAttribute("src", imgUrl);
        //    tagBuilder.MergeAttribute("alt", alt);
        //    tagBuilder.MergeAttribute("title", title);
        //    image = tagBuilder.ToString(TagRenderMode.SelfClosing);

        //    html.Append("<a href=\"");
        //    html.Append(url);
        //    html.Append("\">");
        //    html.Append(image);
        //    html.Append("</a>");

        //    return MvcHtmlString.Create(html.ToString());
        //}

        public static MvcHtmlString Rating<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, bool disabled, object htmlAttributes = null)
        {            
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string propertyName = metaData.PropertyName;

            var rating = new MultiLevelHtmlTag("input");
            rating.Attributes.Add("type", "number");
            rating.Attributes.Add("class", "rating rating-xs");
            rating.Attributes.Add("min", "1");
            rating.Attributes.Add("max", "5");
            rating.Attributes.Add("step", "1");
            rating.Attributes.Add("value", metaData.Model.ToString());

            if(disabled)
            {
                rating.Attributes.Add("disabled", "disabled");
            }
            
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                rating.MergeAttributes(attributes);
            }

            return new MvcHtmlString(rating.ToString());
        }



    }


    public class MultiLevelHtmlTag : TagBuilder
    {
        public MultiLevelHtmlTag(string tagName) : base(tagName) { }

        public List<MultiLevelHtmlTag> InnerTags = new List<MultiLevelHtmlTag>();

        public override string ToString()
        {
            if (InnerTags.Count > 0)
            {
                foreach (MultiLevelHtmlTag tag in InnerTags)
                {
                    this.InnerHtml += tag.ToString();
                }
            }
            return base.ToString();
        }
    }
}

/*
 * <a href="http://egemem.com/theme/kode/v1.1/buttons.html#" class="btn btn-light">
 *      <i class="fa fa-file-o"></i>Light
 * </a>
*/