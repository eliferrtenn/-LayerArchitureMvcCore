#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2d6a6dbe0ba8f61ad929883cc04016ac044f5a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\_ViewImports.cshtml"
using InformsISG.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\_ViewImports.cshtml"
using InformsISG.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2d6a6dbe0ba8f61ad929883cc04016ac044f5a7", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/media/logos/logo.jpeg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("h-25px h-lg-25px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("kt_body"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("header-tablet-and-mobile-fixed aside-enabled footer-fixed  page-footer-fixed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
  
    var Birimm = ViewBag.Birim;
    var birim = this.Context.Request.Cookies["BirimAd"];

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2d6a6dbe0ba8f61ad929883cc04016ac044f5a75957", async() => {
                WriteLiteral(@"

    <title>MERSİN BELEDİYE</title>
    <meta charset=""utf-8"" />

    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
    <meta property=""og:locale"" content=""en_US"" />
    <meta property=""og:type"" content=""article"" />




    ");
#nullable restore
#line 23 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutCssPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2d6a6dbe0ba8f61ad929883cc04016ac044f5a77466", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"d-flex flex-column flex-root\">\r\n\r\n        <div class=\"page d-flex flex-row flex-column-fluid\">\r\n\r\n            ");
#nullable restore
#line 33 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
       Write(await Html.PartialAsync("_LayoutSideBarNav"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            <div class=\"wrapper d-flex flex-column flex-row-fluid\" id=\"kt_wrapper\">\r\n\r\n\r\n                <div id=\"kt_header\"");
                BeginWriteAttribute("style", " style=\"", 976, "\"", 984, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"header align-items-stretch\">\r\n                    <!--begin::Brand-->\r\n                    <div class=\"header-brand\">\r\n                        <!--begin::Logo-->\r\n                        <a>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2d6a6dbe0ba8f61ad929883cc04016ac044f5a78669", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </a>
                        <!--end::Logo-->
                        <!--begin::Aside minimize-->
                        <div id=""kt_aside_toggle"" class=""btn btn-icon w-auto px-0 btn-active-color-primary aside-minimize"" data-kt-toggle=""true"" data-kt-toggle-state=""active"" data-kt-toggle-target=""body"" data-kt-toggle-name=""aside-minimize"">
                            <!--begin::Svg Icon | path: icons/duotune/arrows/arr092.svg-->
                            <span class=""svg-icon svg-icon-1 me-n1 minimize-default"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"">
                                    <rect opacity=""0.3"" x=""8.5"" y=""11"" width=""12"" height=""2"" rx=""1"" fill=""black"" />
                                    <path d=""M10.3687 11.6927L12.1244 10.2297C12.5946 9.83785 12.6268 9.12683 12.194 8.69401C11.8043 8.3043 11.1784 8.28591 10.7664 8.65206L7.84084 11.2526C7.39332 11.6504 7.39332 12.3496 7.84084 ");
                WriteLiteral(@"12.7474L10.7664 15.3479C11.1784 15.7141 11.8043 15.6957 12.194 15.306C12.6268 14.8732 12.5946 14.1621 12.1244 13.7703L10.3687 12.3073C10.1768 12.1474 10.1768 11.8526 10.3687 11.6927Z"" fill=""black"" />
                                    <path opacity=""0.5"" d=""M16 5V6C16 6.55228 15.5523 7 15 7C14.4477 7 14 6.55228 14 6C14 5.44772 13.5523 5 13 5H6C5.44771 5 5 5.44772 5 6V18C5 18.5523 5.44771 19 6 19H13C13.5523 19 14 18.5523 14 18C14 17.4477 14.4477 17 15 17C15.5523 17 16 17.4477 16 18V19C16 20.1046 15.1046 21 14 21H5C3.89543 21 3 20.1046 3 19V5C3 3.89543 3.89543 3 5 3H14C15.1046 3 16 3.89543 16 5Z"" fill=""black"" />
                                </svg>
                            </span>
                            <!--end::Svg Icon-->
                            <!--begin::Svg Icon | path: icons/duotune/arrows/arr076.svg-->
                            <span class=""svg-icon svg-icon-1 minimize-active"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""");
                WriteLiteral(@"0 0 24 24"" fill=""none"">
                                    <rect opacity=""0.3"" width=""12"" height=""2"" rx=""1"" transform=""matrix(-1 0 0 1 15.5 11)"" fill=""black"" />
                                    <path d=""M13.6313 11.6927L11.8756 10.2297C11.4054 9.83785 11.3732 9.12683 11.806 8.69401C12.1957 8.3043 12.8216 8.28591 13.2336 8.65206L16.1592 11.2526C16.6067 11.6504 16.6067 12.3496 16.1592 12.7474L13.2336 15.3479C12.8216 15.7141 12.1957 15.6957 11.806 15.306C11.3732 14.8732 11.4054 14.1621 11.8756 13.7703L13.6313 12.3073C13.8232 12.1474 13.8232 11.8526 13.6313 11.6927Z"" fill=""black"" />
                                    <path d=""M8 5V6C8 6.55228 8.44772 7 9 7C9.55228 7 10 6.55228 10 6C10 5.44772 10.4477 5 11 5H18C18.5523 5 19 5.44772 19 6V18C19 18.5523 18.5523 19 18 19H11C10.4477 19 10 18.5523 10 18C10 17.4477 9.55228 17 9 17C8.44772 17 8 17.4477 8 18V19C8 20.1046 8.89543 21 10 21H19C20.1046 21 21 20.1046 21 19V5C21 3.89543 20.1046 3 19 3H10C8.89543 3 8 3.89543 8 5Z"" fill=""#C4C4C4"" />
                      ");
                WriteLiteral(@"          </svg>
                            </span>
                            <!--end::Svg Icon-->
                        </div>
                        <!--end::Aside minimize-->
                        <!--begin::Aside toggle-->
                        <div class=""d-flex align-items-center d-lg-none ms-n3 me-1"" title=""Show aside menu"">
                            <div class=""btn btn-icon btn-active-color-primary w-30px h-30px"" id=""kt_aside_mobile_toggle"">
                                <!--begin::Svg Icon | path: icons/duotune/abstract/abs015.svg-->
                                <span class=""svg-icon svg-icon-1"">
                                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"">
                                        <path d=""M21 7H3C2.4 7 2 6.6 2 6V4C2 3.4 2.4 3 3 3H21C21.6 3 22 3.4 22 4V6C22 6.6 21.6 7 21 7Z"" fill=""black"" />
                                        <path opacity=""0.3"" d=""M21 14H3C2.4 14 2 13.6 2 13V11C2 10");
                WriteLiteral(@".4 2.4 10 3 10H21C21.6 10 22 10.4 22 11V13C22 13.6 21.6 14 21 14ZM22 20V18C22 17.4 21.6 17 21 17H3C2.4 17 2 17.4 2 18V20C2 20.6 2.4 21 3 21H21C21.6 21 22 20.6 22 20Z"" fill=""black"" />
                                    </svg>
                                </span>
                                <!--end::Svg Icon-->
                            </div>
                        </div>
                        <!--end::Aside toggle-->
                    </div>
                    <!--end::Brand-->
                    <!--begin::Toolbar-->
                    <div class=""toolbar d-flex align-items-stretch"">
                        <!--begin::Toolbar container-->
                        <div class=""container-fluid py-6 py-lg-0 d-flex flex-column flex-lg-row align-items-lg-stretch justify-content-lg-between"">
                            <!--begin::Page title-->
                            <div class=""page-title d-flex justify-content-center flex-column me-5"">
                                <!--begin:");
                WriteLiteral(":Title-->\r\n                                <h1 class=\"d-flex flex-column text-dark fw-bolder fs-3 mb-0\">\r\n                                    <a");
                BeginWriteAttribute("href", " href=\"", 6557, "\"", 6591, 1);
#nullable restore
#line 92 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6564, Url.Action("Index","Home"), 6564, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">ISG</a>
                                </h1>

                                <div class=""d-flex align-items-stretch overflow-auto pt-3 pt-lg-0"">
                                    <!--begin::Action wrapper-->
                                    <div class=""d-flex align-items-center"">
                                        <!--begin::Label-->
                                        <span class=""fs-7 fw-bolder text-gray-700 pe-4 text-nowrap d-none d-xxl-block""></span>
                                        <!--end::Label-->
                                        <!--begin::Select-->
                        
                                    

                                        <!--end::Select-->
                                    </div>
                                    <!--end::Action wrapper-->
                                    <!--end::Action wrapper-->
                                    <!--begin::Theme mode-->
                                    <div class=""d-flex alig");
                WriteLiteral(@"n-items-center"">
                                        <!--begin::Theme mode docs-->
                                        <!--end::Theme mode docs-->
                                    </div>
                                    <!--end::Theme mode-->
                                </div>


                                <ul class=""breadcrumb breadcrumb-separatorless fw-bold fs-7 pt-1"">
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item text-muted"">
                                        <a class=""text-muted text-hover-primary""></a>
                                    </li>
                                    <!--end::Item-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item"">
                                        <span class=""bullet bg-gray-200 w-5px h-2px""></span>
                                    </li>
                                    <!--en");
                WriteLiteral(@"d::Item-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item text-muted""></li>
                                    <!--end::Item-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item"">
                                        <span class=""bullet bg-gray-200 w-5px h-2px""></span>
                                    </li>
                                    <!--end::Item-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item text-dark""></li>
                                    <!--end::Item-->
                                </ul>

                            </div>    
                            <!--begin::Page title-->
                            <div class=""page-title d-flex justify-content-center flex-column me-5"">
                                <!--begin::Title-->
                           ");
                WriteLiteral("     <h5 class=\"d-flex flex-column fs-3 mb-0\" style=\"color: #1e1e2d\">\r\n                                    <a>");
#nullable restore
#line 147 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
                                  Write(birim);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</a>
                                </h5>

                                <div class=""d-flex align-items-stretch overflow-auto pt-3 pt-lg-0"">
                                    <!--begin::Action wrapper-->
                                    <div class=""d-flex align-items-center"">
                                        <!--begin::Label-->
                                        <span class=""fs-7 fw-bolder text-gray-700 pe-4 text-nowrap d-none d-xxl-block""></span>
                                        <!--end::Label-->
                                        <!--begin::Select-->
                        
                                    

                                        <!--end::Select-->
                                    </div>
                                    <!--end::Action wrapper-->
                                    <!--end::Action wrapper-->
                                    <!--begin::Theme mode-->
                                    <div class=""d-flex align-it");
                WriteLiteral(@"ems-center"">
                                        <!--begin::Theme mode docs-->
                                        <!--end::Theme mode docs-->
                                    </div>
                                    <!--end::Theme mode-->
                                </div>


                                <ul class=""breadcrumb breadcrumb-separatorless fw-bold fs-7 pt-1"">
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item text-muted"">
                                        <a class=""text-muted text-hover-primary""></a>
                                    </li>
                                    <!--end::Item-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item"">
                                        <span class=""bullet bg-gray-200 w-5px h-2px""></span>
                                    </li>
                                    <!--end::I");
                WriteLiteral(@"tem-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item text-muted""></li>
                                    <!--end::Item-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item"">
                                        <span class=""bullet bg-gray-200 w-5px h-2px""></span>
                                    </li>
                                    <!--end::Item-->
                                    <!--begin::Item-->
                                    <li class=""breadcrumb-item text-dark""></li>
                                    <!--end::Item-->
                                </ul>

                            </div>
                    
                            
                            
                            
                            <div class=""d-flex align-items-stretch overflow-auto pt-3 pt-lg-0"">
                                <!");
                WriteLiteral(@"--begin::Action wrapper-->
                                <div class=""d-flex align-items-center"">
                                    <!--begin::Label-->
                                    <span class=""fs-7 fw-bolder text-gray-700 pe-4 text-nowrap d-none d-xxl-block""></span>
                                    <!--end::Label-->
                                    <!--begin::Select-->
                                    <a");
                BeginWriteAttribute("href", " href=\"", 13285, "\"", 13322, 1);
#nullable restore
#line 209 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 13292, Url.Action("CikisYap","Home"), 13292, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Çıkış Yap</a>
                                    <!--end::Select-->
                                </div>
                                <!--end::Action wrapper-->
                                <!--end::Action wrapper-->
                                <!--begin::Theme mode-->
                                <div class=""d-flex align-items-center"">
                                    <!--begin::Theme mode docs-->
                                    <!--end::Theme mode docs-->
                                </div>
                                <!--end::Theme mode-->
                            </div>
                            <!--end::Action group-->
                        </div>
                        <!--end::Toolbar container-->
                    </div>
                    <!--end::Toolbar-->
                </div>
                <div>
                    ");
#nullable restore
#line 228 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
               Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div>\r\n\r\n            <div class=\"wrapper d-flex flex-column flex-row-fluid\" id=\"kt_wrapper\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    ");
#nullable restore
#line 240 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutJsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 241 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
Write(await Html.PartialAsync("_FooterMessageScripts"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 242 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("scripts", false));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAntiforgery antiforgery { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
