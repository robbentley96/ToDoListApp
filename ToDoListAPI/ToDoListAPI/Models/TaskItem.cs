using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListAPI
{
	public class TaskItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ToDoItemId { get; set; }
	}
}
