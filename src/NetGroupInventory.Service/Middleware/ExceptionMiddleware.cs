using Microsoft.AspNetCore.Diagnostics;

namespace NetGroupInventory.Service.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //TODO - need to implement error log mechanism
                    }
                });
            });
        }
    }
}
