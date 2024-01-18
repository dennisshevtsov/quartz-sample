using Quartz;
using Quartz.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddQuartz(configurator => configurator.UsePersistentStore(options => options.UsePostgres("")));
builder.Services.AddQuartzServer();

WebApplication app = builder.Build();
app.MapGet("/", () => "Quartz sample working...");
app.Run();
