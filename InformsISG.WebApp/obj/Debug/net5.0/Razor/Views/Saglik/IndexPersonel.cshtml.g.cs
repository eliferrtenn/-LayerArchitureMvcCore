#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3af7d0d0272bd687c68b2092f610e87993f32aad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Saglik_IndexPersonel), @"mvc.1.0.view", @"/Views/Saglik/IndexPersonel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3af7d0d0272bd687c68b2092f610e87993f32aad", @"/Views/Saglik/IndexPersonel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Saglik_IndexPersonel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InformsISG.Entities.Dtos.Personel_BilgiDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChoosePersonel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("menu-link px-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
  
    ViewData["Title"] = "IndexPersonel";
    var TaliBirimListe = (List<InformsISG.Entities.Dtos.Tali_BirimDTO>)ViewBag.TaliBirimListe;
    var SiraNo = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card shadow-sm\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">MUAYENE ??????N PERSONEL SE????M??</h3>\r\n        <div class=\"card-toolbar\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 409, "\"", 453, 1);
#nullable restore
#line 12 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
WriteAttributeValue("", 416, Url.Action("IndexPersonel","Saglik"), 416, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success btn-hover-rotate-end\">\r\n                Personel Bul\r\n            </a>&nbsp;\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 570, "\"", 606, 1);
#nullable restore
#line 15 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
WriteAttributeValue("", 577, Url.Action("Index","Saglik"), 577, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-danger btn-hover-rotate-start"">GER?? D??N</a>

        </div>
    </div>
    <div class=""card-body"">
        <table id=""tblBirim"" class=""table table-striped table-row-bordered gy-5 gs-7"">
            <thead>
                <tr>
                    <th>S??ra No</th>
                    <th>
                        ");
#nullable restore
#line 25 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayNameFor(model => model.Ad_Soyad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 28 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayNameFor(model => model.Sicil_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 31 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayNameFor(model => model.Tc_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 34 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayNameFor(model => model.Sgk_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 37 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayNameFor(model => model.Telefon1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayNameFor(model => model.Tali_Birim_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>????lemler</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 46 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 49 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(SiraNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 51 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Ad_Soyad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 54 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Sicil_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 57 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Tc_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 60 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Sgk_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 63 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Telefon1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n");
#nullable restore
#line 67 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                         foreach (var item3 in TaliBirimListe)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                             if (item3.Id == item.Tali_Birim_Id)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                           Write(Html.DisplayFor(modelItem => item3.Tali_Birim_Ad));

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                                                                                  

                            }
                            else
                            {

                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n\r\n                    <td>\r\n                        <div class=\"menu-item px-3\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3af7d0d0272bd687c68b2092f610e87993f32aad11995", async() => {
                WriteLiteral("\r\n                                Se??\r\n                            ");
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
#line 83 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
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
            WriteLiteral("\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 89 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Saglik\IndexPersonel.cshtml"
                    SiraNo++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"card-footer\">\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
        <script>
            $(""#tblBirim"").DataTable({
                ""pageLength"": 50,
                language: {
                ""sDecimal"": "","",
                    ""sEmptyTable"": ""Tabloda herhangi bir veri mevcut de??il"",
                    ""sInfoEmpty"": ""Kay??t yok"",

                    ""sInfoFiltered"": ""(MAX kay??t i??erisinden bulunan)"",
                    ""sInfoThousands"": ""."",
                    ""sLengthMenu"": ""Sayfada MENU kay??t g??ster"",
                    ""sLoadingRecords"": ""Y??kleniyor..."",
                    ""sProcessing"": ""????leniyor..."",
                    ""sSearch"": ""Ara:"",
                    ""sZeroRecords"": ""E??le??en kay??t bulunamad??"",
                    ""oPaginate"": {
                ""sFirst"": ""??lk"",
                        ""sLast"": ""Son"",
                        ""sNext"": ""Sonraki"",
                        ""sPrevious"": ""??nceki""
                    },
                    ""oAria"": {
                ""sSortAscending"": "": artan s??tun s??ralamas??n?? aktifle??tir"",
      ");
                WriteLiteral(@"                  ""sSortDescending"": "": azalan s??tun s??ralamas??n?? aktifle??tir""
                    },
                    ""select"": {
                ""rows"": {
                ""_"": ""%d kay??t se??ildi"",
                            ""1"": ""1 kay??t se??ildi""
                        }
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


");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InformsISG.Entities.Dtos.Personel_BilgiDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
