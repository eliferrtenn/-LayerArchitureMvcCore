#pragma checksum "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7ea20ca8003a0ba6e52cf0d8b755a9eccdf0c36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personel_Bilgi_DetailKkd2), @"mvc.1.0.view", @"/Views/Personel_Bilgi/DetailKkd2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7ea20ca8003a0ba6e52cf0d8b755a9eccdf0c36", @"/Views/Personel_Bilgi/DetailKkd2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b979eed0774bf60a61861e228c260c32c44618e", @"/Views/_ViewImports.cshtml")]
    public class Views_Personel_Bilgi_DetailKkd2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InformsISG.Entities.Dtos.Personel_BilgiDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
  
    ViewData["Title"] = "Details";
    TempData["kkdId"] = TempData["kkdId"];
    var Kkd = (InformsISG.Entities.Dtos.KkdDTO)ViewBag.Kkd;


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
#line 34 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
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
#line 42 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                        <div class=""me-7 mb-4"">
                                                            <div class=""symbol symbol-100px symbol-lg-160px symbol-fixed position-relative"">
                                                                <img");
            BeginWriteAttribute("src", " src=\"", 2759, "\"", 2781, 2);
            WriteAttributeValue("", 2765, "/", 2765, 1, true);
#nullable restore
#line 47 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
WriteAttributeValue("", 2766, Model.Fotograf, 2766, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image\" />\r\n\r\n                                                            </div>\r\n                                                        </div>\r\n");
#nullable restore
#line 51 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
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
#line 62 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
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
#line 71 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
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
            BeginWriteAttribute("href", " href=\"", 5168, "\"", 5212, 1);
#nullable restore
#line 78 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
WriteAttributeValue("", 5175, Url.Action("Index","Personel_Bilgi"), 5175, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-sm btn-primary me-2 btn btn-danger"">Geri Dön</a>
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
            BeginWriteAttribute("href", " href=\"", 6198, "\"", 6262, 1);
#nullable restore
#line 92 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
WriteAttributeValue("", 6205, Url.Action("Details","Personel_Bilgi",new {id=Model.Id}), 6205, 57, false);

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
            BeginWriteAttribute("href", " href=\"", 6641, "\"", 6716, 1);
#nullable restore
#line 97 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
WriteAttributeValue("", 6648, Url.Action("DetailMuayene","Personel_Bilgi", new { id = Model.Id }), 6648, 68, false);

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
            BeginWriteAttribute("href", " href=\"", 7099, "\"", 7173, 1);
#nullable restore
#line 102 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
WriteAttributeValue("", 7106, Url.Action("DetailEgitim","Personel_Bilgi", new { id = Model.Id }), 7106, 67, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Eğitim Bilgisi</a>
                                            </li>
                                            <!--end::Nav item-->
                                            <!--begin::Nav item-->
                                            <li class=""nav-item mt-2"">
                                                <a class=""nav-link text-active-primary ms-0 me-10 py-5""");
            BeginWriteAttribute("href", " href=\"", 7555, "\"", 7627, 1);
#nullable restore
#line 107 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
WriteAttributeValue("", 7562, Url.Action("DetailKaza","Personel_Bilgi", new { id = Model.Id }), 7562, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Kaza Bilgisi</a>
                                            </li>
                                            <!--end::Nav item-->
                                            <!--begin::Nav item-->
                                            <li class=""nav-item mt-2"">
                                                <a class=""nav-link text-active-primary ms-0 me-10 py-5 active""");
            BeginWriteAttribute("href", " href=\"", 8014, "\"", 8085, 1);
#nullable restore
#line 112 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
WriteAttributeValue("", 8021, Url.Action("DetailKkd","Personel_Bilgi", new { id = Model.Id }), 8021, 64, false);

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
                        <div class=""card-header cursor-pointer"">
                            <div class=""card-title m-0"">
                                <h3 class=""fw-bolder m-0"">Kkd Bigileri</h3>
                            </div>
              
");
            WriteLiteral(@"                        </div>
                        <div class=""card-body p-9"">
                            <div class=""row mb-7"">
                                <label class=""col-lg-4 fw-bold text-muted"">Kkd No</label>
                                <div class=""col-lg-8"">
                                    <span class=""fw-bolder fs-6 text-gray-800"">");
#nullable restore
#line 146 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                                          Write(Kkd.Kkd_No);

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
#line 152 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                                        Write(Kkd.Kkd_Tanim);

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
#line 160 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                                               Write(Kkd.Uretici);

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
#line 166 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                                                                 Write(Kkd.Parca_No);

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
#line 172 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                                                                 Write(Kkd.Parca_No);

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
#line 178 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                                                                 Write(Kkd.Standart);

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
#line 184 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                                                                                 Write(Kkd.Notlar);

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
#line 190 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                     if (Kkd.Kullanilma_Durumu == true)
                                    {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" class=\"fw-bold fs-6 text-gray-800 text-hover-primary\">Evet</a>\r\n");
#nullable restore
#line 195 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" class=\"fw-bold fs-6 text-gray-800 text-hover-primary\">Hayır</a>\r\n");
#nullable restore
#line 199 "C:\Users\Elif\Desktop\Projeler\InformsISG\InformsISG.WebApp\Views\Personel_Bilgi\DetailKkd2.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
