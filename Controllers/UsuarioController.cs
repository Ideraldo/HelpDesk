using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskService.Models;

namespace HelpDeskService.Controllers
{
    [Route("serviceDesk/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly HelpDeskContext _context;

        public UsuarioController(HelpDeskContext context)
        {
            _context = context;
        }

        // GET: serviceDesk/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetUsuarioModel()
        {
          if (_context.usuarioModel == null)
          {
              return NotFound();
          }
            return await _context.usuarioModel.ToListAsync();
        }

        // GET: serviceDesk/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioModel(Guid id)
        {
          if (_context.usuarioModel == null)
          {
              return NotFound();
          }
            var usuarioModel = await _context.usuarioModel.FindAsync(id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return usuarioModel;
        }

        // PUT: serviceDesk/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioModel(Guid id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: serviceDesk/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(UsuarioModel usuarioModel)
        {
          if (_context.usuarioModel == null)
          {
              return Problem("Entity set 'HelpDeskContext.UsuarioModel'  is null.");
          }
            _context.usuarioModel.Add(usuarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.IdUsuario }, usuarioModel);
        }

        // DELETE: serviceDesk/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioModel(Guid id)
        {
            if (_context.usuarioModel == null)
            {
                return NotFound();
            }
            var usuarioModel = await _context.usuarioModel.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            _context.usuarioModel.Remove(usuarioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioModelExists(Guid id)
        {
            return (_context.usuarioModel?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
