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
           
        }

        //Change username method 
        public void ChangeUserName(Player p, string newVal)
        {
            p.UserName = newVal;
            this.Players.Update(p);
            this.SaveChanges();
           
        }

        //Change Email method
        public void ChangeEmail(Player p, string newVal)
        {
            p.Email = newVal;
            this.Players.Update(p);
            this.SaveChanges();
           
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

        public string GetStatus(int statusID)
        {
            PetStatus p = this.PetStatuses.Where(s => statusID == s.StatusId).FirstOrDefault();
            string status = p.Status;
            return status;
        }

        public string GetClean(int cleanID)
        {
            Clean p = this.Cleans.Where(s => cleanID == s.CleanId).FirstOrDefault();
            string level = p.CleanLevel;
            return level;
        }

        public string GetJoy(int joyID)
        {
            Joy p = this.Joys.Where(s => joyID == s.JoyId).FirstOrDefault();
            string level = p.Feelings;
            return level;
        }

        public string GetHunger(int HungerID)
        {
            Hunger p = this.Hungers.Where(s => HungerID == s.HungerId).FirstOrDefault();
            string level = p.HungerLevel;
            return level;
        }
    }
}
