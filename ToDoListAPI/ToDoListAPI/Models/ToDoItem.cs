using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListAPI
{
	public class ToDoItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<TaskItem> TaskItems { get; set; }
	}
}
