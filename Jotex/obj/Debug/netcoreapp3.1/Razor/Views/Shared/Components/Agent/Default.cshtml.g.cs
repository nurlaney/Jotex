#pragma checksum "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Agent\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab36545c61a96d5103cf7ab45b1ce87b98b64246"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Agent_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Agent/Default.cshtml")]
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
#line 1 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\_ViewImports.cshtml"
using Jotex;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\_ViewImports.cshtml"
using Jotex.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\_ViewImports.cshtml"
using Repository.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab36545c61a96d5103cf7ab45b1ce87b98b64246", @"/Views/Shared/Components/Agent/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd9e91776d8d115ce471fb969d7cad9cf67144dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Agent_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AgentViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- start agents-section -->
<section class=""agents-section p-b-0 section-padding"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col col-xs-12"">
                <div class=""agents-area-with-title"">
                    <div class=""agents-grids clearfix"">
                        <div class=""grid"">
                            <div class=""section-title"">
                                <span>Agents</span>
                            </div>
                        </div>
");
#nullable restore
#line 15 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Agent\Default.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"grid\">\r\n                                <div class=\"img-holder\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 827, "\"", 873, 1);
#nullable restore
#line 19 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Agent\Default.cshtml"
WriteAttributeValue("", 833, _cloudinaryService.BuildUrl(item.Image), 833, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </div>\r\n                                <div class=\"agent-info\">\r\n                                    <h4>");
#nullable restore
#line 22 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Agent\Default.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    <p>");
#nullable restore
#line 23 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Agent\Default.cshtml"
                                  Write(item.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 26 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Agent\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div> <!-- end container -->\r\n</section>\r\n<!-- end agents-section -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICloudinaryService _cloudinaryService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AgentViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
