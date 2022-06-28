using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI
{
	public class TaskService : ITaskService
	{
		private ToDoContext context;
		public TaskService(ToDoContext _context)
		{
			context = _context;
		}
		public async Task AddTaskItem(TaskItem taskItem)
		{
			context.TaskItems.Add(taskItem);
			await context.SaveChangesAsync();
		}
		public async Task DeleteTaskItem(int id)
		{
			TaskItem taskItem = await context.TaskItems.Where(x => x.Id == id).FirstOrDefaultAsync();
			context.TaskItems.Remove(taskItem);
			await context.SaveChangesAsync();
		}
	}
}
