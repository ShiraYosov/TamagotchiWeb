using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;





namespace Tamagotchi.Models
{
    public partial class TamagotchiContext : DbContext
    {
        public TamagotchiContext()
        {
        }

        public TamagotchiContext(DbContextOptions<TamagotchiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Clean> Cleans { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Hunger> Hungers { get; set; }
        public virtual DbSet<Joy> Joys { get; set; }
        public virtual DbSet<LifeCircle> LifeCircles { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetActivity> PetActivities { get; set; }
        public virtual DbSet<PetStatus> PetStatuses { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server =localhost\\SQLEXPRESS; Database=Tamagotchi;\nTrusted_Connection=true; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(50)
                    .HasColumnName("activityName");

                entity.Property(e => e.CleanAdd).HasColumnName("cleanAdd");

                entity.Property(e => e.JoyAdd).HasColumnName("joyAdd");
            });

            modelBuilder.Entity<Clean>(entity =>
            {
                entity.ToTable("Clean");

                entity.Property(e => e.CleanId).HasColumnName("cleanID");

                entity.Property(e => e.CleanLevel)
                    .HasMaxLength(50)
                    .HasColumnName("cleanLevel");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.FoodId)
                    .ValueGeneratedNever()
                    .HasColumnName("foodID");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.SatiatyLevel).HasColumnName("satiatyLevel");

                entity.HasOne(d => d.FoodNavigation)
                    .WithOne(p => p.Food)
                    .HasForeignKey<Food>(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivitiesFood");
            });

            modelBuilder.Entity<Hunger>(entity =>
            {
                entity.ToTable("Hunger");

                entity.Property(e => e.HungerId).HasColumnName("hungerID");

                entity.Property(e => e.HungerLevel)
                    .HasMaxLength(50)
                    .HasColumnName("hungerLevel");
            });

            modelBuilder.Entity<Joy>(entity =>
            {
                entity.ToTable("Joy");

                entity.Property(e => e.JoyId).HasColumnName("joyID");

                entity.Property(e => e.Feelings)
                    .HasMaxLength(50)
                    .HasColumnName("feelings");
            });

            modelBuilder.Entity<LifeCircle>(entity =>
            {
                entity.HasKey(e => e.LifeTimeId)
                    .HasName("PK__LifeCirc__9E897D895F0DD4C4");

                entity.ToTable("LifeCircle");

                entity.Property(e => e.LifeTimeId).HasColumnName("lifeTimeID");

                entity.Property(e => e.CalForAday).HasColumnName("calForADay");

                entity.Property(e => e.LifeTimeLevel)
                    .HasMaxLength(50)
                    .HasColumnName("lifeTimeLevel");

                entity.Property(e => e.TimeDuration).HasColumnName("timeDuration");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.PetId).HasColumnName("petID");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CleanId).HasColumnName("cleanID");

                entity.Property(e => e.HungerId).HasColumnName("hungerID");

                entity.Property(e => e.JoyId).HasColumnName("joyID");

                entity.Property(e => e.LifeTimeId).HasColumnName("lifeTimeID");

                entity.Property(e => e.PetAge)
                    .HasColumnName("petAge")
                    .HasDefaultValueSql("((0.1))");

                entity.Property(e => e.PetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("petName");

                entity.Property(e => e.PetWeight)
                    .HasColumnName("petWeight")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.PlayerId).HasColumnName("playerID");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.HasOne(d => d.Clean)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.CleanId)
                    .HasConstraintName("FK_CleanPet");

                entity.HasOne(d => d.Hunger)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.HungerId)
                    .HasConstraintName("FK_HungerPet");

                entity.HasOne(d => d.Joy)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.JoyId)
                    .HasConstraintName("FK_JoyPet");

                entity.HasOne(d => d.LifeTime)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.LifeTimeId)
                    .HasConstraintName("FK_LifeCirclePet");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_PlayerPet");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_PetStatusPet");
            });

            modelBuilder.Entity<PetActivity>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId, e.PetId })
                    .HasName("PK__PetActiv__82164EC9C5BB36CA");

                entity.Property(e => e.ActivityId).HasColumnName("activityID");

                entity.Property(e => e.PetId).HasColumnName("petID");

                entity.Property(e => e.ActionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("actionDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CleanId).HasColumnName("cleanID");

                entity.Property(e => e.HungerId).HasColumnName("hungerID");

                entity.Property(e => e.JoyId).HasColumnName("joyID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.PetActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivitiesPetActivities");

                entity.HasOne(d => d.Clean)
                    .WithMany(p => p.PetActivities)
                    .HasForeignKey(d => d.CleanId)
                    .HasConstraintName("FK_CleanPetActivities");

                entity.HasOne(d => d.Hunger)
                    .WithMany(p => p.PetActivities)
                    .HasForeignKey(d => d.HungerId)
                    .HasConstraintName("FK_HungerPetActivities");

                entity.HasOne(d => d.Joy)
                    .WithMany(p => p.PetActivities)
                    .HasForeignKey(d => d.JoyId)
                    .HasConstraintName("FK_JoyPetActivities");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetActivities)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetPetActivities");
            });

            modelBuilder.Entity<PetStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__PetStatu__36257A38A142BF40");

                entity.ToTable("PetStatus");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.HasIndex(e => e.Email, "UQ__Player__AB6E61648528D883")
                    .IsUnique();

                entity.Property(e => e.PlayerId).HasColumnName("playerID");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birthDate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lName");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("pass");

                entity.Property(e => e.PetId).HasColumnName("petID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK_PetPlayer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
