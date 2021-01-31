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
                    p.Pass = newVal;
                    this.context.Update(p);
                    this.context.SaveChanges();
                    Console.WriteLine("Password changed successfully! Press any key to go back");
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
                    p.UserName = newVal;
                    this.context.Update(p);
                    this.context.SaveChanges();
                    Console.WriteLine("Username changed successfully! Press any key to go back");
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
                    p.Email = newVal;
                    this.context.Update(p);
                    this.context.SaveChanges();
                    Console.WriteLine("Email changed successfully! Press any key to go back");
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
