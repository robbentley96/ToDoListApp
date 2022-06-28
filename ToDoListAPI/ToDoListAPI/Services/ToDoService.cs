using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI
{
	public class ToDoService : IToDoService
	{
		private ToDoContext context;
		public ToDoService(ToDoContext _context)
		{
			context = _context;
		}
		public async Task AddToDoItem(ToDoItem toDoItem)
		{
			await context.ToDoItems.AddAsync(toDoItem);
			await context.SaveChangesAsync();
		}

		public async Task<List<ToDoItem>> GetToDoItems()
		{
			return await context.ToDoItems.OrderBy(x => x.Id).Include(x => x.TaskItems).ToListAsync();
		}

		public async Task DeleteToDoItem(int id)
		{
			List<TaskItem> taskListToDelete = await context.TaskItems.Where(x => x.ToDoItemId == id).ToListAsync();
			context.TaskItems.RemoveRange(taskListToDelete);
			ToDoItem toDoToDelete = await context.ToDoItems.Where(x => x.Id == id).FirstOrDefaultAsync();
			context.ToDoItems.Remove(toDoToDelete);
			await context.SaveChangesAsync();
		}
	}
}
