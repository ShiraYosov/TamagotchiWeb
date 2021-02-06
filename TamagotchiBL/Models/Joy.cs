using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tamagotchi.Models
{
    [Table("Joy")]
    public partial class Joy
    {
        public Joy()
        {
            PetActivities = new HashSet<PetActivity>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("joyID")]
        public int JoyId { get; set; }
        [Column("feelings")]
        [StringLength(50)]
        public string Feelings { get; set; }

        [InverseProperty(nameof(PetActivity.Joy))]
        public virtual ICollection<PetActivity> PetActivities { get; set; }
        [InverseProperty(nameof(Pet.Joy))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
