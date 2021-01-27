using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class Food
    {
        public int FoodId { get; set; }
        public int? SatiatyLevel { get; set; }
        public int? Calories { get; set; }

        public virtual Activity FoodNavigation { get; set; }
    }
}
