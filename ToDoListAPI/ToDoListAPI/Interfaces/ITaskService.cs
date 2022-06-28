using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI
{
	public interface ITaskService
	{
		public Task AddTaskItem(TaskItem taskItem);
		public Task DeleteTaskItem(int id);
	}
}
