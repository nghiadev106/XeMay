#pragma checksum "D:\DA\XeMay\XeMay\Views\Shared\Components\Menu\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1744b18c4e94a0d8c0a5617e1590c4c1dd79a86e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Menu_Index), @"mvc.1.0.view", @"/Views/Shared/Components/Menu/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1744b18c4e94a0d8c0a5617e1590c4c1dd79a86e", @"/Views/Shared/Components/Menu/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32cbdda916fbb7c519415a1ef4b2670e946ed512", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Menu_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<XeMay.Models.MenuViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""nav-item"">
        <div class=""container"">
            <div class=""nav-depart"">
                <div class=""depart-btn"">
                    <i class=""ti-menu""></i>
                    <span>Danh mục</span>
                    <ul class=""depart-hover"">
");
#nullable restore
#line 10 "D:\DA\XeMay\XeMay\Views\Shared\Components\Menu\Index.cshtml"
                         if (Model.Categories.Count() > 0)
                        {
                            foreach (var item in Model.Categories)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a");
            BeginWriteAttribute("href", " href=\"", 537, "\"", 571, 4);
            WriteAttributeValue("", 544, "/loai-xe/", 544, 9, true);
#nullable restore
#line 14 "D:\DA\XeMay\XeMay\Views\Shared\Components\Menu\Index.cshtml"
WriteAttributeValue("", 553, item.Url, 553, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 562, "/", 562, 1, true);
#nullable restore
#line 14 "D:\DA\XeMay\XeMay\Views\Shared\Components\Menu\Index.cshtml"
WriteAttributeValue("", 563, item.Id, 563, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 14 "D:\DA\XeMay\XeMay\Views\Shared\Components\Menu\Index.cshtml"
                                                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 15 "D:\DA\XeMay\XeMay\Views\Shared\Components\Menu\Index.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                     
                    </ul>
                </div>
            </div>
            <nav class=""nav-menu mobile-menu"">
                <ul>
                    <li><a href=""/"">Trang chủ</a></li>
                    <li><a href=""/shop"">Cửa hàng</a></li>
                    <li><a href=""/gio-hang"">Giỏ hàng</a></li>
                    <li><a href=""/tin-tuc"">Tin tức</a></li>
                    <li><a href=""/lien-he"">Liên hệ</a></li>
                </ul>
            </nav>
            <div id=""mobile-menu-wrap""></div>
        </div>
    </div>

   ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<XeMay.Models.MenuViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
