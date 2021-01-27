using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class Hunger
    {
        public Hunger()
        {
            PetActivities = new HashSet<PetActivity>();
            Pets = new HashSet<Pet>();
        }

        public int HungerId { get; set; }
        public string HungerLevel { get; set; }

        public virtual ICollection<PetActivity> PetActivities { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
