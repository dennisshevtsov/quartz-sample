// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Quartz;
using Quartz.AspNetCore;
using QuartzSample.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddQuartz(configurator =>
{
  JobKey jobFromProgram = new("JobFromProgram");
  configurator.AddJob<SimpleJob>(jobFromProgram);
  configurator.AddTrigger(trigger => trigger.ForJob(jobFromProgram)
                                            .WithIdentity("JobFromProgramTrigger")
                                            .WithCronSchedule("*/10 * * ? * *")); // Run every 10 second

  configurator.UsePersistentStore(options =>
  {
    string? connectionString = builder.Configuration.GetConnectionString("QUARTZ");
    ArgumentNullException.ThrowIfNull(connectionString);

    options.UsePostgres(connectionString);
    options.UseNewtonsoftJsonSerializer();
  });
});
builder.Services.AddQuartzServer();

WebApplication app = builder.Build();
app.MapGet("/", () => "Quartz sample working...");
app.Run();
