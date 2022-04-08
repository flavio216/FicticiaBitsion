using Ficticia_Bitsion.Models;
using Ficticia_Bitsion.Models.Response;
using Ficticia_Bitsion.Models.ViewModels;
using Ficticia_Bitsion.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ficticia_Bitsion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login( User model)
        {
            Response oRespuesta = new Response();

            using (var db = new FicticiaSAContext())
            {
                var user = db.Users.Where(d => d.UsrEmail == model.UsrEmail &&
                                                   d.UsrPassword == model.UsrEmail).FirstOrDefault();
                if (user == null) return null;

                model.UsrEmail = user.UsrEmail;
                model.UsrPassword = user.UsrPassword;
                oRespuesta.Success = 1;

            }
            return Ok(oRespuesta);
        }

            /*  [HttpPost("login")]
              public IActionResult Autentificar([FromBody] AuthRequest model)
              {
                  Response respuesta = new Response();

                  var userresponse = _userService.Auth(model);

                  if (userresponse == null)
                  {
                      respuesta.Success = 0;
                      respuesta.Message = " User or password invalid";
                      return BadRequest(respuesta); // Manda un error de navegador error 400
                  }

                  respuesta.Success = 1;
                  respuesta.Data = userresponse;
                  return Ok(respuesta);
              }*/
        }
}
