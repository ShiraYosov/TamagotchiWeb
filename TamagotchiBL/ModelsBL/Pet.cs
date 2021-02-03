using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tamagotchi.Models;

namespace Tamagotchi.Models
{
    public partial class Pet
    {
        
        public string GetStatus(TamagotchiContext db)
        {
            int sId = (int)this.StatusId;
            IEnumerable<string> s = from ps in db.PetStatuses where (ps.StatusId == sId) select ps.Status;
            return s.FirstOrDefault();
        }

        //Feed animal
        public void Feed(Food f, TamagotchiContext db) 
        {
            //Check pet's hunger level
            if (this.HungerId + f.SatiatyLevel <= Hunger.MAX_HUNGER_LEVEL)
            {
                this.HungerId += f.SatiatyLevel;
            }


            else
            {
                Console.WriteLine("Just to be clear, your pet is now full!");
                this.HungerId = Hunger.MAX_HUNGER_LEVEL;
            }
            Activity act = db.Activities.Where(x => x.ActivityId == f.FoodId).FirstOrDefault();

            //Add to pet's clean level
            if (this.CleanId + act.CleanAdd <= Clean.MAX_CLEAN_LEVEL)
            {
                if (this.CleanId + act.CleanAdd >= Clean.MIN_CLEAN_LEVEL)
                    this.CleanId += act.CleanAdd;
                else
                    this.CleanId = Clean.MIN_CLEAN_LEVEL;
            }
            else
                this.CleanId = Clean.MAX_CLEAN_LEVEL;

            //Add to pet's joy level
            if (this.JoyId + act.JoyAdd <= Joy.MAX_JOY_LEVEL)
                this.JoyId += act.JoyAdd;
            else
                this.JoyId = Joy.MAX_JOY_LEVEL;

            //Add to last activities
            PetActivity pa = new PetActivity();
            pa.ActivityId = act.ActivityId;
            pa.PetId = this.PetId;
            pa.CleanId = this.CleanId;
            pa.JoyId = this.JoyId;
            pa.HungerId = this.HungerId;

            //Save and print 
            db.Pets.Update(this);
            db.PetActivities.Add(pa);
            db.SaveChanges();
            Console.WriteLine("Yummy!");
            Console.WriteLine($"\nYour pet's hunger level is now - {this.Hunger.HungerLevel}");
            Console.WriteLine($"\nYour pet's joy level is now - {this.Joy.Feelings}");
            Console.WriteLine($"\nYour pet's clean level is now - {this.Clean.CleanLevel}"); 
        }

        //Amuse animal
        public void Amuse(Activity toy, TamagotchiContext db)
        {
            //Add to pet's joy level
            if (this.JoyId + toy.JoyAdd <= Joy.MAX_JOY_LEVEL)
            {
                this.JoyId += toy.JoyAdd;
            }

            else
                this.JoyId = Joy.MAX_JOY_LEVEL;

            //Add to pet's clean level
            if (this.CleanId + toy.CleanAdd <= Clean.MAX_CLEAN_LEVEL)
            {
                if(this.CleanId + toy.CleanAdd >= Clean.MIN_CLEAN_LEVEL)
                    this.CleanId += toy.CleanAdd;
                else
                    this.CleanId = Clean.MIN_CLEAN_LEVEL;
            }
            else
                this.CleanId = Clean.MAX_CLEAN_LEVEL;

            //Add to last activities
            PetActivity pa = new PetActivity();
            pa.ActivityId = toy.ActivityId;
            pa.PetId = this.PetId;
            pa.CleanId = this.CleanId;
            pa.JoyId = this.JoyId;
            pa.HungerId = this.HungerId;

            //Save and print 
            db.PetActivities.Add(pa);
            db.Pets.Update(this);
            db.SaveChanges();
            Console.WriteLine("Thanks for playing with me!");
            Console.WriteLine($"\nYour pet's joy level is now - {this.Joy.Feelings}");
            Console.WriteLine($"\nYour pet's clean level is now - {this.Clean.CleanLevel}");
        }

        //Clean animal
        public void Cleaning(Activity a, TamagotchiContext db)
        {
            //Add to pet's clean level
            if (this.CleanId + a.CleanAdd <= Clean.MAX_CLEAN_LEVEL)
            {
                this.CleanId += a.CleanAdd;
            }

            else
                this.CleanId = Clean.MAX_CLEAN_LEVEL;

            //Add to pet's joy level
            if (this.JoyId + a.JoyAdd <= Joy.MAX_JOY_LEVEL)
            {
                if (this.JoyId + a.JoyAdd >= Joy.MIN_JOY_LEVEL)
                {
                    this.JoyId += a.JoyAdd;
                }
                else
                    this.JoyId = Joy.MIN_JOY_LEVEL;
            }
            else
                this.JoyId = Joy.MAX_JOY_LEVEL;

            //Add to last activities
            PetActivity pa = new PetActivity();
            pa.ActivityId = a.ActivityId;
            pa.PetId = this.PetId;
            pa.CleanId = this.CleanId;
            pa.JoyId = this.JoyId;
            pa.HungerId = this.HungerId;

            //Save and print 
            db.PetActivities.Add(pa);
            db.Pets.Update(this);
            db.SaveChanges();
            Console.WriteLine("Thanks for cleaning me!");
            Console.WriteLine($"\nYour pet's clean level is now - {this.Clean.CleanLevel}");
            Console.WriteLine($"\nYour pet's joy level is now - {this.Joy.Feelings}");
            
        }
    }
}
