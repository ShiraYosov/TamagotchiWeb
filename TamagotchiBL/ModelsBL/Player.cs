using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Tamagotchi.Models;

namespace Tamagotchi.Models
{
    public partial class Player
    {
        public bool FindPet(int id)
        {
            foreach (Pet p in this.Pets)
            {
                if (p.PetId == id)
                    return true;
            }
            return false;
        }

       
    }
}
