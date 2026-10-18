using Microsoft.EntityFrameworkCore;    
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Data
{
    public class RaceDayContext : DbContext
    {
        public RaceDayContext(DbContextOptions<RaceDayContext> options) : base(options)
        {
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RaceEvent> RaceEvents { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>().HasKey(participant => participant.participantID);
            modelBuilder.Entity<Organiser>().HasKey(organiser => organiser.organiserID);
            modelBuilder.Entity<Category>().HasKey(category => category.categoryID);
            modelBuilder.Entity<RaceEvent>().HasKey(raceEvent => raceEvent.eventID);
            modelBuilder.Entity<Registration>().HasKey(registration => registration.registrationID);
            modelBuilder.Entity<Result>().HasKey(result => result.resultID);
        }
    }
}
