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
    public class DeleteToDoItem
    {
        private IToDoService toDoService;
        public DeleteToDoItem(IToDoService _toDoService)
        {
            toDoService = _toDoService;
        }
        [FunctionName("DeleteToDoItem")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] ToDoItem req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            if (req.Id < 1) { return new BadRequestObjectResult("Valid id must be provided"); }
            await toDoService.DeleteToDoItem(req.Id);
            return new OkObjectResult("To Do successfully deleted");
        }
    }
}
