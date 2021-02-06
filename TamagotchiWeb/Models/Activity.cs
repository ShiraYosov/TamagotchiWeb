using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    public partial class Activity
    {
        public Activity()
        {
            PetActivities = new HashSet<PetActivity>();
        }

        [Key]
        [Column("activityID")]
        public int ActivityId { get; set; }
        [Column("activityName")]
        [StringLength(50)]
        public string ActivityName { get; set; }
        [Column("joyAdd")]
        public int? JoyAdd { get; set; }
        [Column("cleanAdd")]
        public int? CleanAdd { get; set; }

        [InverseProperty("FoodNavigation")]
        public virtual Food Food { get; set; }
        [InverseProperty(nameof(PetActivity.Activity))]
        public virtual ICollection<PetActivity> PetActivities { get; set; }
    }
}
