#pragma checksum "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Testimonial\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cce1b1784a4562ac1f0c8753bce40a5cb7847eb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Testimonial_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Testimonial/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cce1b1784a4562ac1f0c8753bce40a5cb7847eb0", @"/Views/Shared/Components/Testimonial/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10ad6b889c74b9509d13053ebde6c94694e5d326", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Testimonial_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TestimonialViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<!-- start testimonials-section-s2 -->
<section class=""testimonials-section-s2 section-padding"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-4"">
                <div class=""section-title"">
                    <span>Testimonials</span>
                </div>

                <div class=""testimonials-s2-nav"">
                    <div class=""slider-s2-arrows"">
                        <div class=""slider-prev""><i class=""fi flaticon-left-arrow-angle-big-gross-symbol""></i></div>
                        <div class=""slider-next""><i class=""fi flaticon-arrow-angle-pointing-to-right""></i></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-8"">
                <div class=""testimonials-slider-holder"">
                    <div class=""testimonials-slider-s2"">
");
#nullable restore
#line 23 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Testimonial\Default.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"testimonials-slider-item\">\r\n                                <div class=\"grid\">\r\n                                    <p>");
#nullable restore
#line 27 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Testimonial\Default.cshtml"
                                  Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <div class=\"quoter\">\r\n                                        <h4>");
#nullable restore
#line 29 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Testimonial\Default.cshtml"
                                       Write(item.WriterName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                        <span>");
#nullable restore
#line 30 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Testimonial\Default.cshtml"
                                         Write(item.WriterDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 34 "C:\Users\DostTech\source\repos\Jotex\Jotex\Views\Shared\Components\Testimonial\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""testimonials-slider-item"">
                            <div class=""grid"">
                                <p>Recently cut out of an illustrated magazine and housed in a nice, gilded frame. It showed a lady fitted out with a fur hat and fur boa who sat upright, raising a heavy fur muff that covered the whole of her lower arm towards the viewer</p>
                                <div class=""quoter"">
                                    <h4>Mr. Bang</h4>
                                    <span>Life insurance holder</span>
                                </div>
                            </div>
                        </div>
                        <div class=""testimonials-slider-item"">
                            <div class=""grid"">
                                <p>Recently cut out of an illustrated magazine and housed in a nice, gilded frame. It showed a lady fitted out with a fur hat and fur boa who sat upright, raising a heavy fur muff that covered the whole ");
            WriteLiteral(@"of her lower arm towards the viewer</p>
                                <div class=""quoter"">
                                    <h4>Mr. Bang</h4>
                                    <span>Life insurance holder</span>
                                </div>
                            </div>
                        </div>
                        <div class=""testimonials-slider-item"">
                            <div class=""grid"">
                                <p>Recently cut out of an illustrated magazine and housed in a nice, gilded frame. It showed a lady fitted out with a fur hat and fur boa who sat upright, raising a heavy fur muff that covered the whole of her lower arm towards the viewer</p>
                                <div class=""quoter"">
                                    <h4>Mr. Bang</h4>
                                    <span>Life insurance holder</span>
                                </div>
                            </div>
                        </div>
                 ");
            WriteLiteral("   </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div> <!-- end container -->\r\n</section>\r\n<!-- end testimonials-section-s2 -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TestimonialViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591