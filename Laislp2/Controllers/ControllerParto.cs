using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Laislp2.Models;
using System.Linq;

namespace Laislp2.Controllers
{
     [Route("Nascimento/Parto")]
    public class ControllerParto : Controller
    {
        private readonly LaisContext _context;

        public ControllerParto(LaisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Parto> GetAll()
        {
            return _context.Partos.ToList();
        }

        [HttpGet("{id}", Name = "Parto")]
        public IActionResult GetById(int id)
        {
            var par = _context.Partos.FirstOrDefault(p => p.Id == id);
            if (par == null)
            {
                return NotFound();
            }
            return new ObjectResult(par);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Parto pa)
        {
            if (pa == null)
            {
                return BadRequest();
            }

            _context.Partos.Add(pa);
            _context.SaveChanges();

            return CreatedAtRoute("Parto", new { id = pa.Id },pa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Parto pa)
        {
            if (pa == null || pa.Id != id)
            {
                return BadRequest();
            }

            var par = _context.Partos.FirstOrDefault(p => p.Id == id);
            if (par == null)
            {
                return NotFound();
            }

            par.LocalNasci = pa.LocalNasci;
            par.Horario = pa.Horario;

            _context.Partos.Update(par);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var par = _context.Partos.FirstOrDefault(p => p.Id == id);
            if (par == null)
            {
                return NotFound();
            }

            _context.Partos.Remove(par);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}