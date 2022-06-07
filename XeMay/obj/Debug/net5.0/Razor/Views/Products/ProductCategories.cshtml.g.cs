#pragma checksum "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e73fe3b254b2fc683c7705bc064090563fb3aadf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_ProductCategories), @"mvc.1.0.view", @"/Views/Products/ProductCategories.cshtml")]
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
#line 1 "D:\DA\WebTivi\Tivi\Views\_ViewImports.cshtml"
using MayTinh;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DA\WebTivi\Tivi\Views\_ViewImports.cshtml"
using MayTinh.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e73fe3b254b2fc683c7705bc064090563fb3aadf", @"/Views/Products/ProductCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ccc0fe1c0961240b5ee8476c8dce1d3a42796aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_ProductCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MayTinh.Models.PaginationSet<MayTinh.Data.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
  
    ViewData["Title"] = "Danh mục sản phẩm";
    var ListCate = (List<MayTinh.Data.Category>)ViewBag.ListCate;
    var cate = (MayTinh.Data.Category)ViewBag.category;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!--main area-->
<main id=""main"" class=""main-site left-sidebar"">

    <div class=""container"">

        <div class=""wrap-breadcrumb"">
            <ul>
                <li class=""item-link""><a href=""/"" class=""link"">Trang chủ</a></li>
                <li class=""item-link""><span>");
#nullable restore
#line 15 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                       Write(cate.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></li>
            </ul>
        </div>
        <div class=""row"">

            <div class=""col-lg-9 col-md-8 col-sm-8 col-xs-12 main-content-area"">

                <div class=""banner-shop"">
                    <a href=""#"" class=""banner-link"">
                        <figure><img src=""/assets/images/shop-banner.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 862, "\"", 868, 0);
            EndWriteAttribute();
            WriteLiteral("></figure>\r\n                    </a>\r\n                </div>\r\n                <div class=\"row\">\r\n\r\n                    <ul class=\"product-list grid-products equal-container\">\r\n");
#nullable restore
#line 30 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                         if (Model.Items.Count() > 0)
                        {
                            foreach (var item in Model.Items)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <li class=""col-lg-4 col-md-6 col-sm-6 col-xs-6 "">
                                    <div class=""product product-style-3 equal-elem "">
                                        <div class=""product-thumnail"">
                                            <a");
            BeginWriteAttribute("href", " href=\"", 1509, "\"", 1544, 4);
            WriteAttributeValue("", 1516, "/san-pham/", 1516, 10, true);
#nullable restore
#line 37 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 1526, item.Url, 1526, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1535, "/", 1535, 1, true);
#nullable restore
#line 37 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 1536, item.Id, 1536, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1545, "\"", 1563, 1);
#nullable restore
#line 37 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 1553, item.Name, 1553, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <figure><img");
            BeginWriteAttribute("src", " src=\"", 1627, "\"", 1643, 1);
#nullable restore
#line 38 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 1633, item.Logo, 1633, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1644, "\"", 1660, 1);
#nullable restore
#line 38 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 1650, item.Name, 1650, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></figure>\r\n                                            </a>\r\n                                        </div>\r\n                                        <div class=\"product-info\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 1885, "\"", 1920, 4);
            WriteAttributeValue("", 1892, "/san-pham/", 1892, 10, true);
#nullable restore
#line 42 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 1902, item.Url, 1902, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1911, "/", 1911, 1, true);
#nullable restore
#line 42 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 1912, item.Id, 1912, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product-name\"><span>");
#nullable restore
#line 42 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n");
#nullable restore
#line 43 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                             if (item.PriceDiscount > 0)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"wrap-price\"><ins><p class=\"product-price\">");
#nullable restore
#line 45 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                 Write(item.PriceDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></ins> <del><p class=\"product-price\">");
#nullable restore
#line 45 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                                                                             Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></del></div>\r\n");
#nullable restore
#line 46 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"wrap-price\"><ins><p class=\"product-price\">");
#nullable restore
#line 49 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                 Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></ins></div>\r\n");
#nullable restore
#line 50 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"

                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <button data-id=\"");
