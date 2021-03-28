#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea3107c68c938eaca51312f57672521b147d3f4d"
// <auto-generated/>
#pragma warning disable 1591
namespace MyPTClinicApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Telerik.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Telerik.Blazor.Components;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/treatmentoverview")]
    public partial class TreatmentOverview : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 class=\"page-title\">All Treatments</h1>\r\n\r\n<br>");
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
 if (Treatments == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Retrieving treatment information, it will just take a moment...</em></p>");
#nullable restore
#line 10 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "input-group");
            __builder.OpenElement(4, "input");
            __builder.AddAttribute(5, "class", "form-control");
            __builder.AddAttribute(6, "input");
            __builder.AddAttribute(7, "type", "text");
            __builder.AddAttribute(8, "placeholder", "Search by therapist\'s or patient\'s first, last or full name");
            __builder.AddAttribute(9, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 15 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                            SearchName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => SearchName = __value, SearchName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "input-group-append");
            __builder.OpenElement(14, "button");
            __builder.AddAttribute(15, "class", "btn btn-primary");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                      Search

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(17, "Search");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n            ");
            __builder.OpenElement(19, "button");
            __builder.AddAttribute(20, "class", "btn btn-outline-primary");
            __builder.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                              ClearSearch

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(22, "Clear Search");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "<br>");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "input-group input-daterange");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "input-group-prepend");
            __builder.AddMarkupContent(28, "<span class=\"input-group-text\" id=\"basic-addon1\">Date Range From:</span>\r\n            ");
            __builder.OpenElement(29, "input");
            __builder.AddAttribute(30, "class", "form-control");
            __builder.AddAttribute(31, "input");
            __builder.AddAttribute(32, "type", "date");
            __builder.AddAttribute(33, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 27 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                                     FromDate

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(34, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => FromDate = __value, FromDate, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n        ");
            __builder.OpenElement(36, "div");
            __builder.AddAttribute(37, "class", "input-group-prepend");
            __builder.AddMarkupContent(38, "<span class=\"input-group-text\" id=\"basic-addon1\">Date Range To:</span>\r\n            ");
            __builder.OpenElement(39, "input");
            __builder.AddAttribute(40, "class", "form-control");
            __builder.AddAttribute(41, "input");
            __builder.AddAttribute(42, "type", "date");
            __builder.AddAttribute(43, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 31 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                                     ToDate

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(44, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => ToDate = __value, ToDate, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n        ");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "input-group-append");
            __builder.OpenElement(48, "button");
            __builder.AddAttribute(49, "class", "btn btn-primary");
            __builder.AddAttribute(50, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 34 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                      Search

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(51, "Search");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n            ");
            __builder.OpenElement(53, "button");
            __builder.AddAttribute(54, "class", "btn btn-outline-primary");
            __builder.AddAttribute(55, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                              ResetDates

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(56, "Reset Dates");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "<br>\r\n    ");
            __builder.OpenElement(58, "div");
            __builder.OpenElement(59, "b");
            __builder.AddAttribute(60, "class", "alert-warning");
            __builder.AddContent(61, 
#nullable restore
#line 40 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   errormessage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n    <br>");
#nullable restore
#line 43 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
     if (!showSummary)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(63, "button");
            __builder.AddAttribute(64, "class", "btn btn-primary");
            __builder.AddAttribute(65, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 45 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                  ShowSummary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(66, "Show Breakdown of Treatments by Patient and Therapist");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n        <br>");
#nullable restore
#line 47 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
     if (showSummary)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(68, "button");
            __builder.AddAttribute(69, "class", "btn btn-primary");
            __builder.AddAttribute(70, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 50 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                  HideSummary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(71, "Hide Breakdown of Treatments by Patient and Therapist");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n        <br>\r\n        <br>");
            __builder.AddMarkupContent(73, "<h4>Summary info for Treatments</h4>");
            __builder.OpenElement(74, "p");
            __builder.AddContent(75, "Total number of treatments: ");
            __builder.AddContent(76, 
#nullable restore
#line 56 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                        totalTreatments

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n        ");
            __builder.OpenElement(78, "p");
            __builder.AddContent(79, "Total number of treatments meeting search criteria: ");
            __builder.AddContent(80, 
#nullable restore
#line 57 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                                Treatments.Count()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "<h4>Breakdown of Treatments by Patient</h4>");
            __builder.OpenElement(82, "table");
            __builder.AddAttribute(83, "class", "table");
            __builder.AddMarkupContent(84, "<thead><tr><th>Patient</th>\r\n                    <th>Number of Treatments</th>\r\n                    <th></th>\r\n                    <th></th></tr></thead>\r\n            ");
            __builder.OpenElement(85, "tbody");
#nullable restore
#line 71 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                 foreach (var patientGroup in PatientsWithTreatments)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(86, "tr");
            __builder.OpenElement(87, "td");
            __builder.AddContent(88, 
#nullable restore
#line 74 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         patientGroup[0].PatientFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(89, " ");
            __builder.AddContent(90, 
#nullable restore
#line 74 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                           patientGroup[0].PatientLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(91, "\r\n                    ");
            __builder.OpenElement(92, "td");
            __builder.AddContent(93, 
#nullable restore
#line 75 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         patientGroup.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n                    ");
            __builder.OpenElement(95, "td");
            __builder.OpenElement(96, "a");
            __builder.AddAttribute(97, "href", 
#nullable restore
#line 77 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"patientdetail/{patientGroup[0].PatientId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(98, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(99, "<i class=\"fas fa-info-circle\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n                    ");
            __builder.OpenElement(101, "td");
            __builder.OpenElement(102, "a");
            __builder.AddAttribute(103, "href", 
#nullable restore
#line 82 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"patientedit/{patientGroup[0].PatientId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(104, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(105, "<i class=\"fas fa-edit\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 87 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "<h4>Breakdown of Treatments by Therapist</h4>");
            __builder.OpenElement(107, "table");
            __builder.AddAttribute(108, "class", "table");
            __builder.AddMarkupContent(109, "<thead><tr><th>Therapist</th>\r\n                    <th>Number of Treatments</th>\r\n                    <th></th>\r\n                    <th></th></tr></thead>\r\n            ");
            __builder.OpenElement(110, "tbody");
#nullable restore
#line 103 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                 foreach (var therapistGroup in TherapistsWithTreatments)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(111, "tr");
            __builder.OpenElement(112, "td");
            __builder.AddContent(113, 
#nullable restore
#line 106 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         therapistGroup[0].TherapistFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(114, " ");
            __builder.AddContent(115, 
#nullable restore
#line 106 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                               therapistGroup[0].TherapistLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(116, "\r\n                    ");
            __builder.OpenElement(117, "td");
            __builder.AddContent(118, 
#nullable restore
#line 107 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         therapistGroup.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(119, "\r\n                    ");
            __builder.OpenElement(120, "td");
            __builder.OpenElement(121, "a");
            __builder.AddAttribute(122, "href", 
#nullable restore
#line 109 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"therapistdetail/{therapistGroup[0].TherapistId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(123, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(124, "<i class=\"fas fa-info-circle\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(125, "\r\n                    ");
            __builder.OpenElement(126, "td");
            __builder.OpenElement(127, "a");
            __builder.AddAttribute(128, "href", 
#nullable restore
#line 114 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"therapistedit/{therapistGroup[0].TherapistId}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(129, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(130, "<i class=\"fas fa-edit\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 119 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 122 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"


    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(131, "<br>");
            __builder.OpenElement(132, "table");
            __builder.AddAttribute(133, "class", "table table-hover table-striped");
            __builder.AddMarkupContent(134, "<thead><tr><th>Patient Name</th>\r\n                <th>Therapist Name</th>\r\n                <th>Date</th>\r\n                <th>Notes</th>\r\n                <th></th>\r\n                <th></th></tr></thead>\r\n        ");
            __builder.OpenElement(135, "tbody");
#nullable restore
#line 140 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
             foreach (var treatment in Treatments)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(136, "tr");
            __builder.OpenElement(137, "td");
            __builder.AddContent(138, 
#nullable restore
#line 143 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.PatientFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(139, " ");
            __builder.AddContent(140, 
#nullable restore
#line 143 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                     treatment.PatientLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n                    ");
            __builder.OpenElement(142, "td");
            __builder.AddContent(143, 
#nullable restore
#line 144 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.TherapistFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(144, " ");
            __builder.AddContent(145, 
#nullable restore
#line 144 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                       treatment.TherapistLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(146, "\r\n                    ");
            __builder.OpenElement(147, "td");
            __builder.AddContent(148, 
#nullable restore
#line 145 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.Date.Day

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(149, "/");
            __builder.AddContent(150, 
#nullable restore
#line 145 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                             treatment.Date.Month

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(151, "/");
            __builder.AddContent(152, 
#nullable restore
#line 145 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                                   treatment.Date.Year

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(153, "\r\n                    ");
            __builder.OpenElement(154, "td");
            __builder.AddContent(155, 
#nullable restore
#line 146 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.Notes

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(156, "\r\n                    ");
            __builder.OpenElement(157, "td");
            __builder.OpenElement(158, "a");
            __builder.AddAttribute(159, "href", 
#nullable restore
#line 148 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"treatmentdetail/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(160, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(161, "<i class=\"fas fa-info-circle\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(162, "\r\n                    ");
            __builder.OpenElement(163, "td");
            __builder.OpenElement(164, "a");
            __builder.AddAttribute(165, "href", 
#nullable restore
#line 153 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"treatmentedit/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(166, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(167, "<i class=\"fas fa-edit\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 158 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 161 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
