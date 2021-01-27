using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class LifeCircle
    {
        public LifeCircle()
        {
            Pets = new HashSet<Pet>();
        }

        public int LifeTimeId { get; set; }
        public string LifeTimeLevel { get; set; }
        public int? CalForAday { get; set; }
        public int? TimeDuration { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
