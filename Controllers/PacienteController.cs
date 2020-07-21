using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Context;
using Clinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly HospitalDbContext context;
        public PacienteController(HospitalDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            return context.Paciente.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Paciente Get(int id)
        {
            var paciente = context.Paciente.FirstOrDefault(p => p.PacienteId == id);
            return paciente;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Paciente paciente)
        {
            try
            {
                context.Paciente.Add(paciente);
                context.SaveChanges();
                return Ok(paciente);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Paciente paciente)
        {
            if (paciente.PacienteId == id)
            {
                try
                {
                    context.Entry(paciente).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(paciente);
                }
                catch (Exception ex)
                {
                    return NotFound(ex);
                }

            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var paciente = context.Paciente.FirstOrDefault(p => p.PacienteId == id);
            if (paciente != null)
            {
                try
                {
                    context.Paciente.Remove(paciente);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return NotFound(ex);
                }

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
