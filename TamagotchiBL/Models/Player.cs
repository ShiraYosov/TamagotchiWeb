using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class Player
    {
        public Player()
        {
            Pets = new HashSet<Pet>();
        }

        public int PlayerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PetId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
