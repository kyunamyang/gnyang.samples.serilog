using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

[AttributeUsage(AttributeTargets.Class)]
public class CustomLogFilter : ActionFilterAttribute
{
    private readonly Serilog.ILogger _logger;

    public CustomLogFilter()
    {
        _logger = Log.Logger.ForContext<ControllerBase>();
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //check for other kinds of IActionResult if any ...
        //...
        _logger.Information($"{context.ActionDescriptor.DisplayName}");

        await next();

    }

}
