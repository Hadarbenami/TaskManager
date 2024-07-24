using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTaskManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcTaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyTaskController : ControllerBase
    {
        private readonly MvcTaskManagerContext _context;

        public MyTaskController(MvcTaskManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MyTask>> PostTask(MyTask myTask)
        {
            _context.Tasks.Add(myTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTasks), new { id = myTask.Id }, myTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var myTask = await _context.Tasks.FindAsync(id);
            if (myTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(myTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
