#pragma checksum "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd10abcdd4d7a9ff8db2742c23a1c0c7aa4eb1a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_GetComments_GetComments), @"mvc.1.0.view", @"/Views/Shared/Components/GetComments/GetComments.cshtml")]
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
#line 1 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\_ViewImports.cshtml"
using HotelProject.EndPoint;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\_ViewImports.cshtml"
using HotelProject.EndPoint.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
using HotelProject.Application.Services.Comments.Query;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd10abcdd4d7a9ff8db2742c23a1c0c7aa4eb1a8", @"/Views/Shared/Components/GetComments/GetComments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66edff28891947985e79b69e01e9d4763a434bd0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_GetComments_GetComments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GetCommentResultDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>نظرات کاربران (");
#nullable restore
#line 6 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
              Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" نظر)</h3>\n<br />\n<br />\n");
#nullable restore
#line 9 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"border-bottom: 1px dotted red; padding: 40px;\">\n        <div style=\"margin-bottom: 65px;\">\n            <div class=\"col-md-3 comment\" style=\"color: gray\">\n                <h4>");
#nullable restore
#line 14 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n            </div>\n            <div class=\"col-md-3 comment\" style=\"color: gray\">\n                <h4>");
#nullable restore
#line 17 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
               Write(item.InsertTime.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 17 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
                                      Write(item.InsertTime.Month);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 17 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
                                                               Write(item.InsertTime.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n            </div>\n        </div>\n        <div class=\"clearfix\"> </div>\n        <p>\n            ");
#nullable restore
#line 22 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
       Write(item.CommentTxt);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </p>\n    </div>\n");
#nullable restore
#line 25 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Shared\Components\GetComments\GetComments.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GetCommentResultDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591