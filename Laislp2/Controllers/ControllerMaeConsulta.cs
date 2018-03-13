using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Laislp2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Laislp2.Controllers
{
    [Route("Nascimento/MaeConsulta")]
    public class ControllerMaeConsulta : Controller
    {
        private readonly LaisContext _context;

        public ControllerMaeConsulta(LaisContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MaeConsulta> GetAll()
        {
            return _context.MaeConsultas.ToList();
        }

        [HttpGet("{id}", Name = "MaeConsulta")]
        public IActionResult GetById(int id)
        {
            var mc = _context.MaeConsultas.FirstOrDefault(mco => mco.Id == id);
            if (mc == null)
            {
                return NotFound();
            }
            return new ObjectResult(mc);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MaeConsulta mc)
        {
            if (mc == null)
            {
                return BadRequest();
            }

            _context.MaeConsultas.Add(mc);
            _context.SaveChanges();

            return CreatedAtRoute("MaeConsulta", new { id = mc.Id }, mc);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MaeConsulta mc)
        {
            if (mc == null || mc.Id != id)
            {
                return BadRequest();
            }

            var mcons = _context.MaeConsultas.FirstOrDefault(mco => mco.Id == id);
            if (mcons == null)
            {
                return NotFound();
            }

            mcons.IdMae = mc.IdMae;
            mcons.IdConsulta = mc.IdConsulta;

            _context.MaeConsultas.Update(mcons);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mcons = _context.MaeConsultas.FirstOrDefault(mco => mco.Id == id);
            if (mcons == null)
            {
                return NotFound();
            }

            _context.MaeConsultas.Remove(mcons);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}