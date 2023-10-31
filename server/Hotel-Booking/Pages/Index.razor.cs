using HotelBooking.Data;
using Syncfusion.Blazor.Calendars;
using Syncfusion.Blazor.Buttons;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Schedule;
using System;
using Microsoft.AspNetCore.Components;
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
            Service.IndexPageRef = this;
            BookingServices floorService = new BookingServices();
            Service.appointmentData = floorService.GenerateStaticEvents(DateTime.Now, 5, 20, 30);
        }
    }

}
