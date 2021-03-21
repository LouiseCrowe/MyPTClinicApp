#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2571ca89e0c2d0a9b6cc0f6573c326f1f8d9426d"
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
#nullable restore
#line 5 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
using MyPTClinicApp.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/patientedit")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/patientedit/{PatientID}")]
    public partial class PatientEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
 if (Patient == null || Therapists == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<h3>Loading......  just a moment</h3>");
#nullable restore
#line 11 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
     if (SavedStatus == SavedStatus.NotSaved)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "section");
            __builder.AddAttribute(2, "class", "patient-edit");
            __builder.OpenElement(3, "h1");
            __builder.AddAttribute(4, "class", "page-title");
            __builder.AddContent(5, "Patient Details: ");
            __builder.AddContent(6, 
#nullable restore
#line 17 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                     Patient.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(7, " ");
            __builder.AddContent(8, 
#nullable restore
#line 17 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                        Patient.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(10);
            __builder.AddAttribute(11, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 19 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                              Patient

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 19 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                       HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(13, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 20 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                        HandleInvalidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(15);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(17);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(18, "\r\n                ");
                __builder2.OpenElement(19, "div");
                __builder2.AddAttribute(20, "class", "form-group row");
                __builder2.AddMarkupContent(21, "<label for=\"firstName\" class=\"col-sm-2\">First name: </label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(22);
                __builder2.AddAttribute(23, "id", "firstName");
                __builder2.AddAttribute(24, "class", "form-control col-sm-8");
                __builder2.AddAttribute(25, "placeholder", "Enter first name");
                __builder2.AddAttribute(26, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                         Patient.FirstName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.FirstName = __value, Patient.FirstName))));
                __builder2.AddAttribute(28, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.FirstName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(29, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateValidationMessage_0(__builder2, 30, 31, "offset-sm-3 col-sm-8", 32, 
#nullable restore
#line 28 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                           () => Patient.FirstName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n                ");
                __builder2.OpenElement(34, "div");
                __builder2.AddAttribute(35, "class", "form-group row");
                __builder2.AddMarkupContent(36, "<label for=\"lastName\" class=\"col-sm-2\">Last name: </label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(37);
                __builder2.AddAttribute(38, "id", "lastName");
                __builder2.AddAttribute(39, "class", "form-control col-sm-8");
                __builder2.AddAttribute(40, "placeholder", "Enter last name");
                __builder2.AddAttribute(41, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 32 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                        Patient.LastName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(42, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.LastName = __value, Patient.LastName))));
                __builder2.AddAttribute(43, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.LastName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(44, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateValidationMessage_1(__builder2, 45, 46, "offset-sm-3 col-sm-8", 47, 
#nullable restore
#line 35 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                           () => Patient.LastName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(48, "\r\n                ");
                __builder2.OpenElement(49, "div");
                __builder2.AddAttribute(50, "class", "form-group row");
                __builder2.AddMarkupContent(51, "<label for=\"phone\" class=\"col-sm-2\">Phone Number: </label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(52);
                __builder2.AddAttribute(53, "id", "phone");
                __builder2.AddAttribute(54, "class", "form-control col-sm-8");
                __builder2.AddAttribute(55, "placeholder", "Enter phone number");
                __builder2.AddAttribute(56, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 39 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                      Patient.Phone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(57, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Phone = __value, Patient.Phone))));
                __builder2.AddAttribute(58, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.Phone));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(59, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateValidationMessage_2(__builder2, 60, 61, "offset-sm-3 col-sm-8", 62, 
#nullable restore
#line 42 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                           () => Patient.Phone

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(63, "\r\n                ");
                __builder2.OpenElement(64, "div");
                __builder2.AddAttribute(65, "class", "form-group row");
                __builder2.AddMarkupContent(66, "<label for=\"email\" class=\"col-sm-2\">Email: </label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(67);
                __builder2.AddAttribute(68, "id", "email");
                __builder2.AddAttribute(69, "class", "form-control col-sm-8");
                __builder2.AddAttribute(70, "placeholder", "Enter email addess");
                __builder2.AddAttribute(71, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 46 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                      Patient.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(72, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Email = __value, Patient.Email))));
                __builder2.AddAttribute(73, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(74, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateValidationMessage_3(__builder2, 75, 76, "offset-sm-3 col-sm-8", 77, 
#nullable restore
#line 49 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                           () => Patient.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(78, "\r\n                ");
                __builder2.OpenElement(79, "div");
                __builder2.AddAttribute(80, "class", "form-group row");
                __builder2.AddMarkupContent(81, "<label for=\"address\" class=\"col-sm-2\">Address: </label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(82);
                __builder2.AddAttribute(83, "id", "address");
                __builder2.AddAttribute(84, "class", "form-control col-sm-8");
                __builder2.AddAttribute(85, "placeholder", "Enter addess");
                __builder2.AddAttribute(86, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                        Patient.Address

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(87, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Address = __value, Patient.Address))));
                __builder2.AddAttribute(88, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.Address));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(89, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateValidationMessage_4(__builder2, 90, 91, "offset-sm-3 col-sm-8", 92, 
#nullable restore
#line 56 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                           () => Patient.Address

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(93, "\r\n                ");
                __builder2.OpenElement(94, "div");
                __builder2.AddAttribute(95, "class", "form-group row");
                __builder2.AddMarkupContent(96, "<label for=\"dateOfBirth\" class=\"col-sm-2\">Date of birth: </label>\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateInputDate_5(__builder2, 97, 98, "dateOfBirth", 99, "form-control col-sm-8", 100, "Enter date of birth", 101, 
#nullable restore
#line 60 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                           Patient.DateOfBirth

#line default
#line hidden
#nullable disable
                , 102, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.DateOfBirth = __value, Patient.DateOfBirth)), 103, () => Patient.DateOfBirth);
                __builder2.CloseElement();
                __builder2.AddMarkupContent(104, "\r\n                ");
                __builder2.OpenElement(105, "div");
                __builder2.AddAttribute(106, "class", "form-group row");
                __builder2.AddMarkupContent(107, "<label for=\"medications\" class=\"col-sm-2\">Medications: </label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(108);
                __builder2.AddAttribute(109, "id", "medications");
                __builder2.AddAttribute(110, "class", "form-control col-sm-8");
                __builder2.AddAttribute(111, "placeholder", "Enter medications");
                __builder2.AddAttribute(112, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 66 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                           Patient.Medications

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(113, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Medications = __value, Patient.Medications))));
                __builder2.AddAttribute(114, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.Medications));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(115, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateValidationMessage_6(__builder2, 116, 117, "offset-sm-3 col-sm-8", 118, 
#nullable restore
#line 69 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                           () => Patient.Medications

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(119, "\r\n                ");
                __builder2.OpenElement(120, "div");
                __builder2.AddAttribute(121, "class", "form-group row");
                __builder2.AddMarkupContent(122, "<label for=\"gender\" class=\"col-sm-2\">Gender: </label>\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateInputSelect_7(__builder2, 123, 124, "gender", 125, "form-control col-sm-8", 126, 
#nullable restore
#line 73 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                        Patient.Gender

#line default
#line hidden
#nullable disable
                , 127, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Gender = __value, Patient.Gender)), 128, () => Patient.Gender, 129, (__builder3) => {
                    __builder3.OpenElement(130, "option");
                    __builder3.AddAttribute(131, "value", 
#nullable restore
#line 74 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                         Gender.Male

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(132, "Male");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(133, "\r\n                        ");
                    __builder3.OpenElement(134, "option");
                    __builder3.AddAttribute(135, "value", 
#nullable restore
#line 75 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                         Gender.Female

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(136, "Female");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(137, "\r\n                        ");
                    __builder3.OpenElement(138, "option");
                    __builder3.AddAttribute(139, "value", 
#nullable restore
#line 76 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                         Gender.Other

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(140, "Other");
                    __builder3.CloseElement();
                }
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(141, "\r\n                ");
                __builder2.OpenElement(142, "div");
                __builder2.AddAttribute(143, "class", "form-group row");
                __builder2.AddMarkupContent(144, "<label for=\"therapist\" class=\"col-sm-2\">Therapist: </label>\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.PatientEdit.TypeInference.CreateInputSelect_8(__builder2, 145, 146, "therapist", 147, "form-control col-sm-8", 148, 
#nullable restore
#line 81 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                           Patient.TherapistID

#line default
#line hidden
#nullable disable
                , 149, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.TherapistID = __value, Patient.TherapistID)), 150, () => Patient.TherapistID, 151, (__builder3) => {
#nullable restore
#line 82 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                         foreach (var therapist in Therapists)
                                {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(152, "option");
                    __builder3.AddAttribute(153, "value", 
#nullable restore
#line 84 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                            therapist.ID

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(154, 
#nullable restore
#line 84 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                           therapist.FirstName

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(155, " ");
                    __builder3.AddContent(156, 
#nullable restore
#line 84 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                                therapist.LastName

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
#nullable restore
#line 85 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(157, "\r\n\r\n                <br>\r\n                ");
                __builder2.AddMarkupContent(158, "<div><button type=\"submit\" class=\"btn btn-primary edit-btn\">Save Patient</button></div>\r\n                <br>\r\n                ");
                __builder2.OpenElement(159, "div");
#nullable restore
#line 95 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                     if (Patient.ID > 0)
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(160, "a");
                __builder2.AddAttribute(161, "class", "btn btn-danger");
                __builder2.AddAttribute(162, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 97 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                             DeletePatient

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(163, "\r\n                            Delete Patient\r\n                        ");
                __builder2.CloseElement();
#nullable restore
#line 100 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                    }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(164, "\r\n                <br>\r\n                ");
                __builder2.OpenElement(165, "div");
                __builder2.OpenElement(166, "a");
                __builder2.AddAttribute(167, "class", "btn btn-outline-primary");
                __builder2.AddAttribute(168, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 104 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                                  NavigateToOverview

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(169, "Back to patient list");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 108 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
    }

    else
    {


#line default
#line hidden
#nullable disable
            __builder.OpenElement(170, "div");
            __builder.AddAttribute(171, "class", "alert" + " " + (
#nullable restore
#line 113 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                           StatusClass

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(172, 
#nullable restore
#line 113 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                         Message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 116 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
         if (ButtonNavigation == "toOverview")
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(173, "div");
            __builder.OpenElement(174, "a");
            __builder.AddAttribute(175, "class", "btn btn-outline-primary");
            __builder.AddAttribute(176, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 119 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                              NavigateToOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(177, "Back to Patient list");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 121 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
         if (ButtonNavigation == "toAdd")
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(178, "div");
            __builder.OpenElement(179, "a");
            __builder.AddAttribute(180, "class", "btn btn-outline-primary");
            __builder.AddAttribute(181, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 126 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                              NavigateToEditPatient

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(182, "Add new patient");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(183, "<br>");
            __builder.OpenElement(184, "div");
            __builder.OpenElement(185, "a");
            __builder.AddAttribute(186, "class", "btn btn-outline-primary");
            __builder.AddAttribute(187, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 132 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
                                                              NavigateToOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(188, "Back to Patient list");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 134 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 135 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\PatientEdit.razor"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MyPTClinicApp.Client.Pages.PatientEdit
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
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateInputDate_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "placeholder", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_6<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_7<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.AddAttribute(__seq5, "ChildContent", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_8<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.AddAttribute(__seq5, "ChildContent", __arg5);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
