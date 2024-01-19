// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Quartz;
using Quartz.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddQuartz(configurator =>
{
  configurator.UsePersistentStore(options =>
  {
    string connectionString = builder.Configuration.GetConnectionString("QUARTZ") ??
                              throw new ArgumentNullException("QUARTZ");
    options.UsePostgres(connectionString);
    options.UseNewtonsoftJsonSerializer();
  });
});
builder.Services.AddQuartzServer();

WebApplication app = builder.Build();
app.MapGet("/", () => "Quartz sample working...");
app.Run();
