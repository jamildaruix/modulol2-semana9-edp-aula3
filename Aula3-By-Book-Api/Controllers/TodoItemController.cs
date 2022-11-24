using Aula3_By_Book_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aula3_By_Book_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly TodoContext _context;

        /// <summary>
        /// Recebe um DI da tipo TodoContext que ocorreu na configuracao da classe program.cs
        /// Na linha 11.
        /// </summary>
        /// <param name="todoContext"></param>
        public TodoItemController(TodoContext todoContext)
        {
            _context = todoContext;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            var list = _context.TodoItemsDbSet.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(long id)
        {
            var list = _context.TodoItemsDbSet.Where(w => w.Id == id).FirstOrDefault();
            return Ok(list);
        }

        [HttpPost]
        public ActionResult<int> Post(TodoItem todoItem)
        {
            _context.TodoItemsDbSet.Add(todoItem);
            _context.SaveChanges();
            return Ok(todoItem.Id);
        }

        [HttpPut]
        public ActionResult<TodoItem> Put(TodoItem todoItem)
        {
            var item = _context.TodoItemsDbSet.Where(s => s.Id == todoItem.Id).FirstOrDefault();

            if (item != null)
            {
                item.IsComplete = todoItem.IsComplete;
                item.Name = todoItem.Name;

                _context.TodoItemsDbSet.Update(item);
                _context.SaveChanges();
            }

            return Ok(_context.TodoItemsDbSet.Where(s => s.Id == todoItem.Id).FirstOrDefault());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id) 
        {
            if (_context.TodoItemsDbSet.Any(w => w.Id == id))
            {
                var todoItemRemove = _context.TodoItemsDbSet.Where(w => w.Id == id).FirstOrDefault()!;

                _context.TodoItemsDbSet.Remove(todoItemRemove);
                _context.SaveChanges();
            }

            return Ok();
        }

    }
}
