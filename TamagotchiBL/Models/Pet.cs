using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class Pet
    {
        public Pet()
        {
            PetActivities = new HashSet<PetActivity>();
            Players = new HashSet<Player>();
        }

        public int PetId { get; set; }
        public int? PlayerId { get; set; }
        public string PetName { get; set; }
        public int? HungerId { get; set; }
        public int? JoyId { get; set; }
        public int? CleanId { get; set; }
        public int? StatusId { get; set; }
        public int? LifeTimeId { get; set; }
        public DateTime? BirthDate { get; set; }
        public double? PetAge { get; set; }
        public double? PetWeight { get; set; }

        public virtual Clean Clean { get; set; }
        public virtual Hunger Hunger { get; set; }
        public virtual Joy Joy { get; set; }
        public virtual LifeCircle LifeTime { get; set; }
        public virtual Player Player { get; set; }
        public virtual PetStatus Status { get; set; }
        public virtual ICollection<PetActivity> PetActivities { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
