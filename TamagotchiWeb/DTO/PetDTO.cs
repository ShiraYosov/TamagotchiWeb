using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace TamagotchiWeb.DTO
{
    public class PetDTO
    {
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

        public PetDTO() { }
        public PetDTO(Pet p)
        {
            this.PetId = p.PetId;
            this.PlayerId = p.PlayerId;
            this.PetName = p.PetName;
            this.HungerId = p.HungerId;
            this.JoyId = p.JoyId;
            this.CleanId = p.CleanId;
            this.StatusId = p.StatusId;
            this.LifeTimeId = p.LifeTimeId;
            this.BirthDate = p.BirthDate;
            this.PetAge = p.PetAge;
            this.PetWeight = p.PetWeight;
        }

       
    }
}
