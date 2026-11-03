
using Lab3_WorkshopRSVP.Models;

namespace Lab3_WorkshopRSVP.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Do not add duplicates if data already exists
            if (context.Rsvps.Any())
            {
                return;
            }

            // Add initial workshop registrations
            var registrations = new Rsvp[]
            {
                new Rsvp
                {
                    FullName = "Sarah Smith",
                    WorkshopTitle = "Routing Basics",
                    NeedsAccommodation = false
                },
                new Rsvp
                {
                    FullName = "John Wilson",
                    WorkshopTitle = "EF Core Intro",
                    NeedsAccommodation = true
                },
                new Rsvp
                {
                    FullName = "Emily Brown",
                    WorkshopTitle = "Razor Essentials",
                    NeedsAccommodation = false
                }
            };

            context.Rsvps.AddRange(registrations);
            context.SaveChanges();
        }
    }
}
