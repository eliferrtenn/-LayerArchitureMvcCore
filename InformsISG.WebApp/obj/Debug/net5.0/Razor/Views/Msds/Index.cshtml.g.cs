#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f39b85a05b58da093114012e1d6c10c0270c8db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Msds_Index), @"mvc.1.0.view", @"/Views/Msds/Index.cshtml")]
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
#line 2 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f39b85a05b58da093114012e1d6c10c0270c8db", @"/Views/Msds/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Msds_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InformsISG.Entities.Dtos.MsdsDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DownloadFileFromFileSystem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("menu-link px-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MsdsDosyaEkle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MsdsDosyaIslem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
  
    var tokenSet = antiforgery.GetAndStoreTokens(Context);
    ViewData["Title"] = "Index";
    var MsdsDosya = (List<InformsISG.Entities.Dtos.Msds_DosyaDTO>)ViewBag.MsdsDosya;
    int i = 1;
    var Count = ViewBag.Count;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card shadow-sm\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">MSDS LİSTESİ</h3>\r\n        <div class=\"card-toolbar\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 526, "\"", 561, 1);
#nullable restore
#line 15 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
WriteAttributeValue("", 533, Url.Action("Create","Msds"), 533, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success btn-hover-rotate-end"">YENİ MSDS EKLE</a>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""tblBirim"" class=""table table-striped table-row-bordered gy-5 gs-7"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 23 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Urun_Ad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>Dosya</th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 34 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Urun_Ad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 36 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                         foreach (var item2 in MsdsDosya)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                             if (item2.Msds_Id == item.Id)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f39b85a05b58da093114012e1d6c10c0270c8db8235", async() => {
                WriteLiteral("Dosya");
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
#line 41 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                                                 WriteLiteral(item2.Id);

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
            WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 43 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                i = 1;
                                break;
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                             if (Count == i)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td></td>\r\n");
#nullable restore
#line 49 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                i = 1;
                                break;
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                             
                            i++;
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <td style=""text-align:end"">
                            <button type=""button"" class=""btn btn-primary btn-sm dropdown-toggle""
                                    data-kt-menu-trigger=""click""
                                    data-kt-menu-placement=""bottom-start"">
                                İşlemler
                            </button>
                            <div class=""menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-100px py-4""
                                 data-kt-menu=""true"">
                                <div class=""menu-item px-3"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f39b85a05b58da093114012e1d6c10c0270c8db12342", async() => {
                WriteLiteral("\r\n                                        Düzenle\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"menu-item px-3\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f39b85a05b58da093114012e1d6c10c0270c8db14828", async() => {
                WriteLiteral("\r\n                                        Detaylar\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"menu-item px-3\">\r\n");
#nullable restore
#line 74 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                     if (Count == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f39b85a05b58da093114012e1d6c10c0270c8db17611", async() => {
                WriteLiteral("\r\n                                            Dosya Ekle\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                    }
                                    else
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                         foreach (var item2 in MsdsDosya)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                             if (item2.Msds_Id == item.Id)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f39b85a05b58da093114012e1d6c10c0270c8db21000", async() => {
                WriteLiteral("\r\n                                                    Dosya İşlemleri\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 89 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                i = 1;
                                                break;
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                             if (Count == i)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f39b85a05b58da093114012e1d6c10c0270c8db24073", async() => {
                WriteLiteral("\r\n                                                    Dosya Ekle\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 97 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                i = 1;
                                                break;
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                             
                                            i++;

                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                         
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                </div>\r\n                                <div class=\"menu-item px-3\">\r\n                                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 5207, "\"", 5239, 3);
            WriteAttributeValue("", 5217, "VeriSil(", 5217, 8, true);
#nullable restore
#line 108 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
WriteAttributeValue("", 5225, item.Id, 5225, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5233, ",this)", 5233, 6, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"menu-link px-3\">\r\n                                        Sil\r\n                                    </a>\r\n                                </div>\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 115 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n    <div class=\"card-footer\">\r\n\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#tblBirim"").DataTable({
            ""pageLength"": 50,
            language: {
                ""sDecimal"": "","",
                ""sEmptyTable"": ""Tabloda herhangi bir veri mevcut değil"",
                 ""sInfo"": 'Toplam kayıttan _START_  - _END_ arasındaki kayıtlar gösteriliyor.' + ""Toplam ""+");
#nullable restore
#line 131 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                                                                      Write(ViewBag.Msds);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" + "" kayıt vardır."",
                ""sInfoEmpty"": ""Kayıt yok"",
                ""sInfoFiltered"": ""(MAX kayıt içerisinden bulunan)"",
                ""sInfoThousands"": ""."",
                ""sLengthMenu"": ""Sayfada MENU kayıt göster"",
                ""sLoadingRecords"": ""Yükleniyor..."",
                ""sProcessing"": ""İşleniyor..."",
                ""sSearch"": ""Ara:"",
                ""sZeroRecords"": ""Eşleşen kayıt bulunamadı"",
                ""oPaginate"": {
                    ""sFirst"": ""İlk"",
                    ""sLast"": ""Son"",
                    ""sNext"": ""Sonraki"",
                    ""sPrevious"": ""Önceki""
                },
                ""oAria"": {
                    ""sSortAscending"": "": artan sütun sıralamasını aktifleştir"",
                    ""sSortDescending"": "": azalan sütun sıralamasını aktifleştir""
                },
                ""select"": {
                    ""rows"": {
                        ""_"": ""%d kayıt seçildi"",
                        ""1"": ""1 kayıt seçildi""
          ");
                WriteLiteral(@"          }
                }
            },
            dom:
                ""<'row'"" +
                ""<'col-sm-6 d-flex align-items-center justify-conten-start'>"" +
                ""<'col-sm-6 d-flex align-items-center justify-content-end'f>"" +
                "">"" +

                ""<'table-responsive'tr>"" +

                ""<'row'"" +
                ""<'col-sm-12 col-md-5 d-flex align-items-center justify-content-center justify-content-md-start'i>"" +
                ""<'col-sm-12 col-md-7 d-flex align-items-center justify-content-center justify-content-md-end'p>"" +
                "">""

        });
    </script>

    <script type=""text/javascript"">
       function VeriSil(ID, obj) {
            var btn = $(obj);
            Swal.fire({
                title: 'SİLME İŞLEMİ',
                text: ""Silmek istediğinize emin misiniz?"",
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#50cd89',
                cancelButto");
                WriteLiteral(@"nColor: '#f1416c',
                confirmButtonText: 'Evet Sil!',
                cancelButtonText: 'Hayır Silme!',
                showClass: {
                    popup: 'animate_animated animate_fadeInDown'
                },
                hideClass: {
                    popup: 'animate_animated animate_fadeOutUp'
                }
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        method: 'POST',
                        url: '");
#nullable restore
#line 195 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                         Write(Url.Action("Delete", "Msds"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                        headers: {\'");
#nullable restore
#line 196 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                              Write(tokenSet.HeaderName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' : \'");
#nullable restore
#line 196 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Msds\Index.cshtml"
                                                       Write(tokenSet.RequestToken);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"'},
                        data: { id: ID }
                    }).done(function (d) {
                        const result = $.parseJSON(d);
                        if (result.ResultStatus == 0) {
                            Swal.fire({
                                title: 'SİLİNDİ',
                                icon: 'success',
                                text: `${result.Message}`,
                                showClass: {
                                    popup: 'animate_animated animate_fadeInDown'
                                },
                                hideClass: {
                                    popup: 'animate_animated animate_fadeOutUp'
                                }
                            });
                            btn.parent().parent().parent().parent().fadeOut(1000);
                        }
                    }).fail(function () {
                        Swal.fire({
                            title: 'HATALI İŞLEM',
                ");
                WriteLiteral(@"            text: ""Veri silinemedi"",
                            icon: 'error',
                            showClass: {
                                popup: 'animate_animated animate_fadeInDown'
                            },
                            hideClass: {
                                popup: 'animate_animated animate_fadeOutUp'
                            }
                        })
                    })
                }
            });
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InformsISG.Entities.Dtos.MsdsDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
