using StayReservation.Data;
using Syncfusion.Blazor.Calendars;
using Syncfusion.Blazor.Buttons;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Schedule;
using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.TreeMap;
using Syncfusion.Blazor.Navigations;
using System.ComponentModel;
using System.Reflection;

namespace StayReservation.Components.Pages
{
    public partial class Index
    {
        [Inject]
        public AppointmentService Service { get; set; }
        internal void StateChanged()
        {
            StateHasChanged();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Service.IndexPageRef = this;
            ReservationServices floorService = new ReservationServices();
            Service.appointmentData = floorService.GenerateStaticEvents(DateTime.Now, 5, 20, 30);
        }
    }

}
