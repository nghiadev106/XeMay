#pragma checksum "D:\DA\XeMay\XeMay\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "386a20248956e27604aa0f509f873304b9cded89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"386a20248956e27604aa0f509f873304b9cded89", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32cbdda916fbb7c519415a1ef4b2670e946ed512", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("subscribe-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/js/Toastr/toastr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<!DOCTYPE html>\n<html lang=\"zxx\">\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "386a20248956e27604aa0f509f873304b9cded895001", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""description"" content=""Fashi Template"">
    <meta name=""keywords"" content=""Fashi, unica, creative, html"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>Fashi | Template</title>

    <!-- Google Font -->
    <link href=""https://fonts.googleapis.com/css?family=Muli:300,400,500,600,700,800,900&display=swap"" rel=""stylesheet"">

    <!-- Css Styles -->
    <link rel=""stylesheet"" href=""/assets/css/bootstrap.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""/assets/css/font-awesome.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""/assets/css/themify-icons.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""/assets/css/elegant-icons.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""/assets/css/owl.carousel.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""/assets/css/nice-select.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""/assets/css");
                WriteLiteral("/jquery-ui.min.css\" type=\"text/css\">\n    <link rel=\"stylesheet\" href=\"/assets/css/slicknav.min.css\" type=\"text/css\">\n    <link rel=\"stylesheet\" href=\"/assets/css/style.css\" type=\"text/css\">\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "386a20248956e27604aa0f509f873304b9cded897292", async() => {
                WriteLiteral(@"
    <!-- Page Preloder -->
    <div id=""preloder"">
        <div class=""loader""></div>
    </div>

    <!-- Header Section Begin -->
    <header class=""header-section"">
        <div class=""header-top"">
            <div class=""container"">
                <div class=""ht-left"">
                    <div class=""mail-service"">
                        <i class="" fa fa-envelope""></i>
                        user@gmail.com
                    </div>
                    <div class=""phone-service"">
                        <i class="" fa fa-phone""></i>
                        0987654321
                    </div>
                </div>
                <div class=""ht-right"">
");
                WriteLiteral(@"                    <div class=""top-social"">
                        <a href=""#""><i class=""ti-facebook""></i></a>
                        <a href=""#""><i class=""ti-twitter-alt""></i></a>
                        <a href=""#""><i class=""ti-linkedin""></i></a>
                        <a href=""#""><i class=""ti-pinterest""></i></a>
                    </div>
                </div>
            </div>
        </div>
        <div class=""container"">
            <div class=""inner-header"">
                <div class=""row"">
                    <div class=""col-lg-2 col-md-2"">
                        <div class=""logo"">
                            <a href=""/"">
                                <img src=""/assets/img/logo.png""");
                BeginWriteAttribute("alt", " alt=\"", 3446, "\"", 3452, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                            </a>
                        </div>
                    </div>
                    <div class=""col-lg-7 col-md-7"">
                        <div class=""advanced-search"">
                            <div class=""input-group"">
                                <input type=""text"" placeholder=""Tìm kiếm..."">
                                <button type=""button""><i class=""ti-search""></i></button>
                            </div>
                        </div>
                    </div>
                    <div class=""col-lg-3 text-right col-md-3"">
                        <ul class=""nav-right"">
                            <li class=""cart-icon"">
                                <a href=""/gio-hang"">
                                    <i class=""icon_bag_alt""></i>
                                    <span class=""lbl_number_items_header""></span>
                                </a>
                            </li>
                            <li class=""cart-price""></li>
                      ");
                WriteLiteral("  </ul>\n                    </div>\n                </div>\n            </div>\n        </div>\n        ");
#nullable restore
#line 103 "D:\DA\XeMay\XeMay\Views\Shared\_Layout.cshtml"
   Write(await Component.InvokeAsync("Menu"));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\n\n    </header>\n    <!-- Header End -->\n  ");
#nullable restore
#line 107 "D:\DA\XeMay\XeMay\Views\Shared\_Layout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <!-- Footer Section Begin -->
    <footer class=""footer-section"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-3"">
                    <div class=""footer-left"">
                        <div class=""footer-logo"">
                            <a href=""#""><img src=""/assets/img/footer-logo.png""");
                BeginWriteAttribute("alt", " alt=\"", 5015, "\"", 5021, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
                        </div>
                        <ul>
                            <li>Địa chỉ: Hưng Yên, Việt Nam</li>
                            <li>SĐT: 0987654321</li>
                            <li>Email: user@gmail.com</li>
                        </ul>
                        <div class=""footer-social"">
                            <a href=""#""><i class=""fa fa-facebook""></i></a>
                            <a href=""#""><i class=""fa fa-instagram""></i></a>
                            <a href=""#""><i class=""fa fa-twitter""></i></a>
                            <a href=""#""><i class=""fa fa-pinterest""></i></a>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-2 offset-lg-1"">
                    <div class=""footer-widget"">
                        <h5>Information</h5>
                        <ul>
                            <li><a href=""#"">Về chúng tôi</a></li>
                            <li><a href=""#"">Thanh toán</a></li>
              ");
                WriteLiteral(@"              <li><a href=""#"">Liên hệ</a></li>
                            <li><a href=""#"">Giỏ hàng</a></li>
                        </ul>
                    </div>
                </div>
                <div class=""col-lg-2"">
                    <div class=""footer-widget"">
                        <h5>Tài khoản</h5>
                        <ul>
                            <li><a href=""#"">Tài khoản</a></li>
                            <li><a href=""#"">Liên hệ</a></li>
                            <li><a href=""#"">Giỏ hàng</a></li>
                            <li><a href=""#"">Của hàng</a></li>
                        </ul>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""newslatter-item"">
                        <h5>Newsletter</h5>
                        <p>Gửi Email về cho chúng tôi</p>
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "386a20248956e27604aa0f509f873304b9cded8913313", async() => {
                    WriteLiteral("\n                            <input type=\"text\" placeholder=\"Enter Your Mail\">\n                            <button type=\"button\">Gửi</button>\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                </div>
            </div>
        </div>
        <div class=""copyright-reserved"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <div class=""copyright-text"">
                            <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                            Copyright &copy;
                            <script>document.write(new Date().getFullYear());</script> All rights reserved | This template is made with by NVT
                            <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                        </div>
                        <div class=""payment-pic"">
                            <img src=""/assets/img/payment-method.png""");
                BeginWriteAttribute("alt", " alt=\"", 8011, "\"", 8017, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>
    <!-- Footer Section End -->
    <!-- Js Plugins -->
    <script src=""/assets/js/jquery-3.3.1.min.js""></script>
    <script src=""/assets/js/bootstrap.min.js""></script>
    <script src=""/assets/js/jquery-ui.min.js""></script>
    <script src=""/assets/js/jquery.countdown.min.js""></script>
    <script src=""/assets/js/jquery.nice-select.min.js""></script>
    <script src=""/assets/js/jquery.zoom.min.js""></script>
    <script src=""/assets/js/jquery.dd.min.js""></script>
    <script src=""/assets/js/jquery.slicknav.js""></script>
    <script src=""/assets/js/owl.carousel.min.js""></script>
    <script src=""/assets/js/main.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</html>\n\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "386a20248956e27604aa0f509f873304b9cded8917482", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "386a20248956e27604aa0f509f873304b9cded8918520", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n<script>\n    var site = new SiteController();\n    site.initialize();\n</script>\n");
#nullable restore
#line 205 "D:\DA\XeMay\XeMay\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<link href=\"/admin/js/Toastr/build/toastr.css\" rel=\"stylesheet\" />");
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
