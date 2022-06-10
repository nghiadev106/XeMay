#pragma checksum "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9051231619a29e7fa5127976f6acb37d8f962e1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Productbrand), @"mvc.1.0.view", @"/Views/Products/Productbrand.cshtml")]
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
#line 1 "D:\DA\XeMay\XeMay\Views\_ViewImports.cshtml"
using XeMay;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DA\XeMay\XeMay\Views\_ViewImports.cshtml"
using XeMay.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9051231619a29e7fa5127976f6acb37d8f962e1f", @"/Views/Products/Productbrand.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32cbdda916fbb7c519415a1ef4b2670e946ed512", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Productbrand : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<XeMay.Models.PaginationSet<XeMay.Model.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
  
    ViewData["Title"] = "Danh mục sản phẩm";
    var ListCate = (List<XeMay.Model.Category>)ViewBag.ListCate;
    var brand = (XeMay.Model.Brand)ViewBag.brand;
    var ListBrand = (List<XeMay.Model.Brand>)ViewBag.ListBrand;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Breadcrumb Section Begin -->
<div class=""breacrumb-section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb-text"">
                    <a href=""/""><i class=""fa fa-home""></i>Trang chủ</a>
                    <span>");
#nullable restore
#line 16 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                     Write(brand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Breadcrumb Section Begin -->
<!-- Product Shop Section Begin -->
<section class=""product-shop spad"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-3 col-md-6 col-sm-8 order-2 order-lg-1 produts-sidebar-filter"">
                <div class=""filter-widget"">
                    <h4 class=""fw-title"">Thương hiệu</h4>
                    <ul class=""filter-catagories"">
");
#nullable restore
#line 31 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                         if (ListBrand.Count() > 0)
                        {
                            foreach (var item in ListBrand)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1327, "\"", 1365, 4);
            WriteAttributeValue("", 1334, "/thuong-hieu/", 1334, 13, true);
#nullable restore
#line 35 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 1347, item.Url, 1347, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1356, "/", 1356, 1, true);
#nullable restore
#line 35 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 1357, item.Id, 1357, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 35 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 36 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"

                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n                <div class=\"filter-widget\">\r\n                    <h4 class=\"fw-title\">Danh mục</h4>\r\n                    <ul class=\"filter-catagories\">\r\n");
#nullable restore
#line 44 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                         if (ListCate.Count() > 0)
                        {
                            foreach (var item in ListCate)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1860, "\"", 1894, 4);
            WriteAttributeValue("", 1867, "/loai-xe/", 1867, 9, true);
#nullable restore
#line 48 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 1876, item.Url, 1876, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1885, "/", 1885, 1, true);
#nullable restore
#line 48 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 1886, item.Id, 1886, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 48 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 49 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"

                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n\r\n            </div>\r\n\r\n            <div class=\"col-lg-9 order-1 order-lg-2\">\r\n                <div class=\"product-list\">\r\n                    <div class=\"row\">\r\n");
#nullable restore
#line 60 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                         if (Model.Items.Count() > 0)
                        {
                            foreach (var item in Model.Items)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-lg-4 col-sm-6\">\r\n                                    <div class=\"product-item\">\r\n                                        <div class=\"pi-pic\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 2605, "\"", 2621, 1);
#nullable restore
#line 67 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 2611, item.Logo, 2611, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2622, "\"", 2628, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n");
#nullable restore
#line 69 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                             if (item.IsNew == true)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"sale\">Sale</div>\r\n");
#nullable restore
#line 72 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            <div class=""icon"">
                                                <i class=""icon_heart_alt""></i>
                                            </div>
                                            <ul>
                                                <li class=""w-icon active""><a href=""#"" class=""btn-add-cart-2"" data-id=""");
#nullable restore
#line 78 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                                                                                                 Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"icon_bag_alt \"></i></a></li>\r\n                                                <li class=\"quick-view\"><a");
            BeginWriteAttribute("href", " href=\"", 3365, "\"", 3400, 4);
            WriteAttributeValue("", 3372, "/san-pham/", 3372, 10, true);
#nullable restore
#line 79 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 3382, item.Url, 3382, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3391, "/", 3391, 1, true);
#nullable restore
#line 79 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 3392, item.Id, 3392, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">+ Chi tiết</a></li>
                                                <li class=""w-icon""><a href=""#""><i class=""fa fa-random""></i></a></li>
                                            </ul>
                                        </div>
                                        <div class=""pi-text"">
                                            <a");
            BeginWriteAttribute("href", " href=\"", 3749, "\"", 3784, 4);
            WriteAttributeValue("", 3756, "/san-pham/", 3756, 10, true);
#nullable restore
#line 84 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 3766, item.Url, 3766, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3775, "/", 3775, 1, true);
#nullable restore
#line 84 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 3776, item.Id, 3776, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <h5>");
#nullable restore
#line 85 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                            </a>\r\n");
#nullable restore
#line 87 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                             if (item.PriceDiscount > 0)
                                            {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"product-price\">\r\n                                                    ");
