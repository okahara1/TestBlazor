#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestBlazor.Server.Data;
using TestBlazor.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class T_memberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public T_memberController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/T_member
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T_member>>> GetT_member()
        {
            return await _context.T_member.ToListAsync();
        }

        // GET: api/T_member/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T_member>> GetT_member(long id)
        {
            var t_member = await _context.T_member.FindAsync(id);

            if (t_member == null)
            {
                return NotFound();
            }

            return t_member;
        }

        // PUT: api/T_member/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutT_member(long id, T_member t_member)
        {
            if (id != t_member.Id)
            {
                return BadRequest();
            }

            _context.Entry(t_member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_memberExists(id))
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

        // POST: api/T_member
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<T_member>> PostT_member(T_member t_member)
        {
            _context.T_member.Add(t_member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetT_member", new { id = t_member.Id }, t_member);
        }

        // DELETE: api/T_member/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteT_member(long id)
        {
            var t_member = await _context.T_member.FindAsync(id);
            if (t_member == null)
            {
                return NotFound();
            }

            _context.T_member.Remove(t_member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool T_memberExists(long id)
        {
            return _context.T_member.Any(e => e.Id == id);
        }
    }
}
