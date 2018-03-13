using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Laislp2.Models;
using System.Linq;

namespace Laislp2.Controllers
{

    [Route("Nascimento/Consulta")]
    public class ControllerConsulta : Controller
    {
        private readonly LaisContext _context;

        public ControllerConsulta(LaisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Consulta> GetAll()
        {
            return _context.Consultas.ToList();
        }

        [HttpGet("{id}", Name = "Consulta")]
        public IActionResult GetById(int id)
        {
            var con = _context.Consultas.FirstOrDefault(co => co.Id == id);
            if (con == null)
            {
                return NotFound();
            }
            return new ObjectResult(con);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Consulta con)
        {
            if (con == null)
            {
                return BadRequest();
            }

            _context.Consultas.Add(con);
            _context.SaveChanges();

            return CreatedAtRoute("Consulta", new { id = con.Id }, con);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Consulta con)
        {
            if (con == null || con.Id != id)
            {
                return BadRequest();
            }

            var cons = _context.Consultas.FirstOrDefault(co => co.Id == id);
            if (cons == null)
            {
                return NotFound();
            }

            cons.Gravidez = con.Gravidez;
            cons.TempoGestacao = con.TempoGestacao;
            cons.TipoParto = con.TipoParto;

            _context.Consultas.Update(cons);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cons = _context.Consultas.FirstOrDefault(co => co.Id == id);
            if (cons == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(cons);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}