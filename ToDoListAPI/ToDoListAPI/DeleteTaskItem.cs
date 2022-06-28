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
    public class DeleteTaskItem
    {
        private ITaskService taskService;
        public DeleteTaskItem(ITaskService _taskService)
        {
            taskService = _taskService;
        }
        [FunctionName("DeleteTaskItem")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] TaskItem req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            if (req.Id < 1) { return new BadRequestObjectResult("Valid Id must be provided"); }
            await taskService.DeleteTaskItem(req.Id);
            return new OkObjectResult($"Task item {req.Id} successfully deleted");
        }
    }
}
