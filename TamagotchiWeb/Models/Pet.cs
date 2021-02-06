using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    [Table("Pet")]
    public partial class Pet
    {
        public Pet()
        {
            PetActivities = new HashSet<PetActivity>();
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("petID")]
        public int PetId { get; set; }
        [Column("playerID")]
        public int? PlayerId { get; set; }
        [Required]
        [Column("petName")]
        [StringLength(50)]
        public string PetName { get; set; }
        [Column("hungerID")]
        public int? HungerId { get; set; }
        [Column("joyID")]
        public int? JoyId { get; set; }
        [Column("cleanID")]
        public int? CleanId { get; set; }
        [Column("statusID")]
        public int? StatusId { get; set; }
        [Column("lifeTimeID")]
        public int? LifeTimeId { get; set; }
        [Column("birthDate", TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column("petAge")]
        public double? PetAge { get; set; }
        [Column("petWeight")]
        public double? PetWeight { get; set; }

        [ForeignKey(nameof(CleanId))]
        [InverseProperty("Pets")]
        public virtual Clean Clean { get; set; }
        [ForeignKey(nameof(HungerId))]
        [InverseProperty("Pets")]
        public virtual Hunger Hunger { get; set; }
        [ForeignKey(nameof(JoyId))]
        [InverseProperty("Pets")]
        public virtual Joy Joy { get; set; }
        [ForeignKey(nameof(LifeTimeId))]
        [InverseProperty(nameof(LifeCircle.Pets))]
        public virtual LifeCircle LifeTime { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Pets")]
        public virtual Player Player { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(PetStatus.Pets))]
        public virtual PetStatus Status { get; set; }
        [InverseProperty(nameof(PetActivity.Pet))]
        public virtual ICollection<PetActivity> PetActivities { get; set; }
        [InverseProperty("Pet")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
