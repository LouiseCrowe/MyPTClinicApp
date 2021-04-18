using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class Confirm
    {
        // for displaying Delete confirmation dialog box
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; } = "Confirm Delete";           // set default, can overridden in razor page

        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete record?";

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        // bool is the event payload (true to delete, false to cancel)
        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;                       
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}
