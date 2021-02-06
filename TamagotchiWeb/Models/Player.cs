using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    [Table("Player")]
    [Index(nameof(Email), Name = "UQ__Player__AB6E61648528D883", IsUnique = true)]
    public partial class Player
    {
        public Player()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("playerID")]
        public int PlayerId { get; set; }
        [Required]
        [Column("fName")]
        [StringLength(50)]
        public string FName { get; set; }
        [Required]
        [Column("lName")]
        [StringLength(50)]
        public string LName { get; set; }
        [Required]
        [Column("userName")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [Column("pass")]
        [StringLength(10)]
        public string Pass { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("birthDate", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column("petID")]
        public int? PetId { get; set; }

        [ForeignKey(nameof(PetId))]
        [InverseProperty("Players")]
        public virtual Pet Pet { get; set; }
        [InverseProperty("Player")]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
