using Microsoft.EntityFrameworkCore;

namespace Aula3_By_Book_Api.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItemsDbSet { get; set; }
    }
}
