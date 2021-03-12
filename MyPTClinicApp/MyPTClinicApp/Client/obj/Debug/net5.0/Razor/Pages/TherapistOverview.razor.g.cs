#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59e071b32c39b32915dfdbc1626a64bf527dab56"
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
#line 1 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/therapistoverview")]
    public partial class TherapistOverview : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 class=\"page-title\">All Therapists</h1>\r\n\r\n<br>");
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
 if (Therapists == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Retrieving therapist information, it will just take a moment...</em></p>");
#nullable restore
#line 10 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
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
            __builder.AddAttribute(8, "placeholder", "Search by therapist\'s first name");
            __builder.AddAttribute(9, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
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
#line 16 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
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
#line 17 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
                                                              ClearSearch

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(22, "Clear Search");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n    ");
            __builder.OpenElement(24, "div");
            __builder.AddContent(25, 
#nullable restore
#line 20 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
          errormessage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "<br>");
            __builder.OpenElement(27, "table");
            __builder.AddAttribute(28, "class", "table table-hover table-striped");
            __builder.AddMarkupContent(29, "<thead><tr><th>ID</th>\r\n                <th>First name</th>\r\n                <th>Last name</th>\r\n                <th>View</th>\r\n                <th>Edit</th></tr></thead>\r\n        ");
            __builder.OpenElement(30, "tbody");
#nullable restore
#line 35 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
             foreach (var therapist in Therapists)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(31, "tr");
            __builder.OpenElement(32, "td");
            __builder.AddContent(33, 
#nullable restore
#line 38 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
                         therapist.ID

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n                    ");
            __builder.OpenElement(35, "td");
            __builder.AddContent(36, 
#nullable restore
#line 39 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
                         therapist.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                    ");
            __builder.OpenElement(38, "td");
            __builder.AddContent(39, 
#nullable restore
#line 40 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
                         therapist.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                    ");
            __builder.OpenElement(41, "td");
            __builder.OpenElement(42, "a");
            __builder.AddAttribute(43, "href", 
#nullable restore
#line 42 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
                                   $"therapistdetail/{therapist.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(44, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(45, "<i class=\"fas fa-info-circle\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n                    ");
            __builder.OpenElement(47, "td");
            __builder.OpenElement(48, "a");
            __builder.AddAttribute(49, "href", 
#nullable restore
#line 47 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
                                   $"therapistedit/{therapist.ID}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(50, "class", "btn btn-primary table-btn");
            __builder.AddMarkupContent(51, "<i class=\"fas fa-edit\"></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 52 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 55 "C:\MyPTClinicApp\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistOverview.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
