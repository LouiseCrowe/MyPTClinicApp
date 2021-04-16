﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Pages
{
    public partial class Confirm
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; } = "Confirm Delete";

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
