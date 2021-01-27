using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class Activity
    {
        public Activity()
        {
            PetActivities = new HashSet<PetActivity>();
        }

        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int? JoyAdd { get; set; }
        public int? CleanAdd { get; set; }

        public virtual Food Food { get; set; }
        public virtual ICollection<PetActivity> PetActivities { get; set; }
    }
}
