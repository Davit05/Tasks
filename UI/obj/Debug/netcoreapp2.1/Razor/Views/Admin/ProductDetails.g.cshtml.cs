#pragma checksum "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\Admin\ProductDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce445f3cffc79c65984d2536caf817aefbe24e4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ProductDetails), @"mvc.1.0.view", @"/Views/Admin/ProductDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ProductDetails.cshtml", typeof(AspNetCore.Views_Admin_ProductDetails))]
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
#line 1 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\_ViewImports.cshtml"
using DAL.Entities;

#line default
#line hidden
#line 2 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce445f3cffc79c65984d2536caf817aefbe24e4d", @"/Views/Admin/ProductDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bfb89f32a963047349bbda86bf4abe2f8aa299a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ProductDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.ProductDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 324, true);
            WriteLiteral(@"<h3 class=""text-center"">Details</h3>
<table class=""table-bordered col-md-12 text-center"">
    <thead class=""alert-danger align-self-stretch "">
        <tr><td>Mark</td><td>Model</td><td>Year</td><td>Vin</td><td>DateAdded</td><td>Owner</td></tr>
    </thead>
    <tbody>
        <tr>
            <td>
                ");
            EndContext();
            BeginContext(352, 10, false);
#line 10 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\Admin\ProductDetails.cshtml"
           Write(Model.Mark);

#line default
#line hidden
            EndContext();
            BeginContext(362, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(418, 14, false);
#line 13 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\Admin\ProductDetails.cshtml"
           Write(Model.CarModel);

#line default
#line hidden
            EndContext();
            BeginContext(432, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(488, 10, false);
#line 16 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\Admin\ProductDetails.cshtml"
           Write(Model.Year);

#line default
#line hidden
            EndContext();
            BeginContext(498, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(554, 9, false);
#line 19 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\Admin\ProductDetails.cshtml"
           Write(Model.Vin);

#line default
#line hidden
            EndContext();
            BeginContext(563, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(619, 15, false);
#line 22 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\Admin\ProductDetails.cshtml"
           Write(Model.DateAdded);

#line default
#line hidden
            EndContext();
            BeginContext(634, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(690, 11, false);
#line 25 "D:\C# Learning\Proper projects at home\FincaTaskCore\Finca Task\UI\Views\Admin\ProductDetails.cshtml"
           Write(Model.Owner);

#line default
#line hidden
            EndContext();
            BeginContext(701, 58, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.ProductDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
