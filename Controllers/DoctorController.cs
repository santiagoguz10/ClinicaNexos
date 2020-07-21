using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica.Context;
using Clinica.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinica.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext context;

        public DoctorController(HospitalDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        [EnableCors("AllowOrigin,AllowMethod")]
        public IEnumerable<Doctor> Get()
        {
            return context.Doctor.ToList();
        }

        // GET api/<controller>/5
        [EnableCors("AllowOrigin,AllowMethod")]
        public Doctor Get(int id)
        {
            var doctor = context.Doctor.FirstOrDefault(p => p.DoctorId == id);
            return doctor;
        }


        [HttpPost]
        //
        [EnableCors]
        // POST api/<controller>
        public ActionResult Post([FromBody]Doctor doctor)
        {
            try
            {
                context.Doctor.Add(doctor);
                context.SaveChanges();
                return Ok(doctor);
            }
            catch(Exception e) 
            {
                return BadRequest(e);
            }
                        
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Doctor doctor)
        {
            if (doctor.DoctorId == id)
            {
                try
                {
                    context.Entry(doctor).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(doctor);
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
            var doctor = context.Doctor.FirstOrDefault(p => p.DoctorId==id);
            if (doctor != null)
            {
                try
                {
                    context.Doctor.Remove(doctor);
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
