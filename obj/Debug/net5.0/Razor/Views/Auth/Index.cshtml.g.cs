#pragma checksum "/var/www/MoodApp/Views/Auth/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abbfb6ebc7d69cbf6d13a7dabf4d1fdb1f298a8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Index), @"mvc.1.0.view", @"/Views/Auth/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abbfb6ebc7d69cbf6d13a7dabf4d1fdb1f298a8b", @"/Views/Auth/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fa8218eff51fb94629e67fd7eefe0f87366ae31", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "/var/www/MoodApp/Views/Auth/Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n<!DOCTYPE html>\n \n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abbfb6ebc7d69cbf6d13a7dabf4d1fdb1f298a8b3230", async() => {
                WriteLiteral("\n    <meta name=\"viewport\" content=\"width=device-width\"/>\n    <title>Index</title>\n");
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abbfb6ebc7d69cbf6d13a7dabf4d1fdb1f298a8b4266", async() => {
                WriteLiteral("\n    <h1>\n");
#nullable restore
#line 15 "/var/www/MoodApp/Views/Auth/Index.cshtml"
      
        if (ViewBag.Status==false)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/var/www/MoodApp/Views/Auth/Index.cshtml"
       Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/var/www/MoodApp/Views/Auth/Index.cshtml"
                            
            return;
        }
    

#line default
#line hidden
#nullable disable
                WriteLiteral("    </h1>\n\n    <h1>");
#nullable restore
#line 24 "/var/www/MoodApp/Views/Auth/Index.cshtml"
   Write(ViewBag.Question);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\n    <ul>\n");
#nullable restore
#line 26 "/var/www/MoodApp/Views/Auth/Index.cshtml"
          
            for(int i =0; i< ViewBag.AnswersList.Count; i++)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <li><a");
                BeginWriteAttribute("href", " href=\'", 441, "\'", 488, 2);
                WriteAttributeValue("", 448, "/Answer?number=", 448, 15, true);
#nullable restore
#line 29 "/var/www/MoodApp/Views/Auth/Index.cshtml"
WriteAttributeValue("", 463, ViewBag.answersListID[i], 463, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 29 "/var/www/MoodApp/Views/Auth/Index.cshtml"
                                                                  Write(ViewBag.answersList[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\n");
#nullable restore
#line 30 "/var/www/MoodApp/Views/Auth/Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("    </ul>\n");
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
            WriteLiteral("\n</html>\n");
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
