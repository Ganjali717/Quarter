#pragma checksum "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe50a146c88b1ea02e305f4fbed3dcd8d98bca71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Service_Index), @"mvc.1.0.view", @"/Views/Service/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe50a146c88b1ea02e305f4fbed3dcd8d98bca71", @"/Views/Service/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef04afd7d27ccb72b886b3e6744d037cea69259a", @"/Views/_ViewImports.cshtml")]
    public class Views_Service_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "about", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("theme-btn-1 btn btn-effect-1 text-uppercase"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "service", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

    <!-- BREADCRUMB AREA START -->
    <div class=""ltn__breadcrumb-area text-left bg-overlay-white-30 bg-image "" data-bs-bg=""img/bg/14.jpg"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""ltn__breadcrumb-inner"">
                        <h1 class=""page-title"">Bizim Xidmətlər</h1>
                        <div class=""ltn__breadcrumb-list"">
                            <ul>
                                <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe50a146c88b1ea02e305f4fbed3dcd8d98bca716827", async() => {
                WriteLiteral("<span class=\"ltn__secondary-color\"><i class=\"fas fa-home\"></i></span> Ana Səhifə");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                                <li>Servislər</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- BREADCRUMB AREA END -->

    <!-- ABOUT US AREA START -->
    <div class=""ltn__about-us-area pb-115"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-5 align-self-center"">
                    <div class=""about-us-img-wrap ltn__img-shape-left  about-img-left"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fe50a146c88b1ea02e305f4fbed3dcd8d98bca718849", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1247, "~/assets/img/service/", 1247, 21, true);
#nullable restore
#line 30 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
AddHtmlAttributeValue("", 1268, Model.Settings.FirstOrDefault().ServiceImg, 1268, 43, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
                <div class=""col-lg-7 align-self-center"">
                    <div class=""about-us-info-wrap"">
                        <div class=""section-title-area ltn__section-title-2--- mb-20"">
                            <h6 class=""section-subtitle section-subtitle-2 ltn__secondary-color"">Haqqımızda</h6>
                            <h1 class=""section-title"">
                               ");
#nullable restore
#line 38 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                          Write(Model.Settings.FirstOrDefault().AboutUsTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>.</span>\r\n                            </h1>\r\n                            <p>\r\n                                ");
#nullable restore
#line 41 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                           Write(Model.Settings.FirstOrDefault().AboutUsDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"btn-wrapper animated\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe50a146c88b1ea02e305f4fbed3dcd8d98bca7111786", async() => {
                WriteLiteral("About Us");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
                </div>
            </div>
        </div>
    </div>
    <!-- ABOUT US AREA END -->

    <!-- SERVICE AREA START (Service 1) -->
    <div class=""ltn__service-area section-bg-1 pt-115 pb-70"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""section-title-area ltn__section-title-2--- text-center"">
                        <h6 class=""section-subtitle section-subtitle-2 ltn__secondary-color"">Bizim Servislər</h6>
                        <h1 class=""section-title"">Servislər</h1>
                    </div>
                </div>
            </div>
            <div class=""row  justify-content-center"">
");
#nullable restore
#line 66 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                 foreach (var item in Model.Services)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-lg-4 col-sm-6 col-12"">
                        <div class=""ltn__feature-item ltn__feature-item-6 text-center bg-white  box-shadow-1"">
                            <div class=""ltn__feature-icon"">
                                <span>");
#nullable restore
#line 71 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                                 Write(Html.Raw(item.Logo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <!-- <img src=\"~/assets/img/icons/icon-img/21.png\" alt=\"#\"> -->\r\n                            </div>\r\n                            <div class=\"ltn__feature-info\">\r\n                                <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe50a146c88b1ea02e305f4fbed3dcd8d98bca7115098", async() => {
#nullable restore
#line 75 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                                                                                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                                                                                      WriteLiteral(item.Id);

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
            WriteLiteral("</h3>\r\n                                <p>");
#nullable restore
#line 76 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                              Write(item.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <!-- <a class=\"ltn__service-btn\" href=\"service-details.html\">Find A Home <i class=\"flaticon-right-arrow\"></i></a> -->\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 81 "C:\Users\LENOVO\OneDrive\Desktop\Layihe\Quarter\Quarter\Quarter\Views\Service\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <!-- SERVICE AREA END -->\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
