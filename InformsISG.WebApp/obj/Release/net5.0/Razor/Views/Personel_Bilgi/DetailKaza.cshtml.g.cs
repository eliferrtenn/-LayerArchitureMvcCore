#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "638e7198e4fe93e918a57d5f73a1088691ab7407"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personel_Bilgi_DetailKaza), @"mvc.1.0.view", @"/Views/Personel_Bilgi/DetailKaza.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"638e7198e4fe93e918a57d5f73a1088691ab7407", @"/Views/Personel_Bilgi/DetailKaza.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Personel_Bilgi_DetailKaza : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InformsISG.Entities.Dtos.Personel_BilgiDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetailKaza2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
  
    ViewData["Title"] = "Details";
    var KazaList = (List<InformsISG.Entities.Dtos.KazaDTO>)ViewBag.KazaList;
    TempData["kazaId"] = TempData["kazaId"];
    int siraNo = 1;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""page d-flex flex-row flex-column-fluid container-fluid"" style=""margin-top:2rem"">
    <div class="" flex-column container-fluid "" id=""kt_wrapper"">

        <div class=""content flex-column flex-column-fluid container-fluid"" id=""kt_content"">
            <div class=""post flex-column-fluid"" id=""kt_post"">
                <div id=""kt_content_container"" class=""container-fluid"">


                    <div class="" flex-column flex-root"">
                        <!--begin::Page-->
                        <div class=""page flex-row flex-column-fluid"">

                            <!--end::Aside-->
                            <!--begin::Wrapper-->
                            <div class="" flex-column flex-row-fluid"" id=""kt_wrapper"">
                                <!--begin::Header-->
                                <!--begin::Navbar-->
                                <!--begin::Navbar-->
                                <div class=""card mb-5 mb-xl-10"">
                                    <div c");
            WriteLiteral(@"lass=""card-body pt-9 pb-0"">
                                        <!--begin::Details-->
                                        <div class=""d-flex flex-wrap flex-sm-nowrap mb-3"">
                                            <!--begin: Pic-->
                                            <div class=""me-7 mb-4"">
                                                <div class=""symbol symbol-100px symbol-lg-160px symbol-fixed position-relative"">
");
#nullable restore
#line 35 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                     if (Model.Fotograf == null)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                        <div class=""me-7 mb-4"">
                                                            <div class=""symbol symbol-100px symbol-lg-160px symbol-fixed position-relative"">
                                                                <img src=""/Dosya/Personel/Default/defaultPerson.jpg"" alt=""image"" />

                                                            </div>
                                                        </div>
");
#nullable restore
#line 43 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                        <div class=""me-7 mb-4"">
                                                            <div class=""symbol symbol-100px symbol-lg-160px symbol-fixed position-relative"">
                                                                <img");
            BeginWriteAttribute("src", " src=\"", 2799, "\"", 2821, 2);
            WriteAttributeValue("", 2805, "/", 2805, 1, true);
#nullable restore
#line 48 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
WriteAttributeValue("", 2806, Model.Fotograf, 2806, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image\" />\r\n\r\n                                                            </div>\r\n                                                        </div>\r\n");
#nullable restore
#line 52 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                </div>
                                            </div>
                                            <!--end::Pic-->
                                            <!--begin::Info-->
                                            <div class=""flex-grow-1"">
                                                <!--begin::Title-->
                                                <div class=""d-flex justify-content-between align-items-start flex-wrap mb-2"">
                                                    <!--begin::User-->
                                                    <div class=""d-flex flex-column"">
                                                        <div class=""d-flex align-items-center mb-2"">
                                                            <a href=""#"" class=""text-gray-900 text-hover-primary fs-2 fw-bolder me-1"">");
#nullable restore
#line 63 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                                                                                                Write(Model.Ad_Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>

                                                            <a href=""#"" class=""btn btn-sm btn-light-success fw-bolder ms-2 fs-8 py-1 px-3"" data-bs-toggle=""modal"" data-bs-target=""#kt_modal_upgrade_plan""></a>
                                                        </div>
                                                        <div class=""d-flex flex-wrap fw-bold fs-6 mb-4 pe-2"">
                                                            <a href=""#"" class=""d-flex align-items-center text-gray-400 text-hover-primary me-5 mb-2"">
                                                                <span class=""svg-icon svg-icon-4 me-1"">

                                                                </span>
                                                                ");
#nullable restore
#line 72 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                           Write(Model.Unvan);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <!--end::User-->
                                                    <!--begin::Actions-->
                                                    <div class=""d-flex my-4"">
                                                        <a");
            BeginWriteAttribute("href", " href=\"", 5208, "\"", 5252, 1);
#nullable restore
#line 79 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
WriteAttributeValue("", 5215, Url.Action("Index","Personel_Bilgi"), 5215, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-sm btn-primary me-2 btn btn-danger"">Geri D??n</a>
                                                    </div>
                                                    <!--end::Actions-->
                                                </div>
                                                <!--end::Title-->

                                            </div>
                                            <!--end::Info-->
                                        </div>
                                        <!--end::Details-->
                                        <!--begin::Navs-->
                                        <ul class=""nav nav-stretch nav-line-tabs nav-line-tabs-2x border-transparent fs-5 fw-bolder"">
                                            <!--begin::Nav item-->
                                            <li class=""nav-item mt-2"">
                                                <a class=""nav-link text-active-primary ms-0 me-10 py-5""");
            BeginWriteAttribute("href", " href=\"", 6238, "\"", 6302, 1);
#nullable restore
#line 93 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
WriteAttributeValue("", 6245, Url.Action("Details","Personel_Bilgi",new {id=Model.Id}), 6245, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Genel Bilgi</a>
                                            </li>
                                            <!--end::Nav item-->
                                            <!--begin::Nav item-->
                                            <li class=""nav-item mt-2"">
                                                <a class=""nav-link text-active-primary ms-0 me-10 py-5""");
            BeginWriteAttribute("href", " href=\"", 6681, "\"", 6756, 1);
#nullable restore
#line 98 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
WriteAttributeValue("", 6688, Url.Action("DetailMuayene","Personel_Bilgi", new { id = Model.Id }), 6688, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Muayene Bilgisi</a>
                                            </li>
                                            <!--end::Nav item-->
                                            <!--begin::Nav item-->
                                            <li class=""nav-item mt-2"">
                                                <a class=""nav-link text-active-primary ms-0 me-10 py-5""");
            BeginWriteAttribute("href", " href=\"", 7139, "\"", 7213, 1);
#nullable restore
#line 103 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
WriteAttributeValue("", 7146, Url.Action("DetailEgitim","Personel_Bilgi", new { id = Model.Id }), 7146, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">E??itim Bilgisi</a>
                                            </li>
                                            <!--end::Nav item-->
                                            <!--begin::Nav item-->
                                            <li class=""nav-item mt-2"">
                                                <a class=""nav-link text-active-primary ms-0 me-10 py-5 active""");
            BeginWriteAttribute("href", " href=\"", 7602, "\"", 7674, 1);
#nullable restore
#line 108 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
WriteAttributeValue("", 7609, Url.Action("DetailKaza","Personel_Bilgi", new { id = Model.Id }), 7609, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Kaza Bilgisi</a>
                                            </li>
                                            <!--end::Nav item-->
                                            <!--begin::Nav item-->
                                            <li class=""nav-item mt-2"">
                                                <a class=""nav-link text-active-primary ms-0 me-10 py-5""");
            BeginWriteAttribute("href", " href=\"", 8054, "\"", 8125, 1);
#nullable restore
#line 113 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
WriteAttributeValue("", 8061, Url.Action("DetailKkd","Personel_Bilgi", new { id = Model.Id }), 8061, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Kkd Bilgisi</a>
                                            </li>
                                            <!--end::Nav item-->
                                        </ul>
                                        <!--begin::Navs-->
                                    </div>
                                </div>




                                <!--end::Content-->
                                <!--begin::Footer-->
                                <!--end::Footer-->
                            </div>
                            <!--end::Wrapper-->
                        </div>
                        <!--end::Page-->
                    </div>

                    <div class=""card mb-5 mb-xl-10"" id=""kt_profile_details_view"">
                        <div class=""card-body p-9"">

                            <table id=""tblPersonelBilgi"" class=""table table-striped table-row-bordered gy-5 gs-7"">
                                <thead>
                                    <tr>
     ");
            WriteLiteral(@"                                   <th>
                                            S??ra No
                                        </th>
                                        <th>
                                            Kaza No
                                        </th>
                                        <th>
                                            Kaza Tarih

                                        </th>
                                        <th>
                                            Kaza Saat
                                        </th>

                                    </tr>
                                </thead>
");
#nullable restore
#line 155 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                 foreach (var item in KazaList)
                                {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tbody>\r\n                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 161 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                   Write(siraNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 164 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Kaza_No));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 167 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Kaza_Tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>  \r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 170 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.Kaza_Saat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n\r\n                                                    <td>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "638e7198e4fe93e918a57d5f73a1088691ab740720407", async() => {
                WriteLiteral("\r\n                                                            Detay G??r??nt??le\r\n                                                        ");
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
#line 174 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
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
            WriteLiteral("\r\n                                                    </td>\r\n\r\n                                                </tr>\r\n                                            </tbody>\r\n");
#nullable restore
#line 181 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKaza.cshtml"
                                            siraNo++;

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </table>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InformsISG.Entities.Dtos.Personel_BilgiDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
