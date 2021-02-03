using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace TamagotchiWeb.DTO
{
    public class FoodDTO
    {
        public int FoodId { get; set; }
        public int? SatiatyLevel { get; set; }
        public int? Calories { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int? JoyAdd { get; set; }
        public int? CleanAdd { get; set; }       
        public FoodDTO(Food f, Activity a)
        {
            this.FoodId = f.FoodId;
            this.SatiatyLevel = f.SatiatyLevel;
            this.Calories = f.Calories;
            this.ActivityId = a.ActivityId;
            this.ActivityName = a.ActivityName;
            this.JoyAdd = a.JoyAdd;
            this.CleanAdd = a.CleanAdd;
        }
    }
}
