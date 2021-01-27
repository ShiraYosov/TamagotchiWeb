using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class Joy
    {
        public Joy()
        {
            PetActivities = new HashSet<PetActivity>();
            Pets = new HashSet<Pet>();
        }

        public int JoyId { get; set; }
        public string Feelings { get; set; }

        public virtual ICollection<PetActivity> PetActivities { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
