using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test2.Models
{
    public class PetsDbContext : DbContext
    {
        //public DbSet<Musician> Musicians { get; set; }
        //public DbSet<Musician_Track> Musician_Tracks { get; set; }
        //public DbSet<Track> Tracks { get; set; }
        //public DbSet<Album> Albums { get; set; }
        //public DbSet<MusicLabel> MusicLabels { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Volunteer_Pet> Volunteer_Pets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<BreedType> BreedTypes { get; set; }


        public PetsDbContext()
        {

        }

        public PetsDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Volunteer_Pet>(opt =>
            {
                opt.HasKey(opt => opt.IdVolunteer);
                opt.HasKey(opt => opt.IdPet);

                opt.HasOne(p => p.Volunteer)
                    .WithMany(p => p.Volunteer_Pets)
                    .HasForeignKey(p => p.IdVolunteer);

                opt.HasOne(p => p.Pet)
                    .WithMany(p => p.Volunteer_Pets)
                    .HasForeignKey(p => p.IdPet);
            });

            modelBuilder.Entity<Pet>(opt =>
            {
                opt.HasKey(p => p.IdPet);

                opt.Property(p => p.IdPet)
                    .ValueGeneratedOnAdd();

                opt.HasOne(p => p.BreedType)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(p => p.IdBreedType);

                opt.Property(p => p.Name)
                    .HasMaxLength(80)
                    .IsRequired();
            });

            modelBuilder.Entity<BreedType>(opt => 
            {
                opt.HasKey(p => p.IdBreedType);

                opt.Property(p => p.IdBreedType)
                    .ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsRequired();

                opt.Property(p => p.Description)
                   .HasMaxLength(500);
            });

            modelBuilder.Entity<Volunteer>(opt =>
            {
                opt.HasKey(p => p.IdVolounteer);

                opt.Property(p => p.IdVolounteer)
                    .ValueGeneratedOnAdd();

                opt.HasOne(p => p.Supervisor)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(p => p.IdSupervisor);
            });
        }
    }
}