// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Quartz;

namespace QuartzSample.Web;

public sealed class SimpleJob(ILogger<SimpleJob> logger) : IJob
{
  private readonly ILogger<SimpleJob> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

  public Task Execute(IJobExecutionContext context)
  {
    _logger.LogInformation("Job {JobKey} has been executed.", context.JobDetail.Key.Name);
    return Task.CompletedTask;
  }
}
