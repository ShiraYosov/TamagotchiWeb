using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TamagotchiWeb.Models
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
                optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database=Tamagotchi; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.FoodId).ValueGeneratedNever();

                entity.HasOne(d => d.FoodNavigation)
                    .WithOne(p => p.Food)
                    .HasForeignKey<Food>(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivitiesFood");
            });

            modelBuilder.Entity<LifeCircle>(entity =>
            {
                entity.HasKey(e => e.LifeTimeId)
                    .HasName("PK__LifeCirc__9E897D895F0DD4C4");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.BirthDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PetAge).HasDefaultValueSql("((0.1))");

                entity.Property(e => e.PetWeight).HasDefaultValueSql("((3))");

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
                entity.HasKey(e => new { e.ActivityId, e.PetId, e.ActionDate })
                    .HasName("PK_PetActivity");

                entity.Property(e => e.ActionDate).HasDefaultValueSql("(getdate())");

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
            });

            modelBuilder.Entity<Player>(entity =>
            {
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
