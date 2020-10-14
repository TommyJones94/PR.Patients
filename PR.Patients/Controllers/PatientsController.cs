using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR.Patients.Model;

namespace PR.Patients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PrDataContext _context;

        public PatientsController(PrDataContext context)
        {
            _context = context;
        }
        public IActionResult GetAll()
        {
            return Ok(_context.Patients.ToList());
        }

        [HttpPost]
        public IActionResult Register(Patient p)
        {
            _context.Patients.Add(p);
            _context.SaveChanges();

            return Created(uri: "/api/Patients/", p);

        }

    }
}
