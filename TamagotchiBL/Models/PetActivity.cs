using System;
using System.Collections.Generic;



namespace Tamagotchi.Models
{
    public partial class PetActivity
    {
        public int ActivityId { get; set; }
        public int PetId { get; set; }
        public DateTime? ActionDate { get; set; }
        public int? CleanId { get; set; }
        public int? JoyId { get; set; }
        public int? HungerId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Clean Clean { get; set; }
        public virtual Hunger Hunger { get; set; }
        public virtual Joy Joy { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
