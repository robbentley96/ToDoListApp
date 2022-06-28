using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ToDoListAPI
{
    public class CreateTaskItem
    {
        private ITaskService taskService;
        public CreateTaskItem(ITaskService _taskService)
        {
            taskService = _taskService;
        }
        [FunctionName("CreateTaskItem")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] CreateTaskItemInput req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            if (string.IsNullOrWhiteSpace(req.Name) || req.ToDoItemId < 1) { return new BadRequestObjectResult("Please provide a valid name and ToDo id"); }
            await taskService.AddTaskItem(new TaskItem() { Name = req.Name, ToDoItemId = req.ToDoItemId});
            return new OkObjectResult("New Task item added");
        }
    }
}
