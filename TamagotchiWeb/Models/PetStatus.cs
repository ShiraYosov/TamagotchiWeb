using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    [Table("PetStatus")]
    public partial class PetStatus
    {
        public PetStatus()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("statusID")]
        public int StatusId { get; set; }
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }

        [InverseProperty(nameof(Pet.Status))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
