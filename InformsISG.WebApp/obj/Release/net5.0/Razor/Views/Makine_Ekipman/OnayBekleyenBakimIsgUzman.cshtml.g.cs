#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04ff95f0f829946672f6b4b4f1a206c655d0d929"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Makine_Ekipman_OnayBekleyenBakimIsgUzman), @"mvc.1.0.view", @"/Views/Makine_Ekipman/OnayBekleyenBakimIsgUzman.cshtml")]
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
#line 2 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04ff95f0f829946672f6b4b4f1a206c655d0d929", @"/Views/Makine_Ekipman/OnayBekleyenBakimIsgUzman.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Makine_Ekipman_OnayBekleyenBakimIsgUzman : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InformsISG.Entities.Dtos.Makine_Ekipman_Bakim_PlanlariDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OnayIsgUzman", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("menu-link px-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReddetIsgUzman", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetailBakimIsgUzman", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
  
    var tokenSet = antiforgery.GetAndStoreTokens(Context);
    ViewData["Title"] = "Index";
    int siraNo = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card shadow-sm\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">MAKİNE EKİPMAN BAKIM LİSTESİ</h3>\r\n        <div class=\"card-toolbar\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 455, "\"", 516, 1);
#nullable restore
#line 14 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
WriteAttributeValue("", 462, Url.Action("RedBakimBirimSorumlusu","Makine_Ekipman"), 462, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success btn-hover-rotate-end\">Reddedilen Bakımlar</a>&nbsp;\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 608, "\"", 652, 1);
#nullable restore
#line 15 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
WriteAttributeValue("", 615, Url.Action("Index","Makine_Ekipman"), 615, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-danger btn-hover-rotate-start"">GERİ DÖN</a>
        </div>
    </div>
    <div class=""card-body"">
        <table id=""tblBirim"" class=""table table-striped table-row-bordered gy-5 gs-7"">
            <thead>
                <tr>
                    <th>Sıra No</th>
                    <th>
                        ");
#nullable restore
#line 24 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                   Write(Html.DisplayNameFor(model => model.Servis_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 27 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                   Write(Html.DisplayNameFor(model => model.Diger_Servis_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 30 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                   Write(Html.DisplayNameFor(model => model.Bakim_Tip));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 33 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                   Write(Html.DisplayNameFor(model => model.Durum));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n\r\n                    </th>\r\n                    <th></th>\r\n                    <th></th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 44 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                 foreach (var item in Model)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                     if (item.OnayIsgUzman == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 49 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                           Write(siraNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 51 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Servis_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 54 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Diger_Servis_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 56 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                             if (item.Bakim_Tip == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    Periyodik Planlı Bakım\r\n                                </td>\r\n");
#nullable restore
#line 61 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                            }
                            else if (item.Bakim_Tip == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    Arıza Tamiri\r\n                                </td>\r\n");
#nullable restore
#line 67 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                            }
                            else if (item.Bakim_Tip == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    Periyodik Kontrol\r\n                                </td>\r\n");
#nullable restore
#line 73 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                             if (item.Durum == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    Uygun\r\n                                </td>\r\n");
#nullable restore
#line 79 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                            }
                            else if (item.Durum == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    Kusurlu\r\n                                </td>\r\n");
#nullable restore
#line 85 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                            }
                            else if (item.Durum == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    Ağır Kusurlu\r\n                                </td>\r\n");
#nullable restore
#line 91 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04ff95f0f829946672f6b4b4f1a206c655d0d92913476", async() => {
                WriteLiteral("Onayla");
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
#line 94 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
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
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04ff95f0f829946672f6b4b4f1a206c655d0d92915872", async() => {
                WriteLiteral("Reddet");
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
#line 97 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
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
            WriteLiteral(@"
                            </td>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04ff95f0f829946672f6b4b4f1a206c655d0d92918949", async() => {
                WriteLiteral("\r\n                                            Ayrıntılar\r\n                                        ");
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
#line 108 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
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
            WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"menu-item px-3\">\r\n                                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 5110, "\"", 5142, 3);
            WriteAttributeValue("", 5120, "VeriSil(", 5120, 8, true);
#nullable restore
#line 113 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
WriteAttributeValue("", 5128, item.Id, 5128, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5136, ",this)", 5136, 6, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""menu-link px-3"">
                                            Sil
                                        </a>
                                    </div>
                                </div>
                            </td>
                        </tr>
");
#nullable restore
#line 120 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                        siraNo++;
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                     }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n        </table>\r\n    </div>\r\n\r\n    <div class=\"card-footer\">\r\n    </div>\r\n</div>\r\n");
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
#line 136 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                                                                                                      Write(ViewBag.Ekipman);

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
                cancelBut");
                WriteLiteral(@"tonColor: '#f1416c',
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
#line 201 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                         Write(Url.Action("DeleteBakim", "Makine_Ekipman"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                        headers: {\'");
#nullable restore
#line 202 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
                              Write(tokenSet.HeaderName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\' : \'");
#nullable restore
#line 202 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Makine_Ekipman\OnayBekleyenBakimIsgUzman.cshtml"
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
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InformsISG.Entities.Dtos.Makine_Ekipman_Bakim_PlanlariDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591