#pragma checksum "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a34d4b9452a0d957c5638a542b6dccc9b0f570e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blogs_ListBlogs), @"mvc.1.0.view", @"/Views/Blogs/ListBlogs.cshtml")]
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
#line 1 "D:\Outsource\flower\WebsiteBanHang\Views\_ViewImports.cshtml"
using WebsiteBanHang;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Outsource\flower\WebsiteBanHang\Views\_ViewImports.cshtml"
using WebsiteBanHang.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a34d4b9452a0d957c5638a542b6dccc9b0f570e9", @"/Views/Blogs/ListBlogs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea9d782b3b6a4d4d62df034c111d3c646244e96", @"/Views/_ViewImports.cshtml")]
    public class Views_Blogs_ListBlogs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
  
    var ListBlog = (List<WebsiteBanHang.Data.News>)ViewBag.ListBlog;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"}
<div id=""content"">
    <div class=""wrapper"">
        <div class=""lf"">
            <ul class=""crumbs"">
                <li>
                    <h2>
                        <a id=""ctl00_cphContent_hplHomepage"" title=""Trang chủ"" href=""/"">Trang chủ</a>
                    </h2>
                </li>
                <li>
                    <h1>
                        <a id=""ctl00_cphContent_hplNews"" title=""Blog"" href=""#"">Blog</a>
                    </h1>
                </li>
            </ul>
            <input type=""hidden"" name=""ctl00$cphContent$ucNews$hdfMaxResult"" id=""ctl00_cphContent_ucNews_hdfMaxResult"" value=""8"" />
            <div class=""cms_news"">
");
#nullable restore
#line 22 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
                 if (ListBlog.Count() > 0)
                {
                    foreach (var item in ListBlog)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"item\">\r\n                            <div class=\"item_img\">\r\n                                <a");
            BeginWriteAttribute("title", "  title=\"", 1030, "\"", 1049, 1);
#nullable restore
#line 28 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1039, item.Name, 1039, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1050, "\"", 1081, 4);
            WriteAttributeValue("", 1057, "/blog/", 1057, 6, true);
#nullable restore
#line 28 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1063, item.Url, 1063, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1072, "-", 1072, 1, true);
#nullable restore
#line 28 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1073, item.Id, 1073, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("alt", " alt=\"", 1087, "\"", 1103, 1);
#nullable restore
#line 28 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1093, item.Name, 1093, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1104, "\"", 1122, 1);
#nullable restore
#line 28 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1112, item.Name, 1112, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 1123, "\"", 1139, 1);
#nullable restore
#line 28 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1129, item.Logo, 1129, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height:150px;width:200px;border-width:0px;\" /></a>\r\n                            </div>\r\n                            <div class=\"item_info\">\r\n                                <h3>\r\n                                    <a");
            BeginWriteAttribute("title", "  title=\"", 1365, "\"", 1384, 1);
#nullable restore
#line 32 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1374, item.Name, 1374, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1385, "\"", 1416, 4);
            WriteAttributeValue("", 1392, "/blog/", 1392, 6, true);
#nullable restore
#line 32 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1398, item.Url, 1398, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1407, "-", 1407, 1, true);
#nullable restore
#line 32 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1408, item.Id, 1408, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
                                                                                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </h3>\r\n                                <div class=\"desc\">\r\n                                    ");
#nullable restore
#line 35 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
                               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <a class=\"more\" title=\"Xem thêm\"");
            BeginWriteAttribute("href", " href=\"", 1684, "\"", 1715, 4);
            WriteAttributeValue("", 1691, "/blog/", 1691, 6, true);
#nullable restore
#line 37 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1697, item.Url, 1697, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1706, "-", 1706, 1, true);
#nullable restore
#line 37 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
WriteAttributeValue("", 1707, item.Id, 1707, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Xem thêm</a>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 40 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>Không có bài viết nào</div>\r\n");
#nullable restore
#line 45 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n        <div class=\"rt\">\r\n            ");
#nullable restore
#line 51 "D:\Outsource\flower\WebsiteBanHang\Views\Blogs\ListBlogs.cshtml"
       Write(await Html.PartialAsync("_BannerTab"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"line-b padding_top_20\">\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591