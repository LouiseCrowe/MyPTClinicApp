#pragma checksum "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\Pages\Authentication.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13ff69d144078065a181f33f63c6584ae6b1db2d"
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
#line 1 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using MyPTClinicApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Telerik.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\_Imports.razor"
using Telerik.Blazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\Pages\Authentication.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/authentication/{action}")]
    public partial class Authentication : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticatorView>(0);
            __builder.AddAttribute(1, "Action", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 4 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\Pages\Authentication.razor"
                                  Action

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "LoggingIn", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(3, "<h3>Starting login process, please wait...</h3>");
            }
            ));
            __builder.AddAttribute(4, "CompletingLoggingIn", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(5, "<h3>Completing logging in, nearly there....</h3>");
            }
            ));
            __builder.AddAttribute(6, "LogOut", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(7, "<h3>Logging you out, enjoy your day!</h3>");
            }
            ));
            __builder.AddAttribute(8, "LogOutSucceeded", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(9, "<h3>Logged out, enjoy your day!</h3>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 20 "C:\CLONEDCOPY\MyPTClinicApp\MyPTClinicApp\Client\Pages\Authentication.razor"
      

    [CascadingParameter]
    Task<AuthenticationState> authenticationState { get; set; }

    [Parameter] public string Action { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
