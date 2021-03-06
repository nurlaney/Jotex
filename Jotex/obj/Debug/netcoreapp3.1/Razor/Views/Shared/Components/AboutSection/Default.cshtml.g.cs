#pragma checksum "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "387442aa7c859e3138548bf414d267cd0c0c31eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_AboutSection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/AboutSection/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"387442aa7c859e3138548bf414d267cd0c0c31eb", @"/Views/Shared/Components/AboutSection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd9e91776d8d115ce471fb969d7cad9cf67144dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_AboutSection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AboutCompanyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- start about-section -->
<section class=""about-section section-padding"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col col-xs-12"">
                <div class=""inner clearfix"">
                    <div class=""left-col"">
                        <div class=""section-title"">
                            <span>About us</span>
                            <h2>");
#nullable restore
#line 12 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                           Write(Model.LeftTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        </div>\r\n                        <div class=\"details\">\r\n                            <p>");
#nullable restore
#line 15 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                          Write(Model.LeftText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"fun-fact-area\">\r\n                            <div class=\"fun-fact-grids clearfix\">\r\n");
#nullable restore
#line 19 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                                 foreach (var item in Model.FunFacts.Where(f => f.Status))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"grid\">\r\n                                        <div class=\"info\">\r\n                                            <i");
            BeginWriteAttribute("class", " class=\"", 1074, "\"", 1092, 1);
#nullable restore
#line 23 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
WriteAttributeValue("", 1082, item.Icon, 1082, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                            <h3><span class=\"odometer\" data-count=\"");
#nullable restore
#line 24 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                                                                              Write(item.Numbs);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">00</span></h3>\r\n                                            <p>");
#nullable restore
#line 25 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                                          Write(item.FFDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 28 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"right-col\">\r\n                        <div class=\"about-info\">\r\n                            <h3>");
#nullable restore
#line 34 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p>");
#nullable restore
#line 35 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                          Write(Model.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <a href=\"#\" class=\"theme-btn\">");
#nullable restore
#line 36 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
                                                     Write(Model.ActionText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n                        <div class=\"img-holder\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1896, "\"", 1943, 1);
#nullable restore
#line 39 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\AboutSection\Default.cshtml"
WriteAttributeValue("", 1902, _cloudinaryService.BuildUrl(Model.Image), 1902, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div> <!-- end container -->\r\n</section>\r\n<!-- end about-section -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutCompanyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
