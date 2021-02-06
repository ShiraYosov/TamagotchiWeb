using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamagotchiWeb.Models
{
    public partial class PetActivity
    {
        [Key]
        [Column("activityID")]
        public int ActivityId { get; set; }
        [Key]
        [Column("petID")]
        public int PetId { get; set; }
        [Key]
        [Column("actionDate", TypeName = "datetime")]
        public DateTime ActionDate { get; set; }
        [Column("cleanID")]
        public int? CleanId { get; set; }
        [Column("joyID")]
        public int? JoyId { get; set; }
        [Column("hungerID")]
        public int? HungerId { get; set; }

        [ForeignKey(nameof(ActivityId))]
        [InverseProperty("PetActivities")]
        public virtual Activity Activity { get; set; }
        [ForeignKey(nameof(CleanId))]
        [InverseProperty("PetActivities")]
        public virtual Clean Clean { get; set; }
        [ForeignKey(nameof(HungerId))]
        [InverseProperty("PetActivities")]
        public virtual Hunger Hunger { get; set; }
        [ForeignKey(nameof(JoyId))]
        [InverseProperty("PetActivities")]
        public virtual Joy Joy { get; set; }
        [ForeignKey(nameof(PetId))]
        [InverseProperty("PetActivities")]
        public virtual Pet Pet { get; set; }
    }
}
