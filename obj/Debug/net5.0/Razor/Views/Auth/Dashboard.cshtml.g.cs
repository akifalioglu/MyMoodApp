#pragma checksum "/var/www/MoodApp/Views/Auth/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1090d5bd68a87c57f40bc2226738e42c89b8b0f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Dashboard), @"mvc.1.0.view", @"/Views/Auth/Dashboard.cshtml")]
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
#line 1 "/var/www/MoodApp/Views/_ViewImports.cshtml"
using MoodApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/var/www/MoodApp/Views/_ViewImports.cshtml"
using MoodApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1090d5bd68a87c57f40bc2226738e42c89b8b0f8", @"/Views/Auth/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fa8218eff51fb94629e67fd7eefe0f87366ae31", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<h2>İşlem Yapacağınız Alan</h2>\n\n<a href=\"/Question/Add\">Ekleme Sayfası</a><br>\n<a href=\"/Question/Update\">Silme ve Güncelleme Sayfası</a><br>\n<a href=\"AssignRole\">Yetki ataması</a><br>\n<a href=\"AddUser\">Yeni Kullanıcı Ekle</a>");
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
