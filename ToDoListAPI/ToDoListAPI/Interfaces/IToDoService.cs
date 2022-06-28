using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI
{
	public interface IToDoService
	{
		public Task AddToDoItem(ToDoItem toDoItem);
		public Task<List<ToDoItem>> GetToDoItems();
		public Task DeleteToDoItem(int id);
	}
}
