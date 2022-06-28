using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI
{
	public class ToDoContext : DbContext
	{
		public ToDoContext(DbContextOptions<ToDoContext> options)
			: base(options)
		{
		}
		public DbSet<ToDoItem> ToDoItems { get; set; }

		public DbSet<TaskItem> TaskItems { get; set; }
	}
}