#nullable restore
#line 92 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                               Write(item.PriceDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    <span>");
#nullable restore
#line 93 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                                     Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                </div>\r\n");
#nullable restore
#line 95 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"product-price\">\r\n                                                    ");
#nullable restore
#line 99 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n");
#nullable restore
#line 101 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 106 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div style=\"margin-top:20px;\">\r\n");
#nullable restore
#line 111 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                     if (Model.TotalPages > 1)
                    {
                        // Create numeric links
                        var startPageIndex = Math.Max(1, Model.Page - Model.MaxPage / 2);
                        var endPageIndex = Math.Min(Model.TotalPages, Model.Page + Model.MaxPage / 2);


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <nav>\r\n                            <ul class=\"pagination\">\r\n");
#nullable restore
#line 119 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                 if (Model.Page > 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"page-item\">\r\n                                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5607, "\"", 5663, 5);
            WriteAttributeValue("", 5614, "?sort=", 5614, 6, true);
#nullable restore
#line 122 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 5620, Model.Sort, 5620, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5631, "&pageSize=", 5631, 10, true);
#nullable restore
#line 122 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 5641, Model.PageSize, 5641, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5656, "&page=1", 5656, 7, true);
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""First"">
                                            <i class=""fa fa-angle-double-left""></i>
                                        </a>
                                    </li>
                                    <li class=""page-item"">
                                        <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 5980, "\"", 6050, 6);
            WriteAttributeValue("", 5987, "?sort=", 5987, 6, true);
#nullable restore
#line 127 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 5993, Model.Sort, 5993, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6004, "&pageSize=", 6004, 10, true);
#nullable restore
#line 127 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6014, Model.PageSize, 6014, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6029, "&page=", 6029, 6, true);
#nullable restore
#line 127 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6035, Model.Page-1, 6035, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                                            <i class=\"fa fa-angle-double-left\"></i>\r\n                                        </a>\r\n                                    </li>\r\n");
#nullable restore
#line 131 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 132 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                 for (int i = startPageIndex; i <= endPageIndex; i++)
                                {
                                    if (Model.Page == i)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"active page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 6593, "\"", 6650, 6);
            WriteAttributeValue("", 6600, "?sort=", 6600, 6, true);
#nullable restore
#line 136 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6606, Model.Sort, 6606, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6617, "&pageSize=", 6617, 10, true);
#nullable restore
#line 136 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6627, Model.PageSize, 6627, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6642, "&page=", 6642, 6, true);
#nullable restore
#line 136 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6648, i, 6648, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 6651, "\"", 6667, 2);
            WriteAttributeValue("", 6659, "Trang", 6659, 5, true);
#nullable restore
#line 136 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue(" ", 6664, i, 6665, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 136 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                                                                                                                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 137 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 6884, "\"", 6941, 6);
            WriteAttributeValue("", 6891, "?sort=", 6891, 6, true);
#nullable restore
#line 140 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6897, Model.Sort, 6897, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6908, "&pageSize=", 6908, 10, true);
#nullable restore
#line 140 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6918, Model.PageSize, 6918, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6933, "&page=", 6933, 6, true);
#nullable restore
#line 140 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 6939, i, 6939, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 6942, "\"", 6958, 2);
            WriteAttributeValue("", 6950, "Trang", 6950, 5, true);
#nullable restore
#line 140 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue(" ", 6955, i, 6956, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 140 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                                                                                                                                         Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 141 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                 if (Model.Page < Model.TotalPages)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"page-item\">\r\n                                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 7271, "\"", 7341, 6);
            WriteAttributeValue("", 7278, "?sort=", 7278, 6, true);
#nullable restore
#line 146 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 7284, Model.Sort, 7284, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7295, "&pageSize=", 7295, 10, true);
#nullable restore
#line 146 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 7305, Model.PageSize, 7305, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7320, "&page=", 7320, 6, true);
#nullable restore
#line 146 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 7326, Model.Page+1, 7326, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""Next"">
                                            <i class=""fa fa-angle-double-right""></i>
                                        </a>
                                    </li>
                                    <li class=""page-item"">
                                        <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 7658, "\"", 7730, 6);
            WriteAttributeValue("", 7665, "?sort=", 7665, 6, true);
#nullable restore
#line 151 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 7671, Model.Sort, 7671, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7682, "&pageSize=", 7682, 10, true);
#nullable restore
#line 151 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 7692, Model.PageSize, 7692, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7707, "&page=", 7707, 6, true);
#nullable restore
#line 151 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
WriteAttributeValue("", 7713, Model.TotalPages, 7713, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Last\">\r\n                                            <i class=\"fa fa-angle-double-right\"></i>\r\n                                        </a>\r\n                                    </li>\r\n");
#nullable restore
#line 155 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </ul>\r\n                        </nav>\r\n");
#nullable restore
#line 158 "D:\DA\XeMay\XeMay\Views\Products\Productbrand.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<XeMay.Models.PaginationSet<XeMay.Model.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591