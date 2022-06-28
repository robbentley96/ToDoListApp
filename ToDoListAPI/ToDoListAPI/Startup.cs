using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(ToDoListAPI.Startup))]
namespace ToDoListAPI
{
	public class Startup : FunctionsStartup
	{
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<ToDoContext>(options => options.UseInMemoryDatabase(databaseName: "ToDoDb"));
            builder.Services.AddTransient<IToDoService,ToDoService>();
            builder.Services.AddTransient<ITaskService, TaskService>();
        }
    }
}
