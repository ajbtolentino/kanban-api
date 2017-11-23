using Magenic.Kanban.Api.Data;
using Magenic.Kanban.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magenic.Kanban.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/TaskBoards")]
    public class BoardTaskController : Controller
    {
        private readonly MagenicKanbanApiContext _context;

        public BoardTaskController(MagenicKanbanApiContext context)
        {
            _context = context;
        }

        // GET: api/TaskBoards
        [HttpGet]
        public IEnumerable<BoardTask> GetTaskBoard()
        {
            return _context.BoardTasks;
        }

        // GET: api/TaskBoards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskBoard([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskBoard = await _context.BoardTasks.SingleOrDefaultAsync(m => m.Id == id);

            if (taskBoard == null)
            {
                return NotFound();
            }

            return Ok(taskBoard);
        }

        // PUT: api/TaskBoards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskBoard([FromRoute] Guid id, [FromBody] BoardTask taskBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskBoardExists(id))
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

        // POST: api/TaskBoards
        [HttpPost]
        public async Task<IActionResult> PostTaskBoard([FromBody] BoardTask taskBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BoardTasks.Add(taskBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskBoard", new { id = taskBoard.Id }, taskBoard);
        }

        // DELETE: api/TaskBoards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskBoard([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskBoard = await _context.BoardTasks.SingleOrDefaultAsync(m => m.Id == id);
            if (taskBoard == null)
            {
                return NotFound();
            }

            _context.BoardTasks.Remove(taskBoard);
            await _context.SaveChangesAsync();

            return Ok(taskBoard);
        }

        private bool TaskBoardExists(Guid id)
        {
            return _context.BoardTasks.Any(e => e.Id == id);
        }
    }
}