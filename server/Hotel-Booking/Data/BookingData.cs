using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Data
{
   public class BookingService
    {
        
        public static string[] Resources { get; set; } = { "Floors", "Rooms" };
        public static List<ResourceData> FloorData { get; set; } = new List<ResourceData>
    {
        new ResourceData{ FloorText = "Ground Floor", Id = 1, FloorColor = "#cb6bb2" },
        new ResourceData{ FloorText = "First Floor", Id = 2, FloorColor = "#56ca85" },
        new ResourceData{ FloorText = "Second Floor", Id = 3, FloorColor = "#56ca85" },
        new ResourceData{ FloorText = "Third Floor", Id = 4, FloorColor = "#56ca85" },
        new ResourceData{ FloorText = "Fourth Floor", Id = 5, FloorColor = "#56ca85" },

    };
        public static List<ResourceData> RoomData { get; set; } = new List<ResourceData>
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
        public static List<AppointmentData> DataSource = new List<AppointmentData>
     {
        new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2023, 10, 1, 9, 30, 0) , EndTime = new DateTime(2023, 10, 2,9, 30, 0), 
            FloorId = 1, RoomId = 1, Price= "500", Nights= 1, Adults=2, Children=1, Purpose="Vacation", Proof=1, ProofNumber="123ASD",
        Email="eramrajurr@gmail.com", Phone="9489507800"}
    };
        public static int[] Range = new int[] { 200, 300 };

       
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
