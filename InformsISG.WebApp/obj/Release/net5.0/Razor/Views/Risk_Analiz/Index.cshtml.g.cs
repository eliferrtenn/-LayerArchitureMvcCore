#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3398a9f51ff6e675ad63c55ee62a940eb8f56102"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Risk_Analiz_Index), @"mvc.1.0.view", @"/Views/Risk_Analiz/Index.cshtml")]
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
#line 2 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3398a9f51ff6e675ad63c55ee62a940eb8f56102", @"/Views/Risk_Analiz/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Risk_Analiz_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InformsISG.Entities.Dtos.Risk_AnalizDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("menu-link px-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditKutuphaneKonu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
  
    var tokenSet = antiforgery.GetAndStoreTokens(Context);
    ViewData["Title"] = "Index";
    var birimList = (List<InformsISG.Entities.Dtos.BirimDTO>)ViewBag.BirimList;
    var taliBirimList = (List<InformsISG.Entities.Dtos.Tali_BirimDTO>)ViewBag.TaliBirimList;
    int siraNo = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card shadow-sm\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">TÜM RİSK ANALİZLER</h3>\r\n        <div class=\"card-toolbar\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 604, "\"", 646, 1);
#nullable restore
#line 17 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
WriteAttributeValue("", 611, Url.Action("Create","Risk_Analiz"), 611, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success btn-hover-rotate-end"">
                YENİ RİSK
                TANIMLA
            </a>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""tblBirim"" class=""table table-striped table-row-bordered gy-5 gs-7"">
            <thead>
                <tr>
                    <th>
                        Sıra No
                    </th>
                    <th>
                        ");
#nullable restore
#line 31 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Analiz_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 34 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Analiz_Tanim));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 37 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Analiz_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Bitis_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 43 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Birim_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 46 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Tali_Birim_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 53 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                       Write(siraNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 60 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Analiz_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 63 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Analiz_Tanim));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 66 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Analiz_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 69 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Bitis_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n\r\n");
#nullable restore
#line 73 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                             if (birimList != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                 foreach (var item2 in birimList)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                     if (item2.Id == item.Birim_Id)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item2.Birim_Ad));

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                                                                     

                                    }
                                    else
                                    {

                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                 

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n\r\n");
#nullable restore
#line 92 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                             if (taliBirimList != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                 foreach (var item2 in taliBirimList)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                     if (item2.Id == item.Tali_Birim_Id)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item2.Tali_Birim_Ad));

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                                                                          

                                    }
                                    else
                                    {

                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </td>

                        <td>
                            <button type=""button"" class=""btn btn-primary btn-sm dropdown-toggle""
                                    data-kt-menu-trigger=""click""
                                    data-kt-menu-placement=""bottom-start"">
                                İşlemler
                            </button>
                            <div class=""menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-100px py-4""
                                 data-kt-menu=""true"">
                                <div class=""menu-item px-3"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3398a9f51ff6e675ad63c55ee62a940eb8f5610215634", async() => {
                WriteLiteral("\r\n                                        Düzenle\r\n                                    ");
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
#line 118 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                                           WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                                </div>   \r\n                                <div class=\"menu-item px-3\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3398a9f51ff6e675ad63c55ee62a940eb8f5610218131", async() => {
                WriteLiteral("\r\n                                        Detaylar\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 123 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                                              WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                                </div>   \r\n                                <div class=\"menu-item px-3\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3398a9f51ff6e675ad63c55ee62a940eb8f5610220632", async() => {
                WriteLiteral("\r\n                                        Risk Kütüphane Düzenle\r\n                                    ");
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
#line 128 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                                                        WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"menu-item px-3\">\r\n                                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 5616, "\"", 5648, 3);
            WriteAttributeValue("", 5626, "VeriSil(", 5626, 8, true);
#nullable restore
#line 133 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
WriteAttributeValue("", 5634, item.Id, 5634, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5642, ",this)", 5642, 6, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"menu-link px-3\">\r\n                                        Sil\r\n                                    </a>\r\n                                </div>\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 140 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                    siraNo++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"card-footer\">\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#tblBirim"").DataTable({
            ""pageLength"": 5,
            language: {
                ""sDecimal"": "","",
                ""sEmptyTable"": ""Tabloda herhangi bir veri mevcut değil"",

                 ""sInfo"": 'Toplam kayıttan _START_  - _END_ arasındaki kayıtlar gösteriliyor.' + ""Toplam ""+");
#nullable restore
#line 158 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                                                                                                      Write(ViewBag.Risk);

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
#line 222 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                         Write(Url.Action("Delete", "Risk_Analiz"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                        headers: {\'");
#nullable restore
#line 223 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
                              Write(tokenSet.HeaderName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' : \'");
#nullable restore
#line 223 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Risk_Analiz\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InformsISG.Entities.Dtos.Risk_AnalizDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
