#pragma checksum "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab8ba416a45863de4147a4df6b3b6c0c44440cfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__HouseModalPartial), @"mvc.1.0.view", @"/Views/Shared/_HouseModalPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\_ViewImports.cshtml"
using Quarter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\_ViewImports.cshtml"
using Quarter.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\_ViewImports.cshtml"
using Quarter.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\_ViewImports.cshtml"
using Quarter.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\_ViewImports.cshtml"
using Quarter.Models.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab8ba416a45863de4147a4df6b3b6c0c44440cfe", @"/Views/Shared/_HouseModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef04afd7d27ccb72b886b3e6744d037cea69259a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__HouseModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<House>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Wishlist"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-bs-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-bs-target", new global::Microsoft.AspNetCore.Html.HtmlString("#liton_wishlist_modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "addwishlist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

    <div class=""modal-header"">
        <button type=""button"" class=""close"" data-bs-dismiss=""modal"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
            <!-- <i class=""fas fa-times""></i> -->
        </button>
    </div>
    <div class=""modal-body"">
        <div class=""ltn__quick-view-modal-inner"">
            <div class=""modal-product-item"">
                <div class=""row"">
                    <div class=""col-lg-6 col-12"">
                        <div class=""modal-product-img"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ab8ba416a45863de4147a4df6b3b6c0c44440cfe7372", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 582, "~/uploads/house/", 582, 16, true);
#nullable restore
#line 16 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
AddHtmlAttributeValue("", 598, Model.HouseImages.FirstOrDefault(x => x.PosterStatus == true).Image, 598, 68, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-lg-6 col-12"">
                        <div class=""modal-product-info"">
                            <div class=""product-ratting"">
                                <ul>
                                    <li><a href=""#""><i class=""fas fa-star""></i></a></li>
                                    <li><a href=""#""><i class=""fas fa-star""></i></a></li>
                                    <li><a href=""#""><i class=""fas fa-star""></i></a></li>
                                    <li><a href=""#""><i class=""fas fa-star-half-alt""></i></a></li>
                                    <li><a href=""#""><i class=""far fa-star""></i></a></li>
                                    <li class=""review-total""> <a href=""#""> ( 95 Reviews )</a></li>
                                </ul>
                            </div>
                            <h3><a href=""product-details.html"">");
#nullable restore
#line 31 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
                                                          Write(Model.Rooms);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Otaq ");
#nullable restore
#line 31 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
                                                                            Write(Model.City.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" da ");
#nullable restore
#line 31 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
                                                                                                Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a></h3>\r\n                            <div class=\"product-price\">\r\n                                <span>");
#nullable restore
#line 33 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
                                 Write(Model.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" AZN</span>\r\n                            </div>\r\n                            <hr>\r\n                            <div class=\"modal-product-brief\">\r\n                                <p>");
#nullable restore
#line 37 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
                              Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <!-- <hr> -->
                            <div class=""ltn__product-details-menu-3"">
                                <ul>
                                    <li>
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8ba416a45863de4147a4df6b3b6c0c44440cfe12089", async() => {
                WriteLiteral("\r\n                                            <i class=\"far fa-heart\"></i>\r\n                                            <span>Add to Wishlist</span>\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
                                                                                                                                                                            WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </li>\r\n                                    <li>\r\n                                        <a href=\"#\"");
            BeginWriteAttribute("class", " class=\"", 2772, "\"", 2780, 0);
            EndWriteAttribute();
            WriteLiteral(@" title=""Compare"" data-bs-toggle=""modal"" data-bs-target=""#quick_view_modal"">
                                            <i class=""fas fa-exchange-alt""></i>
                                            <span>Compare</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <hr>
                            <div class=""ltn__social-media"">
                                <ul>
                                    <li>Share:</li>
                                    <li><a href=""#"" title=""Facebook""><i class=""fab fa-facebook-f""></i></a></li>
                                    <li><a href=""#"" title=""Twitter""><i class=""fab fa-twitter""></i></a></li>
                                    <li><a href=""#"" title=""Linkedin""><i class=""fab fa-linkedin""></i></a></li>
                                    <li><a href=""#"" title=""Instagram""><i class=""fab fa-instagram""></i></a></li>

  ");
            WriteLiteral("                              </ul>\r\n                            </div>\r\n                            <label class=\"float-end mb-0\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8ba416a45863de4147a4df6b3b6c0c44440cfe16554", async() => {
                WriteLiteral("<small>View Details</small>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Shared\_HouseModalPartial.cshtml"
                                                                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</label>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<House> Html { get; private set; }
    }
}
#pragma warning restore 1591