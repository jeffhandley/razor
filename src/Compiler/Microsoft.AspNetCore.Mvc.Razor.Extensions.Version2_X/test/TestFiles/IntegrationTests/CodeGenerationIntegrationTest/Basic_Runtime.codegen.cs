﻿#pragma checksum "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3b732a30f94dc763cbd74d150cca70825dbddec2bddfba4e4d82547d5ced9a82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.TestFiles_IntegrationTests_CodeGenerationIntegrationTest_Basic), @"mvc.1.0.view", @"/TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml", typeof(AspNetCore.TestFiles_IntegrationTests_CodeGenerationIntegrationTest_Basic))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"3b732a30f94dc763cbd74d150cca70825dbddec2bddfba4e4d82547d5ced9a82", @"/TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml")]
    public class TestFiles_IntegrationTests_CodeGenerationIntegrationTest_Basic : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("<div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 4, "\"", 28, 1);
#line 1 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml"
WriteAttributeValue("", 12, this.ToString(), 12, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(29, 24, true);
            WriteLiteral(">\r\n    Hello world\r\n    ");
            EndContext();
            BeginContext(54, 29, false);
#line 3 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml"
Write(string.Format("{0}", "Hello"));

#line default
#line hidden
            EndContext();
            BeginContext(83, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
#line 5 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml"
   
    var cls = "foo";

#line default
#line hidden
            BeginContext(123, 2, true);
            WriteLiteral("<p");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 125, "\"", 158, 1);
            WriteAttributeValue("", 133, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 8 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml"
           if(cls != null) { 

#line default
#line hidden
                BeginContext(153, 3, false);
#line 8 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml"
                        Write(cls);

#line default
#line hidden
                EndContext();
#line 8 "TestFiles/IntegrationTests/CodeGenerationIntegrationTest/Basic.cshtml"
                                  }

#line default
#line hidden
                PopWriter();
            }
            ), 133, 25, false);
            EndWriteAttribute();
            BeginContext(159, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
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
