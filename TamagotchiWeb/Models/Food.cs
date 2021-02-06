using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    [Table("Food")]
    public partial class Food
    {
        [Key]
        [Column("foodID")]
        public int FoodId { get; set; }
        [Column("satiatyLevel")]
        public int? SatiatyLevel { get; set; }
        [Column("calories")]
        public int? Calories { get; set; }

        [ForeignKey(nameof(FoodId))]
        [InverseProperty(nameof(Activity.Food))]
        public virtual Activity FoodNavigation { get; set; }
    }
}
