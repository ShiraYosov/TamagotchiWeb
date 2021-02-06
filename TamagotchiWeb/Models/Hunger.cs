using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    [Table("Hunger")]
    public partial class Hunger
    {
        public Hunger()
        {
            PetActivities = new HashSet<PetActivity>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("hungerID")]
        public int HungerId { get; set; }
        [Column("hungerLevel")]
        [StringLength(50)]
        public string HungerLevel { get; set; }

        [InverseProperty(nameof(PetActivity.Hunger))]
        public virtual ICollection<PetActivity> PetActivities { get; set; }
        [InverseProperty(nameof(Pet.Hunger))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
