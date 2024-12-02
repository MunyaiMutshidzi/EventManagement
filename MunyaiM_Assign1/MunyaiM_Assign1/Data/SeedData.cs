using Microsoft.EntityFrameworkCore;
using MunyaiM_Assign1.Models;

namespace MunyaiM_Assign1.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Events.Any())
            {
                context.Events.AddRange(
                     new Event
                     {
                         //EventId = 1,
                         EventTitle = "MUSANGWE ROYAL GATHERING",
                         EventDescription = "The Royal event for strength testing",
                         EventStartDate = new DateTime(2024, 04, 05).Date,
                         EventEndDate = new DateTime(2024, 06, 05).Date,
                         EventLocation = "Tshakhuma, Luvhalani A",
                         EventMaxAttendees = 750,
                         EventRegistrations = 0
                        
                     },
                   new Event
                   {
                       //EventId = 2,
                       EventTitle = "Joyous Celebration",
                       EventDescription = "Praising and sharing the gospel of Christ to the society",
                       EventStartDate = new DateTime(2024, 08, 10),
                       EventEndDate = new DateTime(2024, 10, 31).Date,
                       EventLocation = "Thohoyandou, Town-Hall",
                       EventMaxAttendees = 2000,
                       EventRegistrations = 0
                   },
                      new Event
                    {
                    //EventId=3,
                          
                    EventTitle = "Driver's License testing",
                    EventDescription = "K53 a digital test, testing your road knowledge",
                    EventStartDate = new DateTime(2024, 05, 18),
                    EventLocation = "Vuwani, Traffic Centre",
                    EventMaxAttendees = 1,
                    EventRegistrations = 0
                   }
                        );
            }
            context.SaveChanges();
        }
    }
}
                                   