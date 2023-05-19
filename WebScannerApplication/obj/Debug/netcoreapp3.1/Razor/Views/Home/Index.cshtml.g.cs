#pragma checksum "C:\Users\pragyan.nayak\source\repos\WebScannerApplication\WebScannerApplication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4bdb61c86c0ac2761e15fa88ad09cce05e29095b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\pragyan.nayak\source\repos\WebScannerApplication\WebScannerApplication\Views\_ViewImports.cshtml"
using WebScannerApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pragyan.nayak\source\repos\WebScannerApplication\WebScannerApplication\Views\_ViewImports.cshtml"
using WebScannerApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bdb61c86c0ac2761e15fa88ad09cce05e29095b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf706915ac0ed10f0d6b6492afc13a7d54244014", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("<!DOCTYPE html>\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4bdb61c86c0ac2761e15fa88ad09cce05e29095b3330", async() => {
                WriteLiteral(@"
    <title>websocket client</title>

    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"" integrity=""sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u"" crossorigin=""anonymous"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"" integrity=""sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp"" crossorigin=""anonymous"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"" integrity=""sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"" crossorigin=""anonymous""></script>


    <script type=""text/javascript"">var selDiv = """";
        var storedFiles = [];

        $(document).ready(function () {
            selDiv = $(""#selectedFiles"");
            $(""body"").on(""click"", "".selFile"", editFiles);
        });

        var start =");
                WriteLiteral(@" function () {
            var i = 0;

            var wsImpl = window.WebSocket || window.MozWebSocket;

            window.ws = new wsImpl('ws://localhost:8182/');
            ws.onmessage = function (e) {
                if (typeof e.data === ""string"") {
                    //IF Received Data is String
                }
                else if (e.data instanceof ArrayBuffer) {
                   //IF Received Data is ArrayBuffer
                }
                else if (e.data instanceof Blob) {

                    i++;

                    var f = e.data;

                    f.name = ""File"" + i;

                    storedFiles.push(f);

                    var reader = new FileReader();

                    reader.onload = function (e) {
                        var html = ""<div class=\""col-sm-2 text-center\"" style=\""border: 1px solid black; margin-left: 2px;\""><img height=\""200px\"" width=\""200px\"" src=\"""" + e.target.result + ""\"" data-file='"" + f.name + ""' class='selFile' title='Click to remove'><br/>""");
                WriteLiteral(@" + i + ""</div>"";
                        selDiv.append(html);
                    }
                    reader.readAsDataURL(f);
                }
            };
            ws.onopen = function () {
                //Do whatever u want when connected succesfully
            };
            ws.onclose = function () {
                //Do whatever u want when Connection dismissed
            };
        }
        window.onload = start;

        function scanImage() {
            ws.send(""1100"");
        };

        function editFiles(e) {
            var file = $(this).data(""file"");
            for (var i = 0; i < storedFiles.length; i++) {
                if (storedFiles[i].name === file) {
                    $('.mm').modal('show');
                    var c = document.getElementById(""myCanvas"");
                    var ctx = c.getContext(""2d"");
                    var img = new Image();
                    img.src = window.URL.createObjectURL(storedFiles[i]);
                    img.onload = function () {
   ");
                WriteLiteral(@"                     c.width = img.width ;
                        c.height = img.height;
                        ctx.drawImage(img, 0, 0, img.width, img.height);
                    }
                    break;

                }
            }
        };
    </script>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4bdb61c86c0ac2761e15fa88ad09cce05e29095b7807", async() => {
                WriteLiteral("\n    <button type=\"button\" onclick=\"scanImage();\" class=\"btn btn-primary btn-lg\">Scan</button>\n    <br />\n\n\n");
                WriteLiteral(@"    <div id=""selectedFiles"" class=""row"" style=""padding: 3px""></div>

    <div class=""modal fade mm"" role=""dialog"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div style=""max-height:1200px;overflow:scroll;"">
                    <canvas id=""myCanvas""></canvas>
                </div>
            </div>
        </div>
    </div>
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