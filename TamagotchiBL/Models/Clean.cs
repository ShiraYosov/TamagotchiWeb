using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tamagotchi.Models
{
    [Table("Clean")]
    public partial class Clean
    {
        public Clean()
        {
            PetActivities = new HashSet<PetActivity>();
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("cleanID")]
        public int CleanId { get; set; }
        [Column("cleanLevel")]
        [StringLength(50)]
        public string CleanLevel { get; set; }

        [InverseProperty(nameof(PetActivity.Clean))]
        public virtual ICollection<PetActivity> PetActivities { get; set; }
        [InverseProperty(nameof(Pet.Clean))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
