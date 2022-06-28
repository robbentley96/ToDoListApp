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
    public class CreateToDoItem
    {
        private IToDoService toDoService;

        public CreateToDoItem(IToDoService _toDoService)
        {
            toDoService = _toDoService;
        }
        [FunctionName("CreateToDoItem")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] CreateToDoItemInput req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            if (string.IsNullOrWhiteSpace(req.Name)) { return new BadRequestObjectResult("Valid name must be provided"); }
            await toDoService.AddToDoItem(new ToDoItem() { Name = req.Name });
            return new OkObjectResult("New ToDo item added");
        }
    }
}
