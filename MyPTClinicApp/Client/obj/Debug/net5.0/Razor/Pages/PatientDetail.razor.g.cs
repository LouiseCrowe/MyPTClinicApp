#pragma checksum "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e71f4a27bfd5021761c7e0b759d30b4c7700644"
// <auto-generated/>
#pragma warning disable 1591
namespace MyPTClinicApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Telerik.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\_Imports.razor"
using Telerik.Blazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/patientdetail/{ID}")]
    public partial class PatientDetail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 6 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
 if (Patient == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Retrieving patient information, it will just take a moment...</em></p>");
#nullable restore
#line 9 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "h1");
            __builder.AddAttribute(2, "class", "page-title");
            __builder.AddContent(3, "Patient details: ");
            __builder.AddContent(4, 
#nullable restore
#line 12 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                             Patient.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(5, " ");
            __builder.AddContent(6, 
#nullable restore
#line 12 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                Patient.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "<br>");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "form-group row");
            __builder.AddMarkupContent(10, "<label class=\"col-6 col-sm-2 col-form-label\">Patient Name: </label>\r\n        ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "col");
            __builder.OpenElement(13, "label");
            __builder.AddAttribute(14, "type", "text");
            __builder.AddAttribute(15, "readonly");
            __builder.AddAttribute(16, "class", "form-control-plaintext");
            __builder.AddContent(17, 
#nullable restore
#line 19 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                        Patient.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(18, " ");
            __builder.AddContent(19, 
#nullable restore
#line 19 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                                           Patient.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "form-group row");
            __builder.AddMarkupContent(23, "<label class=\"col-6 col-sm-2 col-form-label\">Phone: </label>\r\n        ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "col");
            __builder.OpenElement(26, "label");
            __builder.AddAttribute(27, "type", "text");
            __builder.AddAttribute(28, "readonly");
            __builder.AddAttribute(29, "class", "form-control-plaintext");
            __builder.AddContent(30, 
#nullable restore
#line 25 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                        Patient.Phone

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n    ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "form-group row");
            __builder.AddMarkupContent(34, "<label class=\"col-6 col-sm-2 col-form-label\">Email: </label>\r\n        ");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "col");
            __builder.OpenElement(37, "label");
            __builder.AddAttribute(38, "type", "text");
            __builder.AddAttribute(39, "readonly");
            __builder.AddAttribute(40, "class", "form-control-plaintext");
            __builder.AddContent(41, 
#nullable restore
#line 31 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                        Patient.Email

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n    ");
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "class", "form-group row");
            __builder.AddMarkupContent(45, "<label class=\"col-6 col-sm-2 col-form-label\">Address: </label>\r\n        ");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "col");
            __builder.OpenElement(48, "label");
            __builder.AddAttribute(49, "type", "text");
            __builder.AddAttribute(50, "readonly");
            __builder.AddAttribute(51, "class", "form-control-plaintext");
            __builder.AddContent(52, 
#nullable restore
#line 37 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                        Patient.Address

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n    ");
            __builder.OpenElement(54, "div");
            __builder.AddAttribute(55, "class", "form-group row");
            __builder.AddMarkupContent(56, "<label class=\"col-6 col-sm-2 col-form-label\">Date of Birth: </label>\r\n        ");
            __builder.OpenElement(57, "div");
            __builder.AddAttribute(58, "class", "col");
            __builder.OpenElement(59, "label");
            __builder.AddAttribute(60, "type", "text");
            __builder.AddAttribute(61, "readonly");
            __builder.AddAttribute(62, "class", "form-control-plaintext");
            __builder.AddContent(63, 
#nullable restore
#line 44 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                 Patient.DateOfBirth.Day

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(64, "/");
            __builder.AddContent(65, 
#nullable restore
#line 44 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                          Patient.DateOfBirth.Month

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(66, "/");
            __builder.AddContent(67, 
#nullable restore
#line 44 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                     Patient.DateOfBirth.Year

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n    ");
            __builder.OpenElement(69, "div");
            __builder.AddAttribute(70, "class", "form-group row");
            __builder.AddMarkupContent(71, "<label class=\"col-6 col-sm-2 col-form-label\">Medications: </label>\r\n        ");
            __builder.OpenElement(72, "div");
            __builder.AddAttribute(73, "class", "col");
            __builder.OpenElement(74, "label");
            __builder.AddAttribute(75, "type", "text");
            __builder.AddAttribute(76, "readonly");
            __builder.AddAttribute(77, "class", "form-control-plaintext");
            __builder.AddContent(78, 
#nullable restore
#line 51 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                        Patient.Medications

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n    ");
            __builder.OpenElement(80, "div");
            __builder.AddAttribute(81, "class", "form-group row");
            __builder.AddMarkupContent(82, "<label class=\"col-6 col-sm-2 col-form-label\">Gender: </label>\r\n        ");
            __builder.OpenElement(83, "div");
            __builder.AddAttribute(84, "class", "col");
            __builder.OpenElement(85, "label");
            __builder.AddAttribute(86, "type", "text");
            __builder.AddAttribute(87, "readonly");
            __builder.AddAttribute(88, "class", "form-control-plaintext");
            __builder.AddContent(89, 
#nullable restore
#line 57 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                        Patient.Gender

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\r\n    ");
            __builder.OpenElement(91, "div");
            __builder.AddAttribute(92, "class", "form-group row");
            __builder.AddMarkupContent(93, "<label class=\"col-6 col-sm-2 col-form-label\">Therapist Name: </label>\r\n        ");
            __builder.OpenElement(94, "div");
            __builder.AddAttribute(95, "class", "col");
            __builder.OpenElement(96, "label");
            __builder.AddAttribute(97, "type", "text");
            __builder.AddAttribute(98, "readonly");
            __builder.AddAttribute(99, "class", "form-control-plaintext");
            __builder.AddContent(100, 
#nullable restore
#line 63 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                        Therapist.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(101, " ");
            __builder.AddContent(102, 
#nullable restore
#line 63 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                                                             Therapist.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.OpenElement(103, "h2");
            __builder.AddContent(104, 
#nullable restore
#line 67 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
         Patient.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(105, " ");
            __builder.AddContent(106, 
#nullable restore
#line 67 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                            Patient.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(107, "\'s Treatment History");
            __builder.CloseElement();
#nullable restore
#line 69 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
     if (!Treatments.Any())
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(108, "p");
            __builder.AddContent(109, 
#nullable restore
#line 71 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
            Patient.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(110, " ");
            __builder.AddContent(111, 
#nullable restore
#line 71 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                               Patient.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(112, " has not received any treatments");
            __builder.CloseElement();
#nullable restore
#line 72 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
    }
    else 
    { 

#line default
#line hidden
#nullable disable
            __builder.OpenElement(113, "table");
            __builder.AddAttribute(114, "class", "table table-hover table-striped");
            __builder.AddMarkupContent(115, "<thead><tr><th>ID</th>\r\n                <th>Date</th>\r\n                <th>Notes</th></tr></thead>\r\n        ");
            __builder.OpenElement(116, "tbody");
#nullable restore
#line 84 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
             foreach (var treatment in Treatments)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(117, "tr");
            __builder.OpenElement(118, "td");
            __builder.AddContent(119, 
#nullable restore
#line 87 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                     treatment.ID

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(120, "\r\n                ");
            __builder.OpenElement(121, "td");
            __builder.AddContent(122, 
#nullable restore
#line 88 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                     treatment.Date.Day

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(123, "/");
            __builder.AddContent(124, 
#nullable restore
#line 88 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                         treatment.Date.Month

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(125, "/");
            __builder.AddContent(126, 
#nullable restore
#line 88 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                               treatment.Date.Year

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(127, "\r\n                ");
            __builder.OpenElement(128, "td");
            __builder.AddContent(129, 
#nullable restore
#line 89 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                     treatment.Notes

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(130, "\r\n                ");
            __builder.OpenElement(131, "td");
            __builder.OpenElement(132, "a");
            __builder.AddAttribute(133, "href", 
#nullable restore
#line 91 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                               $"treatmentdetail/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(134, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(135, "<i class=\"fas fa-info-circle\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(136, "\r\n                ");
            __builder.OpenElement(137, "td");
            __builder.OpenElement(138, "a");
            __builder.AddAttribute(139, "href", 
#nullable restore
#line 96 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                               $"treatmentedit/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(140, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(141, "<i class=\"fas fa-edit\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 101 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
           }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 104 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
     
}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(142, "div");
            __builder.OpenElement(143, "a");
            __builder.AddAttribute(144, "class", "btn btn-outline-primary");
            __builder.AddAttribute(145, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 108 "C:\01 MyPTClinicAppHookedUpToDatabase\MyPTClinicApp\Client\Pages\PatientDetail.razor"
                                                  NavigateToOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(146, "Back to patient list");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
