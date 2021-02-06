using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    [Table("LifeCircle")]
    public partial class LifeCircle
    {
        public LifeCircle()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("lifeTimeID")]
        public int LifeTimeId { get; set; }
        [Column("lifeTimeLevel")]
        [StringLength(50)]
        public string LifeTimeLevel { get; set; }
        [Column("calForADay")]
        public int? CalForAday { get; set; }
        [Column("timeDuration")]
        public int? TimeDuration { get; set; }

        [InverseProperty(nameof(Pet.LifeTime))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
