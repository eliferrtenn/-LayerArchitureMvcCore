#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a79f4a9d32bcf2f1fb09962b692437411dca8847"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kkd_PersonelAtama), @"mvc.1.0.view", @"/Views/Kkd/PersonelAtama.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a79f4a9d32bcf2f1fb09962b692437411dca8847", @"/Views/Kkd/PersonelAtama.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Kkd_PersonelAtama : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InformsISG.Entities.Dtos.KkdDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary align-self-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonelCikar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PersonelEkle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
  
    ViewData["Title"] = "Details";
    var PersonelList = (List<InformsISG.Entities.Dtos.Personel_BilgiDTO>)ViewBag.PersonelList;
    TempData["kkdid"] = TempData["id"];
    TempData["id"] = TempData["id"];
    int siraNo = 1;
    var taliBirim = ViewBag.talibirimId;
    var PersonelListe = ViewBag.Liste;
    var KkdPersonelAtama = (List<InformsISG.Entities.Dtos.Kkd_Personel_AtamaDTO>)ViewBag.KkdPersonelAtama;
    var TaliBirimList = (List<InformsISG.Entities.Dtos.Tali_BirimDTO>)ViewBag.TaliBirimList;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 569, "\"", 577, 0);
            EndWriteAttribute();
            WriteLiteral(@">
    <div class="" flex-column "" id=""kt_wrapper"">
        <div class=""content d-flex flex-column flex-column-fluid"" id=""kt_content"">
            <div class=""post d-flex flex-column-fluid"" id=""kt_post"">
                <div id=""kt_content_container"" class=""container-xxl"">
                    <div class=""card mb-5 mb-xl-10"" id=""kt_profile_details_view"">
                        <div class=""card-header cursor-pointer"">
                            <div class=""card-title m-0"">
                                <h3 class=""fw-bolder m-0"">Kkd Bigileri</h3>
                            </div>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a79f4a9d32bcf2f1fb09962b692437411dca88476240", async() => {
                WriteLiteral("Geri D??n");
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
#line 24 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
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
#line 30 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                          Write(Model.Kkd_No);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Kkd Tan??m</label>
                                <div class=""col-lg-8 fv-row"">
                                    <span class=""fw-bold text-gray-800 fs-6"">");
#nullable restore
#line 36 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                        Write(Model.Kkd_Tanim);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">
                                    ??retici
                                </label>
                                <div class=""col-lg-8 d-flex align-items-center"">
                                    <span class=""fw-bolder fs-6 text-gray-800 me-2"">");
#nullable restore
#line 44 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                               Write(Model.Uretici);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Par??a No</label>
                                <div class=""col-lg-8"">
                                    <a href=""#"" class=""fw-bold fs-6 text-gray-800 text-hover-primary"">");
#nullable restore
#line 50 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                                                 Write(Model.Parca_No);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Par??a No</label>
                                <div class=""col-lg-8"">
                                    <a href=""#"" class=""fw-bold fs-6 text-gray-800 text-hover-primary"">");
#nullable restore
#line 56 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                                                 Write(Model.Parca_No);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                </div>
                            </div>
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Kullan??lma Durumu</label>
                                <div class=""col-lg-8"">
");
#nullable restore
#line 62 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                     if (Model.Kullanilma_Durumu == true)
                                    {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" class=\"fw-bold fs-6 text-gray-800 text-hover-primary\">Evet</a>\r\n");
#nullable restore
#line 67 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" class=\"fw-bold fs-6 text-gray-800 text-hover-primary\">Hay??r</a>\r\n");
#nullable restore
#line 71 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n\r\n                        </div>\r\n\r\n\r\n                        <div class=\"card shadow-sm\">\r\n                            <div class=\"card-body\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a79f4a9d32bcf2f1fb09962b692437411dca884713779", async() => {
                WriteLiteral(@"

                                    <table id=""tblPersonelBilgi"" class=""table table-striped table-row-bordered gy-5 gs-7"">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Ad Soyad
                                                </th>
                                                <th>
                                                    Sicil No
                                                </th>
                                                <th>
                                                    Tc No
                                                </th>
                                                <th>
                                                    Birim
                                                </th>
                                                <th></th>
                                            </tr>
         ");
                WriteLiteral("                               </thead>\r\n");
#nullable restore
#line 101 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                         foreach (var item in KkdPersonelAtama)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                             if (item.Kkd_Id == Convert.ToInt64(TempData["kkdid"]))
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                 foreach (var item2 in PersonelList)
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 107 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                     if (item.Personel_Id == item2.Id)
                                                    {


#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                        <tbody>

                                                            <tr>
                                                                <td>
                                                                    ");
#nullable restore
#line 114 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                               Write(item2.Ad_Soyad);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 117 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                               Write(item2.Sicil_No);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 120 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                               Write(item2.Tc_No);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n");
#nullable restore
#line 122 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                 foreach (var item3 in TaliBirimList)
                                                                {


                                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 126 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                     if (item2.Tali_Birim_Id == item3.Id)
                                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                        <td>\r\n                                                                            ");
#nullable restore
#line 129 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                       Write(item3.Tali_Birim_Ad);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                        </td>\r\n");
#nullable restore
#line 131 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 131 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                                     
                                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


                                                                <td>
                                                                    <span class=""form-check form-check-custom form-check-solid"" style=""text-align:center"" id=""MyDiv"">
                                                                        <input class=""form-check-input"" type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 7977, "\"", 7993, 1);
#nullable restore
#line 138 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
WriteAttributeValue("", 7985, item.Id, 7985, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""Ids"" />
                                                                    </span>

                                                                </td>
                                                            </tr>
                                                        </tbody>
");
#nullable restore
#line 144 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 144 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                     
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 145 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                 
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 146 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </table>\r\n                                    <input type=\"submit\" class=\"btn btn-success btn-hover-rotate-end\" value=\"KAYDET\">&nbsp;\r\n\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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


                        <div class=""card shadow-sm"">
                            <div class=""card-body"">
                                <div>
                                    ");
#nullable restore
#line 159 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                               Write(await Component.InvokeAsync("PersonelGetirKkd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <br /><br />\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a79f4a9d32bcf2f1fb09962b692437411dca884724379", async() => {
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
                WriteLiteral("\n                                            </thead>\r\n\r\n");
#nullable restore
#line 181 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
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
#line 189 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                               Write(siraNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                                <td id=\"attrName\">\r\n                                                                    ");
#nullable restore
#line 191 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                               Write(item.Ad_Soyad);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n                                                                <td class=\"attrValue\">\r\n                                                                    ");
#nullable restore
#line 194 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                               Write(item.Sicil_No);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                </td>\r\n                                                                <td>\r\n                                                                    ");
#nullable restore
#line 197 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
                                                               Write(item.Tc_No);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                </td>
                                                                <td>


                                                                    <span class=""form-check form-check-custom form-check-solid"" style=""text-align:center"" id=""MyDiv"">
                                                                        <input class=""form-check-input"" type=""checkbox""");
                BeginWriteAttribute("value", " value=\"", 11945, "\"", 11961, 1);
#nullable restore
#line 203 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
WriteAttributeValue("", 11953, item.Id, 11953, 8, false);

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
#line 208 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Kkd\PersonelAtama.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                        </div>\r\n                    </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
