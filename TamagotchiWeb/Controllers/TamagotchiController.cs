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

        public TamagotchiController(TamagotchiContext context)
        {
            this.context = context;
        }

        [Route("GetAnimalList")]
        [HttpGet]
        public List<PetDTO> GetAnimalList()
        {
            PlayerDTO player = HttpContext.Session.GetObject<PlayerDTO>("player");

            if(player != null)
            {
                Player p = context.Players.Where(pl => pl.PlayerId == player.PlayerId).FirstOrDefault();
                List<PetDTO> list = new List<PetDTO>();

                if(p != null)
                {
                    foreach(Pet pet in p.Pets)
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
                if(p != null)
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
        public Task<List<Food>> PrintFood()
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if(pDTO != null)
            {

            }
        }

        public void Feed(int num)
        {
            PlayerDTO pDTO = HttpContext.Session.GetObject<PlayerDTO>("player");
            if (pDTO != null)
            {
                
            }
        }

        [Route("ChangePass")]
        [HttpGet]
        public void ChangePass(string newVal)
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
        public void ChangeUserName(string newVal)
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
        public void ChangeEmail(string newVal)
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

    }
}
