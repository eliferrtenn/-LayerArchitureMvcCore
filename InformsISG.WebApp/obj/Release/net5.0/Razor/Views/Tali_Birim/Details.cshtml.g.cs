#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe84bf96e7a84dde8129fa00b04743575205674f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tali_Birim_Details), @"mvc.1.0.view", @"/Views/Tali_Birim/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe84bf96e7a84dde8129fa00b04743575205674f", @"/Views/Tali_Birim/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Tali_Birim_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InformsISG.Entities.Dtos.Tali_BirimDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success align-self-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
  
    ViewData["Title"] = "Details";
    var BirimList = (List<InformsISG.Entities.Dtos.BirimDTO>)ViewBag.BirimList;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 177, "\"", 185, 0);
            EndWriteAttribute();
            WriteLiteral(@">
    <div class="" flex-column "" id=""kt_wrapper"">
        <div class=""content d-flex flex-column flex-column-fluid"" id=""kt_content"">
            <div class=""post d-flex flex-column-fluid"" id=""kt_post"">
                <div id=""kt_content_container"" class=""container-xxl"">
                    <div class=""card mb-5 mb-xl-10"">
                        <div class=""card-body pt-9 pb-0"">
                            <div class=""d-flex flex-wrap flex-sm-nowrap mb-3"">
                            </div>
                            <ul class=""nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder"">
                                <li class=""nav-item mt-2"">
                                    <a class=""nav-link text-active-primary ms-0 me-10 py-5 active"" href=""#"">Genel Bilgi</a>
                                </li>


                            </ul>
                        </div>
                    </div>
                    <div class=""card mb-5 mb-xl-10"" id=""kt_profile_detai");
            WriteLiteral(@"ls_view"">
                        <div class=""cursor-pointer"">
                            <div class=""card-header"">
                                <h3 class=""card-title"">TAL?? B??R??M DETAYLARI</h3>
                                <div class=""card-toolbar"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe84bf96e7a84dde8129fa00b04743575205674f5701", async() => {
                WriteLiteral("D??ZENLE");
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
#line 30 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
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
            WriteLiteral("&nbsp;\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1653, "\"", 1693, 1);
#nullable restore
#line 31 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
WriteAttributeValue("", 1660, Url.Action("Index","Tali_Birim"), 1660, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-danger btn-hover-rotate-start"">GER?? D??N</a>
                                </div>
                            </div>
                        </div>
                        <div class=""card-body p-9"">
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Tali Birim Ad??</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 39 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
                                                                          Write(Model.Tali_Birim_Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Birimi</label>
                                <div class=""col-lg-8"">
");
#nullable restore
#line 45 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
                                     foreach (var item in BirimList)
                                    {
                                        if (Model.Birim_Id == item.Id)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"fw-bolder fs-6 text-gray-800\">");
#nullable restore
#line 49 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
                                                                                  Write(item.Birim_Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 50 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">A????klama</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 57 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Tali_Birim\Details.cshtml"
                                                                          Write(Model.Aciklama);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InformsISG.Entities.Dtos.Tali_BirimDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
