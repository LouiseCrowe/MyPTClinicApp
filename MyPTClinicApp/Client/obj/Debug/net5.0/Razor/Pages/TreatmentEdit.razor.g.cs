#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48ced85b3a13decf26aa2c7e8938e01999a64aa1"
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
#nullable restore
#line 5 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
using MyPTClinicApp.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/treatmentedit")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/treatmentedit/{TreatmentID}")]
    public partial class TreatmentEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
 if (Treatment == null || Patients == null || Therapists == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading......  just a moment</em></p>");
#nullable restore
#line 11 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
}

else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
     if (SavedStatus == SavedStatus.NotSaved)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "section");
            __builder.AddAttribute(2, "class", "treatment-edit");
            __builder.AddMarkupContent(3, "<h1 class=\"page-title\">Treatment Details</h1>\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(4);
            __builder.AddAttribute(5, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 19 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                              Treatment

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 19 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                         HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(7, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 20 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                        HandleInvalidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(9);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(10, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(11);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(12, "\r\n                ");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "class", "form-group row");
                __builder2.AddMarkupContent(15, "<label for=\"patientId\" class=\"col-sm-2\">Patient: </label>\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.TreatmentEdit.TypeInference.CreateInputSelect_0(__builder2, 16, 17, "patientId", 18, "form-control col-sm-8", 19, 
#nullable restore
#line 25 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                                           Treatment.PatientID

#line default
#line hidden
#nullable disable
                , 20, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Treatment.PatientID = __value, Treatment.PatientID)), 21, () => Treatment.PatientID, 22, (__builder3) => {
#nullable restore
#line 26 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                         foreach (var patient in Patients)
                                {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(23, "option");
                    __builder3.AddAttribute(24, "value", 
#nullable restore
#line 28 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                            patient.ID

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(25, 
#nullable restore
#line 28 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                         patient.FirstName

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(26, " ");
                    __builder3.AddContent(27, 
#nullable restore
#line 28 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                            patient.LastName

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
#nullable restore
#line 29 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.AddMarkupContent(28, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.TreatmentEdit.TypeInference.CreateValidationMessage_1(__builder2, 29, 30, "offset-sm-3 col-sm-8", 31, 
#nullable restore
#line 31 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                           () => Treatment.PatientID

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(32, "\r\n                ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "form-group row");
                __builder2.AddMarkupContent(35, "<label for=\"therapistId\" class=\"col-sm-2\">Therapist: </label>\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.TreatmentEdit.TypeInference.CreateInputSelect_2(__builder2, 36, 37, "therapistId", 38, "form-control col-sm-8", 39, 
#nullable restore
#line 35 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                                             Treatment.TherapistID

#line default
#line hidden
#nullable disable
                , 40, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Treatment.TherapistID = __value, Treatment.TherapistID)), 41, () => Treatment.TherapistID, 42, (__builder3) => {
#nullable restore
#line 36 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                         foreach (var therapist in Therapists)
                                {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(43, "option");
                    __builder3.AddAttribute(44, "value", 
#nullable restore
#line 38 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                            therapist.ID

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(45, 
#nullable restore
#line 38 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                           therapist.FirstName

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(46, " ");
                    __builder3.AddContent(47, 
#nullable restore
#line 38 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                                therapist.LastName

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
#nullable restore
#line 39 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                }

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.AddMarkupContent(48, "\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.TreatmentEdit.TypeInference.CreateValidationMessage_3(__builder2, 49, 50, "offset-sm-3 col-sm-8", 51, 
#nullable restore
#line 41 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                           () => Treatment.TherapistID

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(52, "\r\n                ");
                __builder2.OpenElement(53, "div");
                __builder2.AddAttribute(54, "class", "form-group row");
                __builder2.AddMarkupContent(55, "<label for=\"date\" class=\"col-sm-2\">Date: </label>\r\n                    ");
                __Blazor.MyPTClinicApp.Client.Pages.TreatmentEdit.TypeInference.CreateInputDate_4(__builder2, 56, 57, "date", 58, "form-control col-sm-8", 59, 
#nullable restore
#line 45 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                                    Treatment.Date

#line default
#line hidden
#nullable disable
                , 60, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Treatment.Date = __value, Treatment.Date)), 61, () => Treatment.Date);
                __builder2.CloseElement();
                __builder2.AddMarkupContent(62, "\r\n                ");
                __builder2.OpenElement(63, "div");
                __builder2.AddAttribute(64, "class", "form-group row");
                __builder2.AddMarkupContent(65, "<label for=\"notes\" class=\"col-sm-2\">Notes: </label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(66);
                __builder2.AddAttribute(67, "id", "date");
                __builder2.AddAttribute(68, "class", "form-control col-sm-8");
                __builder2.AddAttribute(69, "placeholder", "Enter notes");
                __builder2.AddAttribute(70, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 50 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                                        Treatment.Notes

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(71, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Treatment.Notes = __value, Treatment.Notes))));
                __builder2.AddAttribute(72, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Treatment.Notes));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(73, "\r\n                <br>\r\n                ");
                __builder2.AddMarkupContent(74, "<div><button type=\"submit\" class=\"btn btn-primary edit-btn\">Save Treatment</button></div>\r\n                <br>\r\n                ");
                __builder2.OpenElement(75, "div");
#nullable restore
#line 60 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                     if (Treatment.ID > 0)
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(76, "a");
                __builder2.AddAttribute(77, "class", "btn btn-danger");
                __builder2.AddAttribute(78, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 62 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                             DeleteTreatment

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddMarkupContent(79, "\r\n                            Delete Treatment\r\n                        ");
                __builder2.CloseElement();
#nullable restore
#line 65 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                    }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(80, "\r\n                <br>\r\n                ");
                __builder2.OpenElement(81, "div");
                __builder2.OpenElement(82, "a");
                __builder2.AddAttribute(83, "class", "btn btn-outline-primary");
                __builder2.AddAttribute(84, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 69 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                                  NavigateToTreatmentOverview

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(85, "Back to treatment list");
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 73 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"

    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(86, "div");
            __builder.AddAttribute(87, "class", "alert" + " " + (
#nullable restore
#line 77 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                           StatusClass

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(88, 
#nullable restore
#line 77 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                         Message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 80 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
         if (ButtonNavigation == "toOverview")
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(89, "div");
            __builder.OpenElement(90, "a");
            __builder.AddAttribute(91, "class", "btn btn-outline-primary");
            __builder.AddAttribute(92, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 83 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                              NavigateToTreatmentOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(93, "Back to treatment list");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 85 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
         if (ButtonNavigation == "toEdit")
        {


#line default
#line hidden
#nullable disable
            __builder.OpenElement(94, "div");
            __builder.OpenElement(95, "a");
            __builder.AddAttribute(96, "class", "btn btn-outline-primary");
            __builder.AddAttribute(97, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 91 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                              NavigateToEditTreatment

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(98, "Add new treatment");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(99, "<br>");
            __builder.OpenElement(100, "div");
            __builder.OpenElement(101, "a");
            __builder.AddAttribute(102, "class", "btn btn-outline-primary");
            __builder.AddAttribute(103, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 97 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
                                                              NavigateToTreatmentOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(104, "Back to treatment list");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 99 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\TreatmentEdit.razor"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MyPTClinicApp.Client.Pages.TreatmentEdit
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputSelect_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
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
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateInputSelect_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5)
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
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateInputDate_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
