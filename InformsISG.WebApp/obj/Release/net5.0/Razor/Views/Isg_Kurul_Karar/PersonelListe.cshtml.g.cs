#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0638f6339b23b60991edf150887b344d17d315ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Isg_Kurul_Karar_PersonelListe), @"mvc.1.0.view", @"/Views/Isg_Kurul_Karar/PersonelListe.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0638f6339b23b60991edf150887b344d17d315ed", @"/Views/Isg_Kurul_Karar/PersonelListe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Isg_Kurul_Karar_PersonelListe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InformsISG.Entities.Dtos.Isg_Kurul_ElemanDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonelCikar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonelEkle2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
  
    ViewData["Title"] = "PersonelAta";
    var egitimTanimId = ViewBag.egitimTanimId;
    var taliBirim = ViewBag.talibirimId;
    var deneme = ViewBag.deneme;
    var PersonelList = (List<InformsISG.Entities.Dtos.Personel_BilgiDTO>)ViewBag.PersonelList;
    TempData["id"] = TempData["id"];
    int siraNo = 1;
    var PersonelListe = ViewBag.Liste;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card shadow-sm\">\r\n    <div class=\"card-body\">\r\n        <div>\r\n            ");
#nullable restore
#line 17 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
       Write(await Component.InvokeAsync("IsgKurulKararGetir", new { Id = egitimTanimId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
        <br /> <br /> <br /> <br />
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card shadow-sm"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-md-12"">
                                <div class=""card-header"">
                                    <h3 class=""card-title"">TOPLANTIYA EKLENEN PERSONEL LİSTESİ</h3>
                                </div>
                                    <table id=""tblPersonelBilgi2"" class=""table table-striped table-row-bordered gy-5 gs-7"">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Ad Soyad
                                                </th>
                                                <th>
                                                    Sicil No
       ");
            WriteLiteral(@"                                         </th>
                                                <th>
                                                    Tc No
                                                </th>
                                                <th>
                                                    Birim
                                                </th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>

");
#nullable restore
#line 49 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                             foreach (var item in Model)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                 if (item.Isg_Kurul_Karar_Id == egitimTanimId)
                                                {

                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                     foreach (var item2 in PersonelList)
                                                    {
                                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                         if (item.Personel_Id == item2.Id)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <tr>\r\n\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 61 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(item2.Ad_Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 64 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(item2.Sicil_No);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 67 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(item2.Tc_No);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 70 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(item2.Tali_Birim_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0638f6339b23b60991edf150887b344d17d315ed10579", async() => {
                WriteLiteral("\r\n                                                                        Çıkar\r\n                                                                    ");
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
#line 73 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
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
            WriteLiteral("\r\n                                                                </td>\r\n                                                            </tr>\r\n");
#nullable restore
#line 78 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"

                                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                         

                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                     
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tbody>
                                    </table>
                                    <input type=""submit"" class=""btn btn-success btn-hover-rotate-end"" value=""KAYDET"" id=""btnkaydet"">&nbsp;
                                <br /> <br /> <br />
                            </div>
                            <div class=""col-md-12"">
                                <div class=""card-header"">
                                    <h3 class=""card-title"">TOPLANTIYA EKLENECEK PERSONEL LİSTESİ</h3>
                                </div>
                                <div>
                                    ");
#nullable restore
#line 94 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                               Write(await Component.InvokeAsync("PersonelGetirKurul"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <br /> <br />\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0638f6339b23b60991edf150887b344d17d315ed15353", async() => {
                WriteLiteral(@"
                                    <div class=""card-body"">
                                        <table id=""tblPersonelBilgi"" class=""table table-striped table-row-bordered gy-5 gs-7"">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>
                                                        Ad Soyad
                                                    </th>
                                                    <th>
                                                        Sicil No
                                                    </th>
                                                    <th>
                                                        Tc No
                                                    </th>
                                                    <th></th>
                                                </tr>");
                WriteLiteral("\n                                            </thead>\r\n\r\n\r\n\r\n");
#nullable restore
#line 118 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                             foreach (var item in PersonelList)
                                            {
                                                foreach (var item2 in PersonelListe)
                                                {
                                                    if (item.Id == item2 && item.Tali_Birim_Id == taliBirim)
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <tbody>\r\n                                                            <tr>\r\n                                                                <td>");
#nullable restore
#line 126 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(siraNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td id=\"attrName\">\r\n                                                                    ");
#nullable restore
#line 128 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(item.Ad_Soyad);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n                                                                <td class=\"attrValue\">\r\n                                                                    ");
#nullable restore
#line 131 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(item.Sicil_No);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 134 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                               Write(item.Tc_No);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                </td>
                                                                <td>


                                                                    <span class=""form-check form-check-custom form-check-solid"" style=""text-align:center"" id=""MyDiv"">
                                                                        <input class=""form-check-input"" type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 8112, "\"", 8128, 1);
#nullable restore
#line 140 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
WriteAttributeValue("", 8120, item.Id, 8120, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""names"" />
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
");
#nullable restore
#line 145 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Isg_Kurul_Karar\PersonelListe.cshtml"
                                                        siraNo++;
                                                    }
                                                }

                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"



                                        </table>

                                    </div>

                                    <input type=""submit"" class=""btn btn-success btn-hover-rotate-end"" value=""KAYDET"">&nbsp;
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n\r\n\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n                                                               {\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InformsISG.Entities.Dtos.Isg_Kurul_ElemanDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
