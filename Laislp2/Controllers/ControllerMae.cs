using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Laislp2.Models;
using System.Linq;

namespace Laislp2.Controllers
{
    [Route("Nascimento/Mae")]
    public class ControllerMae : Controller
    {
        private readonly LaisContext _context;

        [HttpGet]
        public IEnumerable<Mae> GetAll()
        {
            return _context.Maes.ToList();
        }

        [HttpGet("{id}", Name = "Mae")]
        public IActionResult GetById(int id)
        {
            var mae = _context.Maes.FirstOrDefault(m => m.Id == id);
            if (mae == null)
            {
                return NotFound();
            }
            return new ObjectResult(mae);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Mae mae)
        {
            if (mae == null)
            {
                return BadRequest();
            }

            _context.Maes.Add(mae);
            _context.SaveChanges();

            return CreatedAtRoute("Mae", new { id = mae.Id }, mae);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Mae mae)
        {
            if (mae == null || mae.Id != id)
            {
                return BadRequest();
            }

            var ma = _context.Maes.FirstOrDefault(m => m.Id == id);
            if (ma == null)
            {
                return NotFound();
            }

            ma.Nome = mae.Nome;
            ma.IdadeMae = mae.IdadeMae;
            ma.escolaridade = mae.escolaridade;
            ma.EstadoCivil = mae.EstadoCivil;
            ma.QuantFilhosMortos = mae.QuantFilhosMortos;
            ma.QuantFilhosVivos = mae.QuantFilhosVivos;

            _context.Maes.Update(ma);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ma = _context.Maes.FirstOrDefault(m => m.Id == id);
            if (ma == null)
            {
                return NotFound();
            }

            _context.Maes.Remove(ma);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}