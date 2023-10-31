using Microsoft.Extensions.Logging;
using Syncfusion.Blazor.HeatMap.Internal;
using static HotelBooking.Pages.Index;
using Syncfusion.Blazor.Schedule;
using System;
using HotelBooking.Data;

namespace HotelBooking.Data
{
    public class BookingServices
    {
        public List<AppointmentData> GenerateStaticEvents(
        DateTime start,
        int floor,
        int resCount,
        int overlapCount)
        {
            var data = new List<AppointmentData>();
            int id = 1;

            for (int i = 0, f = floor; i < resCount; i++, f++)
            {
                var randomCollection = new List<int>();
                int random = 0;

                for (int j = 0; j < overlapCount; j++)
                {
                    random = Convert.ToInt32(Math.Floor(new Random().NextDouble() * 26));
                    random = random == 0 ? 1 : random;

                    if (randomCollection.Contains(random) || randomCollection.Contains(random + 2) || randomCollection.Contains(random - 2))
                    {
                        int largest = randomCollection.Max();
                        random += largest + 10;
                    }

                    for (int k = 1; k <= 2; k++)
                    {
                        randomCollection.Add(random + k);
                    }
                    if (random > 26)
                    {
                        continue;
                    }
                    var startDate = new DateTime(start.Year, start.Month, random);
                    var endDate = startDate.AddMinutes(1470);

                    int dateDifference = 0;
                    TimeSpan timeDifference = endDate - startDate;
                    int differenceInDays = (int)(timeDifference.TotalMinutes / 60 / 24);
                    dateDifference = differenceInDays;

                    int nights = differenceInDays;


                    int floorCount = 0;
                    int roomsInFloor = 4;

                    if (i >= 1 * roomsInFloor)
                    {
                        floorCount += 1;
                    }

                    if (i >= 2 * roomsInFloor)
                    {
                        floorCount += 1;
                    }

                    if (i >= 3 * roomsInFloor)
                    {
                        floorCount += 1;
                    }

                    if (i >= 4 * roomsInFloor)
                    {
                        floorCount += 1;
                    }

                    data.Add(new AppointmentData
                    {
                        Id = id,
                        Subject = "Steve Smith",
                        StartTime = startDate,
                        EndTime = endDate,
                        IsAllDay = (id % 10) == 0,
                        FloorId = floorCount + 1,
                        RoomId = i + 1,
                        Nights = nights,
                        Adults = 2,
                        Children = 1,
                        Purpose = "Vacation",
                        Phone = "1234567891",
                        Email = "abc@gmail.com",
                        Price = "500",
                        Proof = 1,
                        ProofNumber = "12341234",
                        RecurrenceException = null,
                        RecurrenceID = null,
                        RecurrenceRule = null,
                    });

                    id++;
                }
            }
            return data;
        }
    }
}

