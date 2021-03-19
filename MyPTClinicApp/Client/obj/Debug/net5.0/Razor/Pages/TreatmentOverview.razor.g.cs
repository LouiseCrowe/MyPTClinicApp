#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07c3a2b7cda12e6529d3cb4e4d4d9f56f5d599b5"
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
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Telerik.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
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
            __builder.OpenElement(59, "em");
            __builder.AddContent(60, 
#nullable restore
#line 40 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
              errormessage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 42 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
     if (!showSummary)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(61, "button");
            __builder.AddAttribute(62, "class", "btn btn-primary");
            __builder.AddAttribute(63, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 44 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                  ShowSummary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(64, "Show Breakdown of Treatments by Patient and Therapist");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n        <br>");
#nullable restore
#line 46 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
     if (showSummary)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(66, "button");
            __builder.AddAttribute(67, "class", "btn btn-primary");
            __builder.AddAttribute(68, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 49 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                  HideSummary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(69, "Hide Breakdown of Treatments by Patient and Therapist");
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n        <br>\r\n        <br>");
            __builder.AddMarkupContent(71, "<h4>Summary info for Treatments</h4>");
            __builder.OpenElement(72, "p");
            __builder.AddContent(73, "Total number of treatments meeting search criteria: ");
            __builder.AddContent(74, 
#nullable restore
#line 55 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                                Treatments.Count()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "<h4>Breakdown of Treatments by Patient</h4>");
            __builder.OpenElement(76, "table");
            __builder.AddAttribute(77, "class", "table");
            __builder.AddMarkupContent(78, "<thead><tr><th>Patient</th>\r\n                    <th>Number of Treatments</th></tr></thead>\r\n            ");
            __builder.OpenElement(79, "tbody");
#nullable restore
#line 67 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                 foreach (var patientGroup in PatientsWithTreatments)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(80, "tr");
            __builder.OpenElement(81, "td");
            __builder.AddContent(82, 
#nullable restore
#line 70 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                             patientGroup[0].PatientFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(83, " ");
            __builder.AddContent(84, 
#nullable restore
#line 70 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                               patientGroup[0].PatientLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n                        ");
            __builder.OpenElement(86, "td");
            __builder.AddContent(87, 
#nullable restore
#line 71 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                             patientGroup.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 73 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "<h4>Breakdown of Treatments by Therapist</h4>");
            __builder.OpenElement(89, "table");
            __builder.AddAttribute(90, "class", "table");
            __builder.AddMarkupContent(91, "<thead><tr><th>Therapist</th>\r\n                    <th>Number of Treatments</th></tr></thead>\r\n            ");
            __builder.OpenElement(92, "tbody");
#nullable restore
#line 87 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                 foreach (var therapistGroup in TherapistsWithTreatments)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(93, "tr");
            __builder.OpenElement(94, "td");
            __builder.AddContent(95, 
#nullable restore
#line 90 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                             therapistGroup[0].TherapistFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(96, " ");
            __builder.AddContent(97, 
#nullable restore
#line 90 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                                   therapistGroup[0].TherapistLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n                        ");
            __builder.OpenElement(99, "td");
            __builder.AddContent(100, 
#nullable restore
#line 91 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                             therapistGroup.Count

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 93 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 96 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"


    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(101, "<br>");
            __builder.OpenElement(102, "table");
            __builder.AddAttribute(103, "class", "table table-hover table-striped");
            __builder.AddMarkupContent(104, "<thead><tr><th>ID</th>\r\n                <th>Patient</th>\r\n                <th>Therapist</th>\r\n                <th>Date</th>\r\n                <th>Notes</th>\r\n                <th></th>\r\n                <th></th></tr></thead>\r\n        ");
            __builder.OpenElement(105, "tbody");
#nullable restore
#line 115 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
             foreach (var treatment in Treatments)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(106, "tr");
            __builder.OpenElement(107, "td");
            __builder.AddContent(108, 
#nullable restore
#line 118 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.ID

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(109, "\r\n                    ");
            __builder.OpenElement(110, "td");
            __builder.AddContent(111, 
#nullable restore
#line 119 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.PatientFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(112, " ");
            __builder.AddContent(113, 
#nullable restore
#line 119 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                     treatment.PatientLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n                    ");
            __builder.OpenElement(115, "td");
            __builder.AddContent(116, 
#nullable restore
#line 120 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.TherapistFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(117, " ");
            __builder.AddContent(118, 
#nullable restore
#line 120 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                       treatment.TherapistLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(119, "\r\n                    ");
            __builder.OpenElement(120, "td");
            __builder.AddContent(121, 
#nullable restore
#line 121 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.Date.Day

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(122, "/");
            __builder.AddContent(123, 
#nullable restore
#line 121 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                             treatment.Date.Month

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(124, "/");
            __builder.AddContent(125, 
#nullable restore
#line 121 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                                   treatment.Date.Year

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(126, "\r\n                    ");
            __builder.OpenElement(127, "td");
            __builder.AddContent(128, 
#nullable restore
#line 122 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                         treatment.Notes

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(129, "\r\n                    ");
            __builder.OpenElement(130, "td");
            __builder.OpenElement(131, "a");
            __builder.AddAttribute(132, "href", 
#nullable restore
#line 124 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"treatmentdetail/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(133, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(134, "<i class=\"fas fa-info-circle\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(135, "\r\n                    ");
            __builder.OpenElement(136, "td");
            __builder.OpenElement(137, "a");
            __builder.AddAttribute(138, "href", 
#nullable restore
#line 129 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                   $"treatmentedit/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(139, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(140, "<i class=\"fas fa-edit\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 134 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 137 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
