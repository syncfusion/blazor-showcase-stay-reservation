using HotelBooking.Data;
using Syncfusion.Blazor.Calendars;
using Syncfusion.Blazor.Buttons;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Schedule;
using System;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.TreeMap;
using Syncfusion.Blazor.Navigations;
using System.ComponentModel;
using Microsoft.JSInterop;
using System.Reflection;

namespace HotelBooking.Pages
{
    public partial class Index
    {
        [Inject]
        public AppointmentService Service { get; set; }
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }
        internal void StateChanged()
        {
            StateHasChanged();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            service.IndexPageRef = this;
            FloorServices floorService = new FloorServices();
            Service.appointmentData = floorService.GenerateStaticEvents(DateTime.Now, 5, 20, 30);
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Service.mobile = await JSRuntime.InvokeAsync<bool>("isDevice");
                Service.isDevice = Service.mobile ? "Mobile" : "Desktop";
                Service.HeaderPageRef.StateChanged();
                Service.SchedulerPageRef.StateChanged();
            }
        }
    }

}
