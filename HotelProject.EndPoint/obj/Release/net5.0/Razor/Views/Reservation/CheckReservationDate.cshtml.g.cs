#pragma checksum "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\CheckReservationDate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec4dab76ee8256839caf2a382ff050a2cf51aeb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_CheckReservationDate), @"mvc.1.0.view", @"/Views/Reservation/CheckReservationDate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4dab76ee8256839caf2a382ff050a2cf51aeb9", @"/Views/Reservation/CheckReservationDate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66edff28891947985e79b69e01e9d4763a434bd0", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservation_CheckReservationDate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\CheckReservationDate.cshtml"
  
    ViewData["Title"] = "CheckReservationDate";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""formm-date"" style=""margin: 30px; margin-bottom: 100px;"">
    <h4 style=""margin-bottom: 50px; padding-bottom: 10px; border-bottom: 2px solid red;"">?????????? ???????? ?? ?????????? ???????? ???? ???????? ????????</h4>
    <div style=""margin-bottom: 20px;"">
        <div class=""row"">
            <div class='col-sm-6'>
                <div class=""form-group"">
                    <div class='input-group date' id='datetimepicker3'>
                        <label for=""startTime"">?????????? ???????? : </label>
                        <input type='date' class=""form-control"" id=""startTime"" style=""margin-bottom: 20px;"">
                        <br />
                        <label for=""endTime"">?????????? ?????????? : </label>
                        <input type='date' class=""form-control"" id=""endTime""/>
                    </div>
                </div>
            </div>
            <script type=""text/javascript"">
                $(function () {
                    $('#datetimepicker3').datetimepicker({
                        format: 'LT'
             ");
            WriteLiteral("       });\n                });\n            </script>\n        </div>\n    </div>\n    <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1214, "\"", 1248, 3);
            WriteAttributeValue("", 1224, "DateCheck(\'", 1224, 11, true);
#nullable restore
#line 31 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\CheckReservationDate.cshtml"
WriteAttributeValue("", 1235, ViewBag.Id, 1235, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1246, "\')", 1246, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">?????????? ??????????</button>\n</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
   <script>
       function DateCheck(Id) {
           var Id = Id;
           var startDate = $('#startTime').val();
           var endDate = $('#endTime').val();
           var data = {
               'Id': Id,
               'startTime': startDate,
               'endTime': endDate
           };
           $.ajax({
               contentType: 'application/x-www-form-urlencoded',
               dataType: 'json',
               type: ""POST"",
               url: ""CheckReservationDate"",
               data: data,
               success: function (data) {
                   if (data.isSuccess == true) {
                       alert(data.message);
                       window.location.replace(""/Reservation/GetInfo/?Id="" + '");
#nullable restore
#line 54 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\CheckReservationDate.cshtml"
                                                                         Write(ViewBag.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' + ""&startTime="" + startDate + ""&endTime="" + endDate);
                   }
                   else {
                       alert(data.message);
                   }
               },
               error: function (request, status, error) {
                   alert(""Error"");
               }
           });
       }
   </script>
");
            }
            );
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
