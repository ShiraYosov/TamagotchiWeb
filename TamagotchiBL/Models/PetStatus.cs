using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class PetStatus
    {
        public PetStatus()
        {
            Pets = new HashSet<Pet>();
        }

        public int StatusId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
