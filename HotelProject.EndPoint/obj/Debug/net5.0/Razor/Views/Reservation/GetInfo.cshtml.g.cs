#pragma checksum "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "859511debc4574ac489afbfd3bb1d93487f3c495"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_GetInfo), @"mvc.1.0.view", @"/Views/Reservation/GetInfo.cshtml")]
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
#line 1 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
using HotelProject.Application.Services.Users.Query.GetUserDetails;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"859511debc4574ac489afbfd3bb1d93487f3c495", @"/Views/Reservation/GetInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66edff28891947985e79b69e01e9d4763a434bd0", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservation_GetInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultGetDetails_DTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frm-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-bottom: 1px solid gray; margin-bottom: 10px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
  
    ViewData["Title"] = "GetInfo";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .withPersons {
        margin-bottom: 20px;
    }
</style>

<div class=""formm-date"" style=""margin: 30px; margin-bottom: 100px;"">
    <h4 style=""margin-bottom: 50px; padding-bottom: 10px; border-bottom: 2px solid red;"">مشخصات رزرو (در صورت مغایرت پروفایل خود را اصلاح کنید)</h4>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "859511debc4574ac489afbfd3bb1d93487f3c4954907", async() => {
                WriteLiteral(@"
        <div class=""readOnlyInputs"" style=""display: flex; justify-content: space-around; align-items: center;"">
            <div class=""column1"">
                <label for=""RoomCode"">کد اتاق : </label>
                <input type=""text"" class=""form-control"" readonly id=""RoomCode""");
                BeginWriteAttribute("value", " value=\"", 858, "\"", 877, 1);
#nullable restore
#line 19 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 866, Model.Code, 866, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 300px !important; margin-bottom: 10px;\" />\r\n\r\n                <label for=\"RoomName\">نام اتاق : </label>\r\n                <input type=\"text\" class=\"form-control\" readonly id=\"RoomName\"");
                BeginWriteAttribute("value", " value=\"", 1076, "\"", 1099, 1);
#nullable restore
#line 22 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 1084, Model.RoomName, 1084, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 300px !important; margin-bottom: 10px;\" />\r\n\r\n                <label for=\"Name\">نام : </label>\r\n                <input type=\"text\" class=\"form-control\" readonly id=\"Name\"");
                BeginWriteAttribute("value", " value=\"", 1285, "\"", 1308, 1);
#nullable restore
#line 25 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 1293, Model.UserName, 1293, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 300px !important; margin-bottom: 10px;\" />\r\n\r\n                <label for=\"Email\">ایمیل : </label>\r\n                <input type=\"text\" class=\"form-control\" readonly id=\"Email\"");
                BeginWriteAttribute("value", " value=\"", 1498, "\"", 1518, 1);
#nullable restore
#line 28 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 1506, Model.Email, 1506, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 300px !important; margin-bottom: 10px;\" />\r\n            </div>\r\n            <div class=\"column2\">\r\n                <label for=\"Phone\">تلفن ثابت : </label>\r\n                <input type=\"text\" class=\"form-control\" readonly id=\"Phone\"");
                BeginWriteAttribute("value", " value=\"", 1765, "\"", 1785, 1);
#nullable restore
#line 32 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 1773, Model.Phone, 1773, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 300px !important; margin-bottom: 10px;;\" />\r\n\r\n                <label for=\"Mobile\">تلفن همراه : </label>\r\n                <input type=\"text\" class=\"form-control\" readonly id=\"Mobile\"");
                BeginWriteAttribute("value", " value=\"", 1983, "\"", 2004, 1);
#nullable restore
#line 35 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 1991, Model.Mobile, 1991, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 300px !important; margin-bottom: 10px;\" />\r\n\r\n                <label for=\"startDate\">تاریخ شروع رزرو : </label>\r\n                <input type=\"text\" class=\"form-control\" readonly id=\"startDate\"");
                BeginWriteAttribute("value", " value=\"", 2212, "\"", 2238, 1);
#nullable restore
#line 38 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 2220, ViewBag.StartTime, 2220, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 300px !important; margin-bottom: 10px;\" />\r\n\r\n                <label for=\"endDate\">تارخ پایان رزرو : </label>\r\n                <input type=\"text\" class=\"form-control\" readonly id=\"endDate\"");
                BeginWriteAttribute("value", " value=\"", 2442, "\"", 2466, 1);
#nullable restore
#line 41 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 2450, ViewBag.EndTime, 2450, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""width: 300px !important; margin-bottom: 10px;"" />
            </div>
        </div>
        <h4 style=""margin-top: 15px;"">اطلاعات زیر را وارد کنید</h4>
        <div class=""fillInputs"" style=""padding-top: 10px; margin-bottom: 30px; border-top: 2px solid red;"">
            <span for=""startDate"">آدرس : </span>
            <input class=""form-control"" type=""text"" id=""address""");
                BeginWriteAttribute("value", " value=\"", 2854, "\"", 2862, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 500px !important; margin-bottom: 10px;\" />\r\n            <span for=\"endDate\">تعداد افراد همراه : </span>\r\n            <input class=\"form-control\" type=\"number\" id=\"withNumbers\"");
                BeginWriteAttribute("value", " value=\"", 3053, "\"", 3061, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 500px !important; margin-bottom: 10px;\" />\r\n            <input type=\"button\" id=\"addPerson\" class=\"btn btn-warning\" value=\"افزودن فرد همراه\" />\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <a class=\"btn btn-success\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3281, "\"", 3343, 6);
            WriteAttributeValue("", 3291, "ConfirmReservation(\'", 3291, 20, true);
#nullable restore
#line 53 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 3311, Model.UserId, 3311, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3324, "\',", 3324, 2, true);
            WriteAttributeValue(" ", 3326, "\'", 3327, 2, true);
#nullable restore
#line 53 "C:\CsharpProjects\Hotel_Project\HotelRoom-master\HotelProject.EndPoint\Views\Reservation\GetInfo.cshtml"
WriteAttributeValue("", 3328, Model.RoomId, 3328, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3341, "\')", 3341, 2, true);
            EndWriteAttribute();
            WriteLiteral(">ثبت</a>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
   <script>
       //----- display add persons inputs ---------
       $(""#addPerson"").on('click', function () {
           $(""#frm-info"").append(
               '<div class=""withPersons"" id=""divWith"">'+
                   '<div class=""fillInputs"" style=""padding-top: 10px; border-top: 2px solid red;"">'+
                      '<span for=""startDate"">نام : </span>'+
                      '<input class=""form-control withNames"" type=""text"" id=""withName"" value="""" style=""width: 500px !important; margin-bottom: 10px;"" />'+
                      '<span for=""endDate"">  تلفن همراه : </span>'+
                      '<input class=""form-control withPhones"" type=""number"" id=""withPhone"" value="""" style=""width: 500px !important; margin-bottom: 10px;"" />'+
                   '</div>'+
                   '<input type=""button"" class=""btn btn-danger remove"" value=""حذف"" />'+
               '</div>' 
           );
       });
       $(""#frm-info"").on('click', '.remove', function () {
           $(this).closest('.wi");
                WriteLiteral(@"thPersons').remove();
       });
       //-----------------------------------------
       //------------ post data ------------------
       function ConfirmReservation(UserId, RoomId) {
           var UserId = UserId;
           var RoomId = RoomId;
           var UserName = $('#Name').val();
           var StartTime = $('#startDate').val();
           var EndTime = $('#endDate').val();
           var Mobile = $('#Mobile').val();
           var UserPhone = $('#Phone').val();
           var Address = $('#address').val();
           var WithPersonsCount = $('#withNumbers').val();
           //persons info
           var dataPersonModel = $(""#frm-info .withPersons"").map(function () {
               return {
                   Name: $(this.getElementsByClassName('withNames')).val(),
                   Phone: $(this.getElementsByClassName('withPhones')).val(),
               };
           }).get();

           dataPerson = $.each(dataPersonModel, function (val) {
               Name = val.");
                WriteLiteral(@"Name;
               Phone = val.Phone;
           });
           WithPersons = dataPerson;
           //------
           var data = {
               'UserId': UserId,
               'RoomId': RoomId,
               'UserName': UserName,
               'StartTime': StartTime,
               'EndTime': EndTime,
               'Mobile': Mobile,
               'UserPhone': UserPhone,
               'Address': Address,
               'WithPersonsCount': WithPersonsCount,
               'WithPersons': WithPersons,
           };

           $.ajax({
               contentType: 'application/x-www-form-urlencoded',
               dataType: 'json',
               type: ""POST"",
               url: ""GetInfo"",
               data: data,
               success: function (data) {
                   if (data.isSuccess == true) {
                       alert(data.message);
                       window.location.replace(""/Profile/Index"");
                   }
                   else {
          ");
                WriteLiteral("             alert(data.message);\r\n                   }\r\n               },\r\n               error: function (request, status, error) {\r\n                   alert(\"Error\");\r\n               }\r\n           });\r\n       }\r\n   </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultGetDetails_DTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
