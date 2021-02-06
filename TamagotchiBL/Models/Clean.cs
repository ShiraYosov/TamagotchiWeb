using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class Clean
    {
        public Clean()
        {
            PetActivities = new HashSet<PetActivity>();
            Pets = new HashSet<Pet>();
        }

        public int CleanId { get; set; }
        public string CleanLevel { get; set; }

        
        public virtual ICollection<PetActivity> PetActivities { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