#nullable restore
#line 52 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                        Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn add-to-cart btn-add-cart-2\">Thêm giỏ hàng</button>\r\n                                        </div>\r\n                                    </div>\r\n                                </li>\r\n");
#nullable restore
#line 56 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n\r\n                </div>\r\n\r\n                <div class=\"wrap-pagination-info\">\r\n                    <div class=\"page-numbers\">\r\n");
#nullable restore
#line 64 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                         if (Model.TotalPages > 1)
                        {
                            // Create numeric links
                            var startPageIndex = Math.Max(1, Model.Page - Model.MaxPage / 2);
                            var endPageIndex = Math.Min(Model.TotalPages, Model.Page + Model.MaxPage / 2);


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <nav>\r\n                                <ul class=\"pagination\">\r\n");
#nullable restore
#line 72 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                     if (Model.Page > 1)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"page-item\">\r\n                                            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3740, "\"", 3796, 5);
            WriteAttributeValue("", 3747, "?sort=", 3747, 6, true);
#nullable restore
#line 75 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 3753, Model.Sort, 3753, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3764, "&pageSize=", 3764, 10, true);
#nullable restore
#line 75 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 3774, Model.PageSize, 3774, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3789, "&page=1", 3789, 7, true);
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""First"">
                                                <i class=""fa fa-angle-double-left""></i>
                                            </a>
                                        </li>
                                        <li class=""page-item"">
                                            <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 4133, "\"", 4203, 6);
            WriteAttributeValue("", 4140, "?sort=", 4140, 6, true);
#nullable restore
#line 80 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 4146, Model.Sort, 4146, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4157, "&pageSize=", 4157, 10, true);
#nullable restore
#line 80 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 4167, Model.PageSize, 4167, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4182, "&page=", 4182, 6, true);
#nullable restore
#line 80 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 4188, Model.Page-1, 4188, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                                                <i class=\"fa fa-angle-double-left\"></i>\r\n                                            </a>\r\n                                        </li>\r\n");
#nullable restore
#line 84 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                     for (int i = startPageIndex; i <= endPageIndex; i++)
                                    {
                                        if (Model.Page == i)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li class=\"active page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4782, "\"", 4839, 6);
            WriteAttributeValue("", 4789, "?sort=", 4789, 6, true);
#nullable restore
#line 89 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 4795, Model.Sort, 4795, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4806, "&pageSize=", 4806, 10, true);
#nullable restore
#line 89 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 4816, Model.PageSize, 4816, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4831, "&page=", 4831, 6, true);
#nullable restore
#line 89 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 4837, i, 4837, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 4840, "\"", 4856, 2);
            WriteAttributeValue("", 4848, "Trang", 4848, 5, true);
#nullable restore
#line 89 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue(" ", 4853, i, 4854, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 89 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                                                                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 90 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5089, "\"", 5146, 6);
            WriteAttributeValue("", 5096, "?sort=", 5096, 6, true);
#nullable restore
#line 93 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5102, Model.Sort, 5102, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5113, "&pageSize=", 5113, 10, true);
#nullable restore
#line 93 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5123, Model.PageSize, 5123, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5138, "&page=", 5138, 6, true);
#nullable restore
#line 93 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5144, i, 5144, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 5147, "\"", 5163, 2);
            WriteAttributeValue("", 5155, "Trang", 5155, 5, true);
#nullable restore
#line 93 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue(" ", 5160, i, 5161, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 93 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                                                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 94 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                     if (Model.Page < Model.TotalPages)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li class=\"page-item\">\r\n                                            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5500, "\"", 5570, 6);
            WriteAttributeValue("", 5507, "?sort=", 5507, 6, true);
#nullable restore
#line 99 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5513, Model.Sort, 5513, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5524, "&pageSize=", 5524, 10, true);
#nullable restore
#line 99 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5534, Model.PageSize, 5534, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5549, "&page=", 5549, 6, true);
#nullable restore
#line 99 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5555, Model.Page+1, 5555, 15, false);

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
            BeginWriteAttribute("href", " href=\"", 5907, "\"", 5979, 6);
            WriteAttributeValue("", 5914, "?sort=", 5914, 6, true);
