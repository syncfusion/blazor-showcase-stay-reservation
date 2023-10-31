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
using System.ComponentModel.DataAnnotations;

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
            this.Resources = new string[] { "Floors", "Rooms" };
            this.FloorData = new List<ResourceData>
            {
                new ResourceData{ FloorText = "Ground Floor", Id = 1, FloorColor = "#cb6bb2" },
                new ResourceData{ FloorText = "First Floor", Id = 2, FloorColor = "#56ca85" },
                new ResourceData{ FloorText = "Second Floor", Id = 3, FloorColor = "#56ca85" },
                new ResourceData{ FloorText = "Third Floor", Id = 4, FloorColor = "#56ca85" },
                new ResourceData{ FloorText = "Fourth Floor", Id = 5, FloorColor = "#56ca85" },

            };
            this.RoomData = new List<ResourceData>
            {
                new ResourceData{ RoomText = "Alpha Room", Id = 1, RoomsId = 1, RoomColor = "#FDF4FF",Price=500, Amenities =  "Television, Projector, Balcony, Whiteboard, Kitchen, Internet"  },
                new ResourceData{ RoomText = "Beta Room", Id = 2, RoomsId = 1, RoomColor = "#F0FDF4",Price=400, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen"  },
                new ResourceData{ RoomText = "Gamma Room", Id = 3, RoomsId = 1, RoomColor = "#ECE7FF",Price=250, Amenities =  "Television, Projector, Balcony"  },
                new ResourceData{ RoomText = "Zeta Room", Id = 4, RoomsId = 1, RoomColor = "#ECFEFF",Price=150, Amenities = "Television"  },
                new ResourceData{ RoomText = "Alpha Room", Id = 5, RoomsId = 2, RoomColor = "#FDF2F8",Price=500, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen, Internet" },
                new ResourceData{ RoomText = "Beta Room", Id = 6, RoomsId = 2, RoomColor = "#FFF7ED" ,Price=400, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen" },
                new ResourceData{ RoomText = "Gamma Room", Id = 7, RoomsId = 2, RoomColor = "#FDF4FF",Price=250, Amenities = "Television, Projector, Balcony" },
                new ResourceData{ RoomText = "Zeta Room", Id = 8, RoomsId = 2, RoomColor = "#ECFEFF",Price=150, Amenities = "Television" },
                new ResourceData{ RoomText = "Alpha Room", Id = 9, RoomsId = 3, RoomColor = "#FDF4FF",Price=500, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen, Internet" },
                new ResourceData{ RoomText = "Beta Room", Id = 10, RoomsId = 3, RoomColor = "#F0FDF4",Price=400, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen"  },
                new ResourceData{ RoomText = "Gamma Room", Id = 11, RoomsId = 3, RoomColor = "#ECE7FF",Price=250, Amenities = "Television, Projector, Balcony" },
                new ResourceData{ RoomText = "Zeta Room", Id = 12, RoomsId = 3, RoomColor = "#ECFEFF",Price=150, Amenities = "Television" },
                new ResourceData{ RoomText = "Alpha Room", Id = 13, RoomsId = 4, RoomColor = "#FDF2F8",Price=500, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen, Internet" },
                new ResourceData{ RoomText = "Beta Room", Id = 14, RoomsId = 4, RoomColor = "#FFF7ED",Price=400, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen"  },
                new ResourceData{ RoomText = "Gamma Room", Id = 15, RoomsId = 4, RoomColor = "#FDF4FF",Price=250, Amenities = "Television, Projector, Balcony" },
                new ResourceData{ RoomText = "Zeta Room", Id = 16, RoomsId = 4, RoomColor = "#ECFEFF",Price=150, Amenities = "Television" },
                new ResourceData{ RoomText = "Alpha Room", Id = 17, RoomsId = 5, RoomColor = "#FDF4FF",Price=500, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen, Internet" },
                new ResourceData{ RoomText = "Beta Room", Id = 18, RoomsId = 5, RoomColor = "#F0FDF4",Price=400, Amenities = "Television, Projector, Balcony, Whiteboard, Kitchen"  },
                new ResourceData{ RoomText = "Gamma Room", Id = 19, RoomsId = 5, RoomColor = "#ECE7FF",Price=250, Amenities = "Television, Projector, Balcony" },
                new ResourceData{ RoomText = "Zeta Room", Id = 20, RoomsId = 5, RoomColor = "#ECFEFF",Price=150, Amenities = "Television" },
            };
            this.Range = new int[] { 200, 300 };
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
        public string[] Resources { get; set; }
        public List<ResourceData> FloorData { get; set; }
        public List<ResourceData> RoomData { get; set; }
        public int[] Range { get; set; }
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

    public class AppointmentData
    {
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; } = false;
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
        public string Price { get; set; }
        public int Nights { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        [Required]
        public string Purpose { get; set; }
        [Required]
        public int Proof { get; set; }
        [Required]
        public string ProofNumber { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }
        public string BorderColor { get; set; }
    }

    public class ResourceData
    {
        public int Id { get; set; }
        public string FloorText { get; set; }
        public string FloorColor { get; set; }
        public string RoomText { get; set; }
        public string RoomColor { get; set; }
        public int RoomsId { get; set; }
        public string Amenities { get; set; }
        public int Price { get; set; }
    }

    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
