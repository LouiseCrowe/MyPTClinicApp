#pragma checksum "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56e899b43d6f8adb3d848cbe0afca1da4aeba16e"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/scheduleroverview")]
    public partial class SchedulerOverview : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __Blazor.MyPTClinicApp.Client.Pages.SchedulerOverview.TypeInference.CreateTelerikScheduler_0(__builder, 0, 1, 
#nullable restore
#line 3 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                         Appointments

#line default
#line hidden
#nullable disable
            , 2, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Telerik.Blazor.Components.SchedulerUpdateEventArgs>(this, 
#nullable restore
#line 4 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                             UpdateAppointment

#line default
#line hidden
#nullable disable
            ), 3, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Telerik.Blazor.Components.SchedulerCreateEventArgs>(this, 
#nullable restore
#line 5 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                             AddAppointment

#line default
#line hidden
#nullable disable
            ), 4, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Telerik.Blazor.Components.SchedulerDeleteEventArgs>(this, 
#nullable restore
#line 6 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                             DeleteAppointment

#line default
#line hidden
#nullable disable
            ), 5, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Telerik.Blazor.Components.SchedulerEditEventArgs>(this, 
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                           EditHandler

#line default
#line hidden
#nullable disable
            ), 6, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Telerik.Blazor.Components.SchedulerCancelEventArgs>(this, 
#nullable restore
#line 7 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                                   CancelHandler

#line default
#line hidden
#nullable disable
            ), 7, 
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                               true

#line default
#line hidden
#nullable disable
            , 8, 
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                                  true

#line default
#line hidden
#nullable disable
            , 9, 
#nullable restore
#line 8 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                                                     true

#line default
#line hidden
#nullable disable
            , 10, "600px", 11, "800px", 12, 
#nullable restore
#line 9 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                               StartDate

#line default
#line hidden
#nullable disable
            , 13, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.DateTime>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => StartDate = __value, StartDate)), 14, 
#nullable restore
#line 9 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                                       CurrView

#line default
#line hidden
#nullable disable
            , 15, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Telerik.Blazor.SchedulerView>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => CurrView = __value, CurrView)), 16, (__builder2) => {
                __builder2.OpenComponent<Telerik.Blazor.Components.SchedulerMonthView>(17);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(18, "\r\n        ");
                __builder2.OpenComponent<Telerik.Blazor.Components.SchedulerDayView>(19);
                __builder2.AddAttribute(20, "StartTime", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 12 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                      DayStartTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "WorkDayStart", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 13 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                         DayStartTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "WorkDayEnd", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 14 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                       DayEndTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(23, "\r\n        ");
                __builder2.OpenComponent<Telerik.Blazor.Components.SchedulerWeekView>(24);
                __builder2.AddAttribute(25, "StartTime", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 15 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                       DayStartTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(26, "WorkDayStart", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 16 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                          DayStartTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(27, "WorkDayEnd", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 17 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                        DayEndTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(28, "\r\n        ");
                __builder2.OpenComponent<Telerik.Blazor.Components.SchedulerMultiDayView>(29);
                __builder2.AddAttribute(30, "StartTime", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 18 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                           DayStartTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(31, "WorkDayStart", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 19 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                         DayStartTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(32, "WorkDayEnd", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.DateTime>(
#nullable restore
#line 20 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                       DayEndTime

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(33, "NumberOfDays", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 21 "C:\MyPTClinicApp\MyPTClinicApp\Client\Pages\SchedulerOverview.razor"
                                        10

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            );
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MyPTClinicApp.Client.Pages.SchedulerOverview
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateTelerikScheduler_0<TItem>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.Generic.IEnumerable<TItem> __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<global::Telerik.Blazor.Components.SchedulerUpdateEventArgs> __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<global::Telerik.Blazor.Components.SchedulerCreateEventArgs> __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<global::Telerik.Blazor.Components.SchedulerDeleteEventArgs> __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<global::Telerik.Blazor.Components.SchedulerEditEventArgs> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.EventCallback<global::Telerik.Blazor.Components.SchedulerCancelEventArgs> __arg5, int __seq6, global::System.Boolean __arg6, int __seq7, global::System.Boolean __arg7, int __seq8, global::System.Boolean __arg8, int __seq9, global::System.String __arg9, int __seq10, global::System.String __arg10, int __seq11, global::System.DateTime __arg11, int __seq12, global::Microsoft.AspNetCore.Components.EventCallback<global::System.DateTime> __arg12, int __seq13, global::Telerik.Blazor.SchedulerView __arg13, int __seq14, global::Microsoft.AspNetCore.Components.EventCallback<global::Telerik.Blazor.SchedulerView> __arg14, int __seq15, global::Microsoft.AspNetCore.Components.RenderFragment __arg15)
        {
        __builder.OpenComponent<global::Telerik.Blazor.Components.TelerikScheduler<TItem>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "OnUpdate", __arg1);
        __builder.AddAttribute(__seq2, "OnCreate", __arg2);
        __builder.AddAttribute(__seq3, "OnDelete", __arg3);
        __builder.AddAttribute(__seq4, "OnEdit", __arg4);
        __builder.AddAttribute(__seq5, "OnCancel", __arg5);
        __builder.AddAttribute(__seq6, "AllowCreate", __arg6);
        __builder.AddAttribute(__seq7, "AllowDelete", __arg7);
        __builder.AddAttribute(__seq8, "AllowUpdate", __arg8);
        __builder.AddAttribute(__seq9, "Height", __arg9);
        __builder.AddAttribute(__seq10, "Width", __arg10);
        __builder.AddAttribute(__seq11, "Date", __arg11);
        __builder.AddAttribute(__seq12, "DateChanged", __arg12);
        __builder.AddAttribute(__seq13, "View", __arg13);
        __builder.AddAttribute(__seq14, "ViewChanged", __arg14);
        __builder.AddAttribute(__seq15, "SchedulerViews", __arg15);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591