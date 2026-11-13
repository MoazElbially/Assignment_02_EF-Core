using Assignment_02_EF_Core.EventHub.Configurations;
using Assignment_02_EF_Core.EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_02_EF_Core.EventHub.Data
{
    internal class EventHubDbContext: DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Biography)
                      .IsRequired();

                entity.Property(p => p.Website)
                      .IsRequired();

                entity.Property(p => p.Logo)
                      .IsRequired();

                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.Profile)
                      .HasForeignKey<OrganizerProfile>(
                          p => p.OrganizerId)
                      .IsRequired();
            });


            modelBuilder.Entity<Badge>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.BadgeNumber)
                      .IsRequired();

                entity.HasIndex(b => b.BadgeNumber)
                      .IsUnique();

                entity.Property(b => b.Tier)
                      .HasConversion<string>();

                entity.HasOne(b => b.Attendee)
                      .WithOne(a => a.Badge)
                      .HasForeignKey<Badge>(
                          b => b.AttendeeId)
                      .IsRequired();
            });
            modelBuilder.ApplyConfiguration(
               new EventConfiguration());
        }
    }
}
