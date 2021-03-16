#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f93eda79142e981909027fcfd3db82b0981f42e1"
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
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table table-hover table-striped");
            __builder.AddMarkupContent(4, "<thead><tr><th>ID</th>\r\n                <th>Patient</th>\r\n                <th>Therapist</th>\r\n                <th>Date</th>\r\n                <th>Notes</th>\r\n                <th></th>\r\n                <th></th></tr></thead>\r\n        ");
            __builder.OpenElement(5, "tbody");
#nullable restore
#line 26 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
             foreach (var treatment in Treatments)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "tr");
            __builder.OpenElement(7, "td");
            __builder.AddContent(8, 
#nullable restore
#line 29 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                     treatment.ID

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "    \r\n                ");
            __builder.OpenElement(10, "td");
            __builder.AddContent(11, 
#nullable restore
#line 30 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                     treatment.PatientFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(12, " ");
            __builder.AddContent(13, 
#nullable restore
#line 30 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                 treatment.PatientLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                ");
            __builder.OpenElement(15, "td");
            __builder.AddContent(16, 
#nullable restore
#line 31 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                     treatment.TherapistFirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(17, " ");
            __builder.AddContent(18, 
#nullable restore
#line 31 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                   treatment.TherapistLastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n                ");
            __builder.OpenElement(20, "td");
            __builder.AddContent(21, 
#nullable restore
#line 32 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                     treatment.Date.Day

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(22, "/");
            __builder.AddContent(23, 
#nullable restore
#line 32 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                         treatment.Date.Month

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(24, "/");
            __builder.AddContent(25, 
#nullable restore
#line 32 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                                                               treatment.Date.Year

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "td");
            __builder.AddContent(28, 
#nullable restore
#line 33 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                     treatment.Notes

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenElement(30, "td");
            __builder.OpenElement(31, "a");
            __builder.AddAttribute(32, "href", 
#nullable restore
#line 35 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                               $"treatmentdetail/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(33, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(34, "<i class=\"fas fa-info-circle\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n                ");
            __builder.OpenElement(36, "td");
            __builder.OpenElement(37, "a");
            __builder.AddAttribute(38, "href", 
#nullable restore
#line 40 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                               $"treatmentedit/{treatment.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(39, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(40, "<i class=\"fas fa-edit\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 44 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
                 }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 47 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentOverview.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