#nullable restore
#line 104 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5920, Model.Sort, 5920, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5931, "&pageSize=", 5931, 10, true);
#nullable restore
#line 104 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5941, Model.PageSize, 5941, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5956, "&page=", 5956, 6, true);
#nullable restore
#line 104 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 5962, Model.TotalPages, 5962, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Last\">\r\n                                                <i class=\"fa fa-angle-double-right\"></i>\r\n                                            </a>\r\n                                        </li>\r\n");
#nullable restore
#line 108 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n                            </nav>\r\n");
#nullable restore
#line 111 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
            </div><!--end main products area-->

            <div class=""col-lg-3 col-md-4 col-sm-4 col-xs-12 sitebar"">
                <div class=""widget mercado-widget categories-widget"">
                    <h2 class=""widget-title"">Thương hiệu</h2>
                    <div class=""widget-content"">
                        <ul class=""list-category"">
");
#nullable restore
#line 121 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                             if (ListCate.Count() > 0)
                            {
                                foreach (var item in ListCate)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"category-item\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 7032, "\"", 7070, 4);
            WriteAttributeValue("", 7039, "/thuong-hieu/", 7039, 13, true);
#nullable restore
#line 126 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 7052, item.Url, 7052, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7061, "/", 7061, 1, true);
#nullable restore
#line 126 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 7062, item.Id, 7062, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"cate-link\">");
#nullable restore
#line 126 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 128 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </ul>
                    </div>
                </div><!-- Categories widget-->

                <div class=""widget mercado-widget widget-product"">
                    <h2 class=""widget-title"">Sản phẩm bán chạy</h2>
                    <div class=""widget-content"">
                        <ul class=""products"">

");
#nullable restore
#line 140 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                             if (Model.Items.Count() > 0)
                            {
                                foreach (var item in Model.Items.Take(6).ToList())
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <li class=""product-item"">
                                        <div class=""product product-widget-style"">
                                            <div class=""thumbnnail"">
                                                <a");
            BeginWriteAttribute("href", " href=\"", 8039, "\"", 8074, 4);
            WriteAttributeValue("", 8046, "/san-pham/", 8046, 10, true);
#nullable restore
#line 147 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 8056, item.Url, 8056, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8065, "/", 8065, 1, true);
#nullable restore
#line 147 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 8066, item.Id, 8066, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Radiant-360 R6 Wireless Omnidirectional Speaker [White]\">\r\n                                                    <figure><img");
            BeginWriteAttribute("src", " src=\"", 8206, "\"", 8222, 1);
#nullable restore
#line 148 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 8212, item.Logo, 8212, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 8223, "\"", 8229, 0);
            EndWriteAttribute();
            WriteLiteral(" /></figure>\r\n                                                </a>\r\n                                            </div>\r\n                                            <div class=\"product-info\">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 8472, "\"", 8507, 4);
            WriteAttributeValue("", 8479, "/san-pham/", 8479, 10, true);
#nullable restore
#line 152 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 8489, item.Url, 8489, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8498, "/", 8498, 1, true);
#nullable restore
#line 152 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
WriteAttributeValue("", 8499, item.Id, 8499, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"product-name\"><span>");
#nullable restore
#line 152 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                             Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n");
#nullable restore
#line 153 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                 if (item.PriceDiscount > 0)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <div class=\"wrap-price\"><span class=\"product-price\">");
#nullable restore
#line 155 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                   Write(item.PriceDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n");
#nullable restore
#line 156 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"

                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <div class=\"wrap-price\"><span class=\"product-price\">");
#nullable restore
#line 159 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                                                                                 Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n");
#nullable restore
#line 160 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"

                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </div>\r\n                                        </div>\r\n                                    </li>\r\n");
#nullable restore
#line 165 "D:\DA\WebTivi\Tivi\Views\Products\ProductCategories.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                </div><!-- brand widget-->\r\n\r\n            </div><!--end sitebar-->\r\n\r\n        </div><!--end row-->\r\n\r\n    </div><!--end container-->\r\n\r\n</main>\r\n<!--main area-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MayTinh.Models.PaginationSet<MayTinh.Data.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
