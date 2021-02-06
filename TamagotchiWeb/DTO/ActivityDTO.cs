using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace TamagotchiWeb.DTO
{
    public class ActivityDTO
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int? JoyAdd { get; set; }
        public int? CleanAdd { get; set; }

        public ActivityDTO(Activity a)
        {
            this.ActivityId = a.ActivityId;
            this.ActivityName = a.ActivityName;
            this.JoyAdd = a.JoyAdd;
            this.CleanAdd = a.CleanAdd;
        }
    }
}
