using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Calendars;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Schedule;
using HotelBooking.Pages;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Navigations;
using Syncfusion.Blazor.Notifications;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Inputs;
using Index = HotelBooking.Pages.Index;

namespace HotelBooking.Data
{
    public class AppointmentService
    {
        public event EventHandler DataChanged;
        public AppointmentService()
        {
            this.CurrentDate = (DateTime)(DateTime.Now).Date;
            this.SelectAllChecked = false;
            this.GroundFloorChecked = true;
            this.FirstFloorChecked = true;
            this.SecondFloorChecked = false;
            this.ThirdFloorChecked = false;
            this.FourthFloorChecked = false;
            this.TelevisionChecked = true;
            this.ProjectorChecked = false;
            this.WhiteBoardChecked = false;
            this.KitchenChecked = false;
            this.BalconyChecked = false;
            this.InternetChecked = false;
            this.GroundFloorId = "1";
            this.FirstFloorId = "2";
            this.SecondFloorId = "3";
            this.ThirdFloorId = "4";
            this.FourthFloorId = "5";
            this.TelevisionId = "1";
            this.ProjectorId = "2";
            this.WhiteBoardId = "3";
            this.KitchenId = "4";
            this.BalconyId = "5";
            this.InternetId = "6";
            this.ddlValue = 1;
            this.price = 500;
            this.ResourceQuery = new Query().Where(new WhereFilter() { Field = "Id", Operator = "equal", value = 1 }.Or(new WhereFilter() { Field = "Id", Operator = "equal", value = 2 }));
            this.query = new Query().Search("Television", new List<string> { "Amenities" }, null, true, true);
            this.DropDownQuery = new Query().Where(new WhereFilter() { Field = "RoomsId", Operator = "equal", value = 1 });
            this.showCalendar = true;
            this.DateTimePickerStartTime = DateTime.Now.Date;
            this.DateTimePickerEndTime = DateTime.Now.Date.AddDays(1);
            TimeSpan difference = this.DateTimePickerEndTime.Subtract(this.DateTimePickerStartTime);
            int totalDays = Convert.ToInt32(difference.TotalDays);
            this.NoOfNights = totalDays - 1;
            this.isOverlay = false;
            this.ToastPositionXValue = "right";
            this.ToastPositionYValue = "bottom";
            this.ToastContent = "";
            this.renderSchedule = "";
            this.showNoSchedule = "hide-no-schedule";
            this.proofDdlValue = 1;
        }
        public DateTime CurrentDate { get; set; }
        public bool SelectAllChecked { get; set; } 
        public bool GroundFloorChecked { get; set; } 
        public bool FirstFloorChecked { get; set; }
        public bool SecondFloorChecked { get; set; } 
        public bool ThirdFloorChecked { get; set; } 
        public bool FourthFloorChecked { get; set; } 
        public bool TelevisionChecked { get; set; }
        public bool ProjectorChecked { get; set; }
        public bool WhiteBoardChecked { get; set; }
        public bool KitchenChecked { get; set; }
        public bool BalconyChecked { get; set; }
        public bool InternetChecked { get; set; }

        public string GroundFloorId { get; set; }
        public string FirstFloorId { get; set; }
        public string SecondFloorId { get; set; }
        public string ThirdFloorId { get; set; }
        public string FourthFloorId { get; set; }
        public string TelevisionId { get; set; }
        public string ProjectorId { get; set; }
        public string WhiteBoardId { get; set; }
        public string KitchenId { get; set; }
        public string BalconyId { get; set; }
        public string InternetId { get; set; }
        public string SearchValue { get; set; }
        public Query ResourceQuery { get; set; }
        public Query DropDownQuery { get; set; }
        public Query query { get; set; }
        public int ddlValue { get; set; }
        public int price { get; set; }
        public DateTime DateTimePickerStartTime { get; set; }
        public DateTime DateTimePickerEndTime { get; set; }
        public int NoOfNights { get; set; }
        public bool isOverlay { get; set; }
        public string ToastPositionXValue { get; set; }
        public string ToastPositionYValue { get; set; }
        public string ToastContent { get; set; }
        public string isDevice { get; set; }
        public bool mobile { get; set; }
        public string renderSchedule { get; set; }
        public string showNoSchedule { get; set; }
        public int proofDdlValue { get; set; }
        public string hide { get; set; }
        public string opacity { get; set; } = "0";
        public string visible { get; set; } = "hidden";
        public List<AppointmentData> appointmentData = new List<AppointmentData>();
        public readonly Dictionary<string, string> Mappings = new Dictionary<string, string>()
    {
        { "1_1", "#E879F9" },
        { "2_1", "#4ADE80" },
        { "3_1", "#6F47FF" },
        { "4_1", "#22D3EE" },
        { "5_2", "#F472B6" },
        { "6_2", "#FDBA74" },
        { "7_2", "#C084FC" },
        { "8_2", "#22D3EE" },
        { "9_3", "#E879F9" },
        { "10_3", "#4ADE80" },
        { "11_3", "#6F47FF" },
        { "12_3", "#22D3EE" },
        { "13_4", "#F472B6" },
        { "14_4", "#FDBA74" },
        { "15_4", "#C084FC" },
        { "16_4", "#22D3EE" },
        { "17_5", "#E879F9" },
        { "18_5", "#4ADE80" },
        { "19_5", "#6F47FF" },
        { "20_5", "#22D3EE" },
    };
        public bool showCalendar { get; set; }
        public SfSchedule<AppointmentData> ScheduleRef;
        public SfCalendar<DateTime> CalendarRef;
        public SfDropDownBase<ResourceData> DropDownRef;
        public SfSidebar sidebarRef;
        public SfToast ToastObj;
        public SfSlider<int[]> rangeSliderRef;
        internal Schedule? SchedulerPageRef { get; set; }
        internal Header? HeaderPageRef { get; set; }
        internal Sidebar? SidebarPageRef { get; set; }
        internal Calendar CalendarPageRef { get; set; }
        internal Index IndexPageRef { get; set; }
    }
}
