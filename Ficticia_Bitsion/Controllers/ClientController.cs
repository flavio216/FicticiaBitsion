using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ficticia_Bitsion.Models.Response;
using Ficticia_Bitsion.Models;
using Ficticia_Bitsion.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Ficticia_Bitsion.Services;

namespace Ficticia_Bitsion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ClientController : Controller
    {
       /* private readonly ClientBusiness _ClientBusiness;

        public ClientController(ClientBusiness clientBusiness)
        {
            this._ClientBusiness = clientBusiness;
        }*/
        //[AllowAnonymous]
        //[HttpGet]

        //public IActionResult GetClients()
        //{
        //    return Ok(_ClientBusiness.ClientList());
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult AddClient([FromBody] Client client)
        //{
        //    _ClientBusiness.CreateClient(client);
        //    return Ok(true);
        //}


        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult UpdateClient([FromBody] Client client)
        //{
        //    _ClientBusiness.UpdateClient(client);
        //    return Ok(true);
        //}

        //[AllowAnonymous]
        //[HttpDelete]
        //public IActionResult DeleteClient(int id)
        //{
        //    _ClientBusiness.DeleteClient(id);
        //    return Ok(true);
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult SearchById(int id)
        //{
        //    return Ok(_ClientBusiness.ClientById(id));
        //}
            [AllowAnonymous]
            [HttpGet]
             public IActionResult GetClients()
             {
                 Response oRespuesta = new Response();
                 try
                 {
                     using (FicticiaSAContext db = new FicticiaSAContext())
                     {

                         var lst = db.Clients.OrderByDescending(d => d.CliId).ToList();
                         oRespuesta.Success = 1;
                         oRespuesta.Data = lst;
                     }
                 }
                 catch (Exception ex)
                 {

                     oRespuesta.Message = ex.Message;
                 }
                 return Ok(oRespuesta);

             }
          [AllowAnonymous]
          [HttpGet]
          [Route("documentType")]
        public IActionResult DocumentType()
            {
                Response oRespuesta = new Response();
                try
                {
                    {
                        using (var db = new FicticiaSAContext())
                        {
                            var lst = db.DocumentTypes.ToList();
                        oRespuesta.Success = 1;
                        oRespuesta.Data = lst;
                        }
                    }
                }
                catch (Exception ex)
                {

                    oRespuesta.Message = ex.Message;
                }
                return Ok(oRespuesta);

            }

        [AllowAnonymous]
             [HttpPost]
             public IActionResult AddClient(ClientRequest oModel)
             {
                 Response oRespuesta = new Response();
                 try
                 {
                     using (FicticiaSAContext db = new FicticiaSAContext())
                     {
                         Client oCliente = new Client();
                         oCliente.CliName = oModel.CliName;
                         oCliente.CliDni = oModel.CliDni;
                         oCliente.CliDocDocumentType = oModel.CliDocDocumentType;
                         oCliente.CliGenGender = oModel.CliGenGender;
                         oCliente.CliDrive = oModel.CliDrive;
                         oCliente.CliUseGlasses = oModel.CliUseGlasses;
                         oCliente.CliDiabetic = oModel.CliDiabetic;
                         oCliente.CliOtherDiseases = oModel.CliOtherDiseases;
                         oCliente.CliDiseases = oModel.CliDiseases;

                         db.Clients.Add(oCliente);
                         db.SaveChanges();
                         oRespuesta.Success = 1;
                     }

                 }
                 catch (Exception ex)
                 {

                     oRespuesta.Message = ex.Message;
                 }
                 return Ok(oRespuesta);
             }
        [AllowAnonymous]
        [HttpPut]
             public IActionResult EditarCliente(ClientRequest oModel)
             {
                 Response oRespuesta = new Response();
                 try
                 {
                     using (FicticiaSAContext db = new FicticiaSAContext())
                     {
                        Client oCliente = db.Clients.Find(oModel.CliId);
                        oCliente.CliName = oModel.CliName;
                        oCliente.CliDni = oModel.CliDni;
                        oCliente.CliDocDocumentType = oModel.CliDocDocumentType;
                        oCliente.CliGenGender = oModel.CliGenGender;
                        oCliente.CliDrive = oModel.CliDrive;
                        oCliente.CliUseGlasses = oModel.CliUseGlasses;
                        oCliente.CliDiabetic = oModel.CliDiabetic;
                        oCliente.CliOtherDiseases = oModel.CliOtherDiseases;
                        oCliente.CliDiseases = oModel.CliDiseases;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                         db.SaveChanges();
                         oRespuesta.Success = 1;
                     }

                 }
                 catch (Exception ex)
                 {

                     oRespuesta.Message = ex.Message;
                 }
                 return Ok(oRespuesta);
             }
        [AllowAnonymous]
        [HttpDelete]
             public IActionResult DeleteClient (int cliId)
             {
                 Response oRespuesta = new Response();
                 try
                 {
                     using (FicticiaSAContext db = new FicticiaSAContext())
                     {
                         Client oCliente = db.Clients.Find(cliId);
                         db.Remove(oCliente);
                         db.SaveChanges();
                         oRespuesta.Success = 1;
                     }

                 }
                 catch (Exception ex)
                 {

                     oRespuesta.Message = ex.Message;
                 }
                 return Ok(oRespuesta);
             }
    }
}
