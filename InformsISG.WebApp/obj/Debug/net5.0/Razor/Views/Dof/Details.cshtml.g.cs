#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "404406fe475415fefc23eaf028ed234b54c4b4d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dof_Details), @"mvc.1.0.view", @"/Views/Dof/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"404406fe475415fefc23eaf028ed234b54c4b4d5", @"/Views/Dof/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Dof_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InformsISG.Entities.Dtos.DofDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary align-self-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 89, "\"", 97, 0);
            EndWriteAttribute();
            WriteLiteral(@">
    <div class="" flex-column "" id=""kt_wrapper"">
        <div class=""content d-flex flex-column flex-column-fluid"" id=""kt_content"">
            <div class=""post d-flex flex-column-fluid"" id=""kt_post"">
                <div id=""kt_content_container"" class=""container-xxl"">
                    <div class=""card mb-5 mb-xl-10"">
                        <div class=""card-body pt-9 pb-0"">
                            <ul class=""nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder"">
                                <li class=""nav-item mt-2"">
                                    <a class=""nav-link text-active-primary ms-0 me-10 py-5 active"" href=""#"">Genel Bilgi</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class=""card mb-5 mb-xl-10"" id=""kt_profile_details_view"">
                        <div class=""card-header cursor-pointer"">
                            <div class=""car");
            WriteLiteral("d-title m-0\">\r\n                                <h3 class=\"fw-bolder m-0\">Döf Bigileri</h3>\r\n                            </div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "404406fe475415fefc23eaf028ed234b54c4b4d55429", async() => {
                WriteLiteral("Geri Dön");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                    WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div class=""card-body p-9"">
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Döf No</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 31 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Dof_No);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Düzenli Önleyici Faaliyetler</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 37 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Dof_Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Döf Tipi</label>
                                <div class=""col-lg-8"">
");
#nullable restore
#line 43 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                     if (Model.Tip == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fw-bolder fs-6 text-gray-800\">Düzeltici</span>\r\n");
#nullable restore
#line 46 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Tip ==1)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fw-bolder fs-6 text-gray-800\">Önleyici</span>\r\n");
#nullable restore
#line 50 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>     
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Geldiği Kaynak</label>
                                <div class=""col-lg-8"">
");
#nullable restore
#line 56 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                     if (Model.Geldigi_Kaynak == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"fw-bolder fs-6 text-gray-800\">Risk Değerlendirme</span>\r\n");
#nullable restore
#line 59 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Geldigi_Kaynak == 1)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"fw-bolder fs-6 text-gray-800\">İş Kazası</span>\r\n");
#nullable restore
#line 63 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Geldigi_Kaynak == 2)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"fw-bolder fs-6 text-gray-800\">İç Denetim</span>\r\n");
#nullable restore
#line 67 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Geldigi_Kaynak == 3)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"fw-bolder fs-6 text-gray-800\">Tehlike Bildirimi</span>\r\n");
#nullable restore
#line 71 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Geldigi_Kaynak == 4)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"fw-bolder fs-6 text-gray-800\">Ramak Kala</span>\r\n");
#nullable restore
#line 75 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Geldigi_Kaynak == 5)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fw-bolder fs-6 text-gray-800\">Dış Denetim</span>\r\n");
#nullable restore
#line 79 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Geldigi_Kaynak == 6)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fw-bolder fs-6 text-gray-800\">ISG Kurulu</span>\r\n");
#nullable restore
#line 83 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Geldigi_Kaynak == 7)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fw-bolder fs-6 text-gray-800\">Periyodik Kontrol</span>\r\n");
#nullable restore
#line 87 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Döf Durumu</label>
                                <div class=""col-lg-8"">
");
#nullable restore
#line 93 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                     if (Model.Dof_Acik == false)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fw-bolder fs-6 text-gray-800\">Kapalı</span>\r\n");
#nullable restore
#line 96 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }
                                    else if (Model.Dof_Acik == true)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"fw-bolder fs-6 text-gray-800\">Açık</span>\r\n");
#nullable restore
#line 100 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Uygunsuzluk Tanımı</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 106 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Uygunsuzluk_Tanim);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Tespit Eden</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 112 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Tespit_Eden);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Sorumlular</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 118 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Sorumlular);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Açılış Tarihi</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 124 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Acilis_Tarih);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Cevap Süresi</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 130 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Cevap_Sure);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Cevap Sonlanma Tarihi</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 136 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Cevap_Sonlanma_Tarih);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Sonlanma Tarihi</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 142 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Dof\Details.cshtml"
                                                                          Write(Model.Sonlanma_Tarih);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InformsISG.Entities.Dtos.DofDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
