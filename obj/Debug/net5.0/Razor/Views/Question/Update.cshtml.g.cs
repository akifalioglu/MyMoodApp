#pragma checksum "/var/www/MoodApp/Views/Question/Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d964dc0b877836bde74bbd8055798c561f2ff239"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Question_Update), @"mvc.1.0.view", @"/Views/Question/Update.cshtml")]
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
#nullable restore
#line 2 "/var/www/MoodApp/Views/Question/Update.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d964dc0b877836bde74bbd8055798c561f2ff239", @"/Views/Question/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fa8218eff51fb94629e67fd7eefe0f87366ae31", @"/Views/_ViewImports.cshtml")]
    public class Views_Question_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d964dc0b877836bde74bbd8055798c561f2ff2394664", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d964dc0b877836bde74bbd8055798c561f2ff2395764", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d964dc0b877836bde74bbd8055798c561f2ff2396864", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"  <!-- Content Wrapper. Contains page content -->
  <div class=""content-wrapper"">
    <!-- Content Header (Page header) -->
    <div class=""content-header"">
      <div class=""container-fluid"">
        <div class=""row mb-2"">
          <div class=""col-sm-6"">
            <h1 class=""m-0"">Yazı Düzenleme veya Silme</h1>
          </div><!-- /.col -->
          <div class=""col-sm-6"">
            <ol class=""breadcrumb float-sm-right"">
              <li class=""breadcrumb-item""><a href=""#"">Question</a></li>
              <li class=""breadcrumb-item active"">Update</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
      <section class=""content"">
        <div class=""container-fluid"">
          <div class=""row"">
            <div class=""col-md-12"">
            <!-- general form elements -->
            <!-- /.card -->

            <div class=""card"">
              <div class=""card-header"">
                <h3 class=""card-title"">İşlem Yapılacak Kayıt</h3>
");
            WriteLiteral("              </div>\n");
#nullable restore
#line 33 "/var/www/MoodApp/Views/Question/Update.cshtml"
                
                    if (Context.Session.GetString("ses_errorMessage") is string)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                      <div class=""alert alert-danger alert-dismissible"">
                          <button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">×</button>
                          <h5><i class=""icon fas fa-ban""></i> Uyarı !</h5>
                          ");
#nullable restore
#line 39 "/var/www/MoodApp/Views/Question/Update.cshtml"
                     Write(Context.Session.GetString("ses_errorMessage"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 40 "/var/www/MoodApp/Views/Question/Update.cshtml"
                            Context.Session.Remove("ses_errorMesssage");

#line default
#line hidden
#nullable disable
            WriteLiteral("                      </div>   \n");
#nullable restore
#line 42 "/var/www/MoodApp/Views/Question/Update.cshtml"
                    }
                    
                    if (Context.Session.GetString("ses_succesMessage") is string)
                    {
                      Context.Session.Remove("ses_succesMesssage");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                      <div class=""alert alert-success alert-dismissible"">
                          <button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">×</button>
                          <h5><i class=""icon fas fa-check""></i> Başarılı !</h5>
                          ");
#nullable restore
#line 50 "/var/www/MoodApp/Views/Question/Update.cshtml"
                     Write(Context.Session.GetString("ses_succesMessage"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 51 "/var/www/MoodApp/Views/Question/Update.cshtml"
                            Context.Session.Remove("ses_succesMessage");

#line default
#line hidden
#nullable disable
            WriteLiteral("                      </div>   \n");
#nullable restore
#line 53 "/var/www/MoodApp/Views/Question/Update.cshtml"
                    }
              

#line default
#line hidden
#nullable disable
            WriteLiteral(@"              <!-- /.card-header -->
              <div class=""card-body"">
                <table id=""example1"" class=""table table-bordered table-striped"">
                  <thead>
                  <tr>
                    <th>Başlık</th>
                    <th>Sil</th>
                    <th>Düzenle</th>
                  </tr>
                  </thead>
                  <tbody>
");
#nullable restore
#line 66 "/var/www/MoodApp/Views/Question/Update.cshtml"
                      
                    if (ViewBag.Questions.Rows.Count>0)
                    {
                      for(int i =0; i< ViewBag.Questions.Rows.Count; i++)
                      {

#line default
#line hidden
#nullable disable
            WriteLiteral("                      <tr>\n                        <td>");
#nullable restore
#line 72 "/var/www/MoodApp/Views/Question/Update.cshtml"
                       Write(ViewBag.Questions.Rows[i]["question"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 3339, "\"", 3402, 2);
            WriteAttributeValue("", 3346, "/Question/Update/delete/", 3346, 24, true);
#nullable restore
#line 73 "/var/www/MoodApp/Views/Question/Update.cshtml"
WriteAttributeValue("", 3370, ViewBag.Questions.Rows[i]["id"], 3370, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" > Sil </a></td>\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 3450, "\"", 3514, 2);
            WriteAttributeValue("", 3457, "/Question/UpdateQuestion/", 3457, 25, true);
#nullable restore
#line 74 "/var/www/MoodApp/Views/Question/Update.cshtml"
WriteAttributeValue("", 3482, ViewBag.Questions.Rows[i]["id"], 3482, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> Düzenle |</a></td>\n                      </tr>\n");
#nullable restore
#line 76 "/var/www/MoodApp/Views/Question/Update.cshtml"
                      }
                    }
                  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                  </tbody>
                  <tfoot>
                  <tr>
                    <th>Başlık</th>
                    <th>Sil</th>
                    <th>Düzenle</th>
                  </tr>
                  </tfoot>
                </table>
              </div>
              <!-- /.card-body -->
            </div>
            <!-- /.card -->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
