using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using Microsoft.AspNetCore.Http;
using TamagotchiWeb.DTO;


namespace TamagotchiWeb.Controllers
{
    [Route("Tamagotchi")]
    [ApiController]
    public class TamagotchiController : ControllerBase
    {
        TamagotchiContext context;
        const int DEAD = 1;

        public TamagotchiController(TamagotchiContext context)
        {
            this.context = context;
        }

        [Route("GetAnimalList")]
        [HttpGet]
        public List<PetDTO> GetAnimalList()
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("player");

            if (player != null)
            {
                Player p = context.Players.Where(pl => pl.PlayerId == player.PlayerId).FirstOrDefault();
                List<PetDTO> list = new List<PetDTO>();

                if (p != null)
                {
                    foreach (Pet pet in p.Pets)
                    {
                        list.Add(new PetDTO(pet));
                    }
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return list;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("GetPetStatus")]
        [HttpGet]
        public string GetPetStatus([FromQuery] int id)
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("player");
            string status = "";

            if (player != null)
            {
                Player p = context.Players.Where(pl => pl.PlayerId == player.PlayerId).FirstOrDefault();
                if (p != null)
                {
                    status = context.GetStatus(id);
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return status;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("GetCleanLevel")]
        [HttpGet]
        public string GetCleanLevel([FromQuery] int id)
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("player");
            string level = "";

            if (player != null)
            {
                Player p = context.Players.Where(pl => pl.PlayerId == player.PlayerId).FirstOrDefault();
                if (p != null)
                {
                    level = context.GetClean(id);
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return level;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("GetHungerLevel")]
        [HttpGet]
        public string GetHungerLevel([FromQuery] int id)
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("player");
            string level = "";

            if (player != null)
            {
                Player p = context.Players.Where(pl => pl.PlayerId == player.PlayerId).FirstOrDefault();
                if (p != null)
                {
                    level = context.GetHunger(id);
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return level;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("GetJoyLevel")]
        [HttpGet]
        public string GetJoyLevel([FromQuery] int id)
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("player");
            string level = "";

            if (player != null)
            {
                Player p = context.Players.Where(pl => pl.PlayerId == player.PlayerId).FirstOrDefault();
                if (p != null)
                {
                    level = context.GetJoy(id);
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return level;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("Login")]
        [HttpGet]
        public PlayerDTO Login([FromQuery] string userName, [FromQuery] string pass)
        {
            Player p = context.Login(userName, pass);

            //Check user name and password
            if (p != null)
            {
                PlayerDTO pDTO = new PlayerDTO(p);

                HttpContext.Session.SetObject("player", pDTO);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("PrintFood")]
        [HttpGet]
        public List<FoodDTO> PrintFood()
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {            
                List<FoodDTO> list = new List<FoodDTO>();
                foreach (Food f in context.Foods)
                {
                    FoodDTO ff = new FoodDTO(f,f.FoodNavigation);
                    list.Add(ff);               
                }
              
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return list;
            }

            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("Feed")]
        [HttpGet]
        public void Feed([FromQuery]int id)
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {
                Player p = context.GetPlayerByID(pDTO.PlayerId);
                Food f = context.Foods.Where(n => n.FoodId == id).FirstOrDefault();
                p.Pets.Where(p => p.StatusId != DEAD).FirstOrDefault().Feed(f, context);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            
            else
            {
              Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
            
        }

        [Route("GetPlayer")]
        [HttpGet]
        public PlayerDTO GetPlayer()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.GetPlayerByID(pDto.PlayerId);
                
                if (p != null)
                {
                    pDto = new PlayerDTO(p);
                    Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return pDto;
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("ChangePass")]
        [HttpGet]
        public void ChangePass([FromQuery]string newVal)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.GetPlayerByID(pDto.PlayerId);

                if (p != null)
                {
                    this.context.ChangePass(p, newVal);
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
        }

        [Route("ChangeUserName")]
        [HttpGet]
        public void ChangeUserName([FromQuery] string newVal)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.GetPlayerByID(pDto.PlayerId);

                if (p != null)
                {
                    this.context.ChangeUserName(p, newVal);
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
        }

        [Route("ChangeEmail")]
        [HttpGet]
        public void ChangeEmail([FromQuery] string newVal)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.GetPlayerByID(pDto.PlayerId);

                if (p != null)
                {
                    this.context.ChangeEmail(p, newVal);
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
        }

        [Route("GetCleanList")]
        [HttpGet]
        public List<ActivityDTO> GetCList()
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");

            //Check if user logged in!
            if (pDTO != null)
            {
                List<ActivityDTO> list = new List<ActivityDTO>();

                foreach (Activity a in context.Activities)
                {
                    list.Add(new ActivityDTO(a));
                }

                
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return list;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("UpdateCleanLevel")]
        [HttpGet]

        public void UpdateCLevel([FromQuery] int cleanId)
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.GetPlayerByID(pDto.PlayerId);
                Activity a = context.Activities.Where(ac => ac.ActivityId == cleanId).FirstOrDefault();

                p.Pets.Where(p => p.StatusId != DEAD).FirstOrDefault().Cleaning(a, context);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            }
        }

        
    }

   

}

