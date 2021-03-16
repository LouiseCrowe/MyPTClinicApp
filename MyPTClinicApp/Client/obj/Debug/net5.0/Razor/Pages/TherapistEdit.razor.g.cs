#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5af5e658b51c2ae6c07d8fc6ac54aba65823b19"
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
#line 4 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
using MyPTClinicApp.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/therapistedit")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/therapistedit/{TherapistID}")]
    public partial class TherapistEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
 if (SavedStatus == SavedStatus.NotSaved)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "section");
            __builder.AddAttribute(1, "class", "therapist-edit");
            __builder.OpenElement(2, "h1");
            __builder.AddAttribute(3, "class", "page-title");
            __builder.AddContent(4, "Details for ");
            __builder.AddContent(5, 
#nullable restore
#line 10 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                            Therapist.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(6, " ");
            __builder.AddContent(7, 
#nullable restore
#line 10 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                 Therapist.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(9);
            __builder.AddAttribute(10, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 11 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                          Therapist

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 11 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                     HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(12, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 12 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                    HandleInvalidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(14);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(16);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\r\n            ");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-group row");
                __builder2.AddMarkupContent(20, "<label for=\"firstName\" class=\"col-sm-3\">First name: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(21);
                __builder2.AddAttribute(22, "id", "firstName");
                __builder2.AddAttribute(23, "class", "form-control col-sm-8");
                __builder2.AddAttribute(24, "placeholder", "Enter first name");
                __builder2.AddAttribute(25, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                                      Therapist.FirstName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Therapist.FirstName = __value, Therapist.FirstName))));
                __builder2.AddAttribute(27, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Therapist.FirstName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(28, "\r\n                ");
                __Blazor.MyPTClinicApp.Client.Pages.TherapistEdit.TypeInference.CreateValidationMessage_0(__builder2, 29, 30, "offset-sm-3 col-sm-8", 31, 
#nullable restore
#line 18 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                       () => Therapist.FirstName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(32, "\r\n            ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "form-group row");
                __builder2.AddMarkupContent(35, "<label for=\"lastName\" class=\"col-sm-3\">Last name: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(36);
                __builder2.AddAttribute(37, "id", "lastName");
                __builder2.AddAttribute(38, "class", "form-control col-sm-8");
                __builder2.AddAttribute(39, "placeholder", "Enter last name");
                __builder2.AddAttribute(40, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 22 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                                     Therapist.LastName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Therapist.LastName = __value, Therapist.LastName))));
                __builder2.AddAttribute(42, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Therapist.LastName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(43, "\r\n                ");
                __Blazor.MyPTClinicApp.Client.Pages.TherapistEdit.TypeInference.CreateValidationMessage_1(__builder2, 44, 45, "offset-sm-3 col-sm-8", 46, 
#nullable restore
#line 23 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                       () => Therapist.LastName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(47, "\r\n\r\n            ");
                __builder2.OpenElement(48, "div");
                __builder2.AddAttribute(49, "class", "form-group row");
                __builder2.AddMarkupContent(50, "<label for=\"phone\" class=\"col-sm-3\">Phone: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(51);
                __builder2.AddAttribute(52, "id", "phone");
                __builder2.AddAttribute(53, "class", "form-control col-sm-8");
                __builder2.AddAttribute(54, "placeholder", "Enter phone");
                __builder2.AddAttribute(55, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                                  Therapist.Phone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(56, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Therapist.Phone = __value, Therapist.Phone))));
                __builder2.AddAttribute(57, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Therapist.Phone));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(58, "\r\n                ");
                __Blazor.MyPTClinicApp.Client.Pages.TherapistEdit.TypeInference.CreateValidationMessage_2(__builder2, 59, 60, "offset-sm-3 col-sm-8", 61, 
#nullable restore
#line 29 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                       () => Therapist.Phone

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(62, "\r\n\r\n            ");
                __builder2.OpenElement(63, "div");
                __builder2.AddAttribute(64, "class", "form-group row");
                __builder2.AddMarkupContent(65, "<label for=\"email\" class=\"col-sm-3\">Email: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(66);
                __builder2.AddAttribute(67, "id", "email");
                __builder2.AddAttribute(68, "class", "form-control col-sm-8");
                __builder2.AddAttribute(69, "placeholder", "Enter email");
                __builder2.AddAttribute(70, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 34 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                                  Therapist.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(71, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Therapist.Email = __value, Therapist.Email))));
                __builder2.AddAttribute(72, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Therapist.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(73, "\r\n                ");
                __Blazor.MyPTClinicApp.Client.Pages.TherapistEdit.TypeInference.CreateValidationMessage_3(__builder2, 74, 75, "offset-sm-3 col-sm-8", 76, 
#nullable restore
#line 35 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                       () => Therapist.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(77, "\r\n\r\n            ");
                __builder2.OpenElement(78, "div");
                __builder2.AddAttribute(79, "class", "form-group row");
                __builder2.AddMarkupContent(80, "<label for=\"street\" class=\"col-sm-3\">Location: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(81);
                __builder2.AddAttribute(82, "id", "street");
                __builder2.AddAttribute(83, "class", "form-control col-sm-8");
                __builder2.AddAttribute(84, "placeholder", "Enter location");
                __builder2.AddAttribute(85, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                                   Therapist.Location

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(86, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Therapist.Location = __value, Therapist.Location))));
                __builder2.AddAttribute(87, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Therapist.Location));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(88, "\r\n            <br>\r\n            ");
                __builder2.AddMarkupContent(89, "<div><button type=\"submit\" class=\"btn btn-primary edit-btn\">Save therapist</button></div>\r\n            <br>\r\n            ");
                __builder2.OpenElement(90, "div");
#nullable restore
#line 48 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                 if (Therapist.ID > 0)
                {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(91, "a");
                __builder2.AddAttribute(92, "class", "btn btn-danger");
                __builder2.AddAttribute(93, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 50 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                         DeleteTherapist

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(94, "\r\n                        Delete Therapist\r\n                    ");
                __builder2.CloseElement();
#nullable restore
#line 53 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(95, "\r\n            <br>\r\n            ");
                __builder2.OpenElement(96, "div");
                __builder2.OpenElement(97, "a");
                __builder2.AddAttribute(98, "class", "btn btn-outline-primary");
                __builder2.AddAttribute(99, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 57 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                              NavigateToOverview

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(100, "Back to therapist list");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 61 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"

}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(101, "div");
            __builder.AddAttribute(102, "class", "alert" + " " + (
#nullable restore
#line 65 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                       StatusClass

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(103, 
#nullable restore
#line 65 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                     Message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 68 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
     if (ButtonNavigation == "toOverview")
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(104, "div");
            __builder.OpenElement(105, "a");
            __builder.AddAttribute(106, "class", "btn btn-outline-primary");
            __builder.AddAttribute(107, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 71 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                              NavigateToOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(108, "Back to therapist list");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 73 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
         if (ButtonNavigation == "toAdd")
        {


#line default
#line hidden
#nullable disable
            __builder.OpenElement(109, "div");
            __builder.OpenElement(110, "a");
            __builder.AddAttribute(111, "class", "btn btn-outline-primary");
            __builder.AddAttribute(112, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 79 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                  NavigateToEditTherapist

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(113, "Add new therapist");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "<br>");
            __builder.OpenElement(115, "div");
            __builder.OpenElement(116, "a");
            __builder.AddAttribute(117, "class", "btn btn-outline-primary");
            __builder.AddAttribute(118, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 85 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
                                                                  NavigateToOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(119, "Back to therapist list");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 87 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TherapistEdit.razor"
         
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MyPTClinicApp.Client.Pages.TherapistEdit
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591