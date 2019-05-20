using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Repository
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PetTypes> PetTypes { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<PetOwners> PetOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PetTypes>(entity =>
            {
                entity.ToTable("pet_types");
                entity.HasKey(x => x.PetType);

                entity.Property(x => x.PetType)
                .IsRequired()
                .HasColumnName("pet_type");

                entity.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(75)
                .HasColumnName("description");
            });

            modelBuilder.Entity<Owners>(entity =>
            {
                entity.ToTable("owners");
                entity.HasKey(x => x.OwnerId);

                entity.Property(x => x.OwnerId).HasColumnName("owner_id");

                entity.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("first_name");

                entity.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("last_name");

                entity.Property(x => x.MiddleName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("middle_name");

                entity.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("smalldatetime")
                .HasColumnName("date_of_birth");

                entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("email");

                entity.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("address");

                entity.Property(x => x.MobilePhone)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("mobile_phone");

                entity.Property(x => x.HomePhone)
                .HasMaxLength(10)
                .HasColumnName("home_phone");

                entity.Property(x => x.WorkPhone)
                .HasMaxLength(10)
                .HasColumnName("work_phone");
            });

            modelBuilder.Entity<Pets>(entity =>
            {
                entity.ToTable("pets");
                entity.HasKey(x => x.PetId);

                entity.Property(x => x.PetId).HasColumnName("pet_id");

                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");

                entity.Property(x => x.FamilyLasName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("family_last_name");

                entity.Property(x => x.Raise)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("raise");

                entity.Property(x => x.Age)
                .IsRequired()
                .HasColumnName("age");

                entity.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("smalldatetime")
                .HasColumnName("date_of_birth");

                entity.Property(x => x.PetType)
                .IsRequired()
                .HasColumnName("pet_type");

                entity.Property(x => x.Size)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("size");

                entity.HasOne(x => x.PetTypeNavigation)
                .WithMany(x => x.PetsNavigation)
                .HasForeignKey(x => x.PetType)
                .OnDelete(DeleteBehavior.Restrict).HasConstraintName("fk_pets__pet_type");
            });

            modelBuilder.Entity<PetOwners>(entity =>
            {
                entity.ToTable("pet_owners");
                entity.HasKey(x => new { x.PetId, x.OwnerId });

                entity.Property(x => x.PetId)
                .IsRequired()
                .HasColumnName("pet_id");

                entity.Property(x => x.OwnerId)
                .IsRequired()
                .HasColumnName("owner_id");

                entity.HasOne(x => x.PetNavigation)
                .WithMany(x => x.PetOwnersNavigation)
                .HasForeignKey(x => x.PetId).HasConstraintName("fk_pet_owner__pets");

                entity.HasOne(x => x.OwnerNavigation)
                .WithMany(x => x.PetOwnersNavigation)
                .HasForeignKey(x => x.OwnerId).HasConstraintName("fk_pet_owner__owners");
            });

        }
    }
}
