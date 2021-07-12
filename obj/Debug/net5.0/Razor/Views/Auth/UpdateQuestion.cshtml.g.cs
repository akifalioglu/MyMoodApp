#pragma checksum "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "661366e1f9645524b512a380116e33696971f5fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_UpdateQuestion), @"mvc.1.0.view", @"/Views/Auth/UpdateQuestion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"661366e1f9645524b512a380116e33696971f5fc", @"/Views/Auth/UpdateQuestion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fa8218eff51fb94629e67fd7eefe0f87366ae31", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_UpdateQuestion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateQuestion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script>\n    function deleteElement(id)\n    {\n        var btnDelete=  document.getElementById(\"btn\"+id).remove();\n        document.getElementById(\"txtDescription\"+id).remove();\n        document.getElementById(\"txtOption\"+id).remove();\n    }\n</script>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "661366e1f9645524b512a380116e33696971f5fc4606", async() => {
                WriteLiteral("\n\n");
#nullable restore
#line 11 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
  
if(ViewBag.QuestionList is not null)
{
    if(ViewBag.QuestionList.Rows.Count==0)
    {
        ViewBag.Message="Böyle bir kayıt yok...";
    }
    else
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <textarea name=\"txtQuestion\">");
#nullable restore
#line 20 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
                                Write(ViewBag.QuestionList.Rows[0]["question"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea><br>\n");
#nullable restore
#line 21 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
        string optName;
        string btnName;
        string dscName;
        int sayac=1;
        for (int i = 0; i < ViewBag.QuestionList.Rows.Count; i++)
        {
            optName="txtOption"+@sayac;
            dscName="txtDescription"+@sayac;
            btnName="btn"+@sayac;
            

#line default
#line hidden
#nullable disable
                WriteLiteral("<input type=\"text\"");
                BeginWriteAttribute("name", " name=\"", 927, "\"", 942, 1);
#nullable restore
#line 30 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
WriteAttributeValue("", 934, optName, 934, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 943, "\"", 956, 1);
#nullable restore
#line 30 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
WriteAttributeValue("", 948, optName, 948, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Seçenek...\"");
                BeginWriteAttribute("value", " value=\"", 982, "\"", 1029, 1);
#nullable restore
#line 30 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
WriteAttributeValue("", 990, ViewBag.QuestionList.Rows[i]["answer"], 990, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><br>\n            <textarea");
                BeginWriteAttribute("name", " name=\"", 1057, "\"", 1072, 1);
#nullable restore
#line 31 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
WriteAttributeValue("", 1064, dscName, 1064, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 1073, "\"", 1086, 1);
#nullable restore
#line 31 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
WriteAttributeValue("", 1078, dscName, 1078, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Açıklama...\">");
#nullable restore
#line 31 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
                                                                         Write(ViewBag.QuestionList.Rows[i]["text"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea><br>\n            <input type=\"button\"");
                BeginWriteAttribute("id", " id=\"", 1199, "\"", 1212, 1);
#nullable restore
#line 32 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
WriteAttributeValue("", 1204, btnName, 1204, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" value=\"*Sil*\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1227, "\"", 1254, 3);
                WriteAttributeValue("", 1237, "deleteElement(", 1237, 14, true);
#nullable restore
#line 32 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
WriteAttributeValue("", 1251, i, 1251, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1253, ")", 1253, 1, true);
                EndWriteAttribute();
                WriteLiteral("><hr>\n");
#nullable restore
#line 33 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
            sayac++;
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        <input type=\"submit\" value=\"Submit\"/>\n");
#nullable restore
#line 36 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
    }
}

#line default
#line hidden
#nullable disable
                WriteLiteral("<h2>");
#nullable restore
#line 38 "/var/www/MoodApp/Views/Auth/UpdateQuestion.cshtml"
Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\n");
                WriteLiteral("\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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