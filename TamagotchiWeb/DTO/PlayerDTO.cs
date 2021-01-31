using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace TamagotchiWeb.DTO
{
    public class PlayerDTO
    {
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

        public PlayerDTO(Player p) 
        {
            this.PlayerId = p.PlayerId;
            this.FName = p.FName;
            this.LName = p.LName;
            this.UserName = p.UserName;
            this.Pass = p.Pass;
            this.Email = p.Email;
            this.Gender = p.Gender;
            this.BirthDate =p.BirthDate;
            this.PetId = p.PetId;

        }
    }
}
