#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8260a4a802eacceeda7e08da6dd94f70e1db3c3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kkd_Details), @"mvc.1.0.view", @"/Views/Kkd/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8260a4a802eacceeda7e08da6dd94f70e1db3c3a", @"/Views/Kkd/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Kkd_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InformsISG.Entities.Dtos.KkdDTO>
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
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
  
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
            WriteLiteral("d-title m-0\">\r\n                                <h3 class=\"fw-bolder m-0\">Kkd Bilgileri</h3>\r\n                            </div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8260a4a802eacceeda7e08da6dd94f70e1db3c3a5430", async() => {
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
#line 25 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
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
                                <label class=""col-lg-4 fw-bold text-muted"">Kkd No</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 31 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                                                          Write(Model.Kkd_No);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Kkd Tanım</label>
                                <div class=""col-lg-8 fv-row"">
                                    <span class=""fw-bold text-gray-800 fs-6"">");
#nullable restore
#line 37 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                                                        Write(Model.Kkd_Tanim);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">
                                    Üretici
                                </label>
                                <div class=""col-lg-8 d-flex align-items-center"">
                                    <span class=""fw-bolder fs-6 text-gray-800 me-2"">");
#nullable restore
#line 45 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                                                               Write(Model.Uretici);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Parça No</label>
                                <div class=""col-lg-8"">
                                    <a href=""#"" class=""fw-bold fs-6 text-gray-800 text-hover-primary"">");
#nullable restore
#line 51 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                                                                                 Write(Model.Parca_No);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </div>
                            </div>        
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Parça No</label>
                                <div class=""col-lg-8"">
                                    <a href=""#"" class=""fw-bold fs-6 text-gray-800 text-hover-primary"">");
#nullable restore
#line 57 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                                                                                 Write(Model.Parca_No);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </div>
                            </div>                
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Standardı</label>
                                <div class=""col-lg-8"">
                                    <a href=""#"" class=""fw-bold fs-6 text-gray-800 text-hover-primary"">");
#nullable restore
#line 63 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                                                                                 Write(Model.Standart);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </div>
                            </div>         
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Notlar</label>
                                <div class=""col-lg-8"">
                                    <a href=""#"" class=""fw-bold fs-6 text-gray-800 text-hover-primary"">");
#nullable restore
#line 69 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                                                                                 Write(Model.Notlar);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </div>
                            </div>    
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Kullanılma Durumu</label>
                                <div class=""col-lg-8"">
");
#nullable restore
#line 75 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                     if (Model.Kullanilma_Durumu == true)
                                    {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" class=\"fw-bold fs-6 text-gray-800 text-hover-primary\">Evet</a>\r\n");
#nullable restore
#line 80 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" class=\"fw-bold fs-6 text-gray-800 text-hover-primary\">Hayır</a>\r\n");
#nullable restore
#line 84 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\Details.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InformsISG.Entities.Dtos.KkdDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
