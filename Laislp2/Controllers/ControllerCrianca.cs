using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Laislp2.Models;
using System.Linq;

namespace Laislp2.Controllers
{
    [Route("Nascimento/Crianca")]
    public class ControllerCrianca : Controller
    {
        private readonly LaisContext _context;

        [HttpGet]
        public IEnumerable<Crianca> GetAll()
        {
            return _context.Criancas.ToList();
        }

        [HttpGet("{id}", Name = "Crianca")]
        public IActionResult GetById(int id)
        {
            var crianca = _context.Criancas.FirstOrDefault(c => c.Id == id);
            if (crianca == null)
            {
                return NotFound();
            }
            return new ObjectResult(crianca);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Crianca crianca)
        {
            if (crianca == null)
            {
                return BadRequest();
            }

            _context.Criancas.Add(crianca);
            _context.SaveChanges();

            return CreatedAtRoute("GetCrianca", new { id = crianca.Id }, crianca);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Crianca crianca)
        {
            if (crianca == null || crianca.Id != id)
            {
                return BadRequest();
            }

            var cri = _context.Criancas.FirstOrDefault(c => c.Id == id);
            if (cri == null)
            {
                return NotFound();
            }

            cri.Peso = crianca.Peso;
            cri.Sexo = crianca.Sexo;
            cri.Apgar1 = crianca.Apgar1;
            cri.Apgar2 = crianca.Apgar2;

            _context.Criancas.Update(cri);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cri = _context.Criancas.FirstOrDefault(c => c.Id == id);
            if (cri == null)
            {
                return NotFound();
            }

            _context.Criancas.Remove(cri);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}