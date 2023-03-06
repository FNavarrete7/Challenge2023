using System;
using System.Linq;
using System.Security.Claims;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoLogic _logic;
        public ContactoController(IContactoLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_logic.GetById(id));
        }

        [HttpGet]
        [Route("{page:int}/{rows:int}")]
        public IActionResult GetAll(int page, int rows)
        {
            return Ok(_logic.GetAllContacto(page, rows));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contacto Contacto)
        {
            Int32 userId = Int32.Parse(((ClaimsIdentity)HttpContext.User.Identity).
                            Claims.Where(W => W.Type == ClaimTypes.PrimarySid).FirstOrDefault().Value);
            String rol = ((ClaimsIdentity)HttpContext.User.Identity).
                            Claims.Where(W => W.Type == ClaimTypes.Role).FirstOrDefault().Value;

            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(Contacto, userId));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Contacto Contacto)
        {
            Int32 userId = Int32.Parse(((ClaimsIdentity)HttpContext.User.Identity).
                            Claims.Where(W => W.Type == ClaimTypes.PrimarySid).FirstOrDefault().Value);

            String rol = ((ClaimsIdentity)HttpContext.User.Identity).
                            Claims.Where(W => W.Type == ClaimTypes.Role).FirstOrDefault().Value;

            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Update(Contacto, userId));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Contacto Contacto)
        {
            Int32 userId = Int32.Parse(((ClaimsIdentity)HttpContext.User.Identity).
                            Claims.Where(W => W.Type == ClaimTypes.PrimarySid).FirstOrDefault().Value);

            if (Contacto.Id > 0)
                return Ok(_logic.Delete(Contacto, userId));
            return BadRequest();
        }
    }
}
