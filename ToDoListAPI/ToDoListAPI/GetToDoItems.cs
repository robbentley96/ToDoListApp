using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ToDoListAPI
{
    public class GetToDoItems
    {
        private IToDoService toDoService;

        public GetToDoItems(IToDoService _toDoService)
        {
            toDoService = _toDoService;
        }

        [FunctionName("GetToDoItems")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<ToDoItem> toDoList = await toDoService.GetToDoItems();
            return new OkObjectResult(toDoList);
        }
    }
}
