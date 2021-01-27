using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tamagotchi.Models;

namespace Tamagotchi.Models
{
    public partial class TamagotchiContext
    {
        //Here write general methods to extract root objects from the database!
        public Player GetPlayerByID(int id)
        {
            Player p = this.Players.Where(p => p.PlayerId == id).FirstOrDefault();
            return p;
        }


        public Activity GetActivityTypeByID(int id)
        {
            Activity at = this.Activities.Single(item => item.ActivityId == id);
            return at;
        }

        //Log in method. Return a player or null if not succeed!
        public Player Login(string uName, string pswd)
        {
            Player p = this.Players.Where(p => p.UserName == uName && p.Pass == pswd).FirstOrDefault();
            return p;
        }

       
        // Change password method
        public void ChangePass(Player p, string newVal)
        {
            p.Pass = newVal;
            this.Players.Update(p);
            this.SaveChanges();
            Console.WriteLine("Password changed successfully! Press any key to go back");
        }

        //Change username method 
        public void ChangeUserName(Player p, string newVal)
        {
            p.UserName = newVal;
            this.Players.Update(p);
            this.SaveChanges();
            Console.WriteLine("Username changed successfully! Press any key to go back");
        }

        //Change Email method
        public void ChangeEmail(Player p, string newVal)
        {
            p.Email = newVal;
            this.Players.Update(p);
            this.SaveChanges();
            Console.WriteLine("Email changed successfully! Press any key to go back ");
        }


        //Last actions of a specific pet by action type
        public List<Object> LastActions(Player p, int name, int ID)
        {
            int start = 0;
            int end = 0;
            // Defining start and end IDs accoding to the database
            if (name == 1)
            {
                start = 12;
                end = 24;
            }
            if (name == 2)
            {
                start = 6;
                end = 11;
            }
            if (name == 3)
            {
                start = 1;
                end = 5;
            }

            //Creating a list according to the wanted field and the chosen pet
            List<Object> actions = (from PetActivities in p.Pet.PetActivities
                                    where (PetActivities.Activity.ActivityId >= start && PetActivities.Activity.ActivityId <= end)
                                    where PetActivities.PetId == ID
                                    select new
                                    {
                                        Name = PetActivities.Activity.ActivityName,
                                        ActionDate = PetActivities.ActionDate
                                    }).ToList<Object>();
            return actions;
        }



    }
}
