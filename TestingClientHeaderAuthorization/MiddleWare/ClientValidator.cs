namespace TestingClientHeaderAuthorization.MiddleWare
{
  public class ClientValidator
  {
    public readonly IConfiguration _configuration;
    public readonly RequestDelegate _next;

    public ClientValidator(RequestDelegate next, IConfiguration config)
    {
      _next = next;
      _configuration = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      if(!context.Request.Headers.TryGetValue("ApiKey", out var apiKey))
      {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Api key needs to be provided.");
        return;
      }

      var ApiKey = _configuration.GetSection("ApiKey");
      if(ApiKey !=null)
      {
        if(ApiKey.Value != apiKey)
        {
          context.Response.StatusCode = 401;
          await context.Response.WriteAsync("UnAuthorized.");
          return;
        }
      }

      await _next(context);
    }
    //public async Task InvokeAsync(HttpContext context, SampleDbContext dbContext)
    //{
    //  var keyValue = context.Request.Query["key"];

    //  if (!string.IsNullOrWhiteSpace(keyValue))
    //  {
    //    dbContext.Requests.Add(new Request("Conventional", keyValue));

    //    await dbContext.SaveChangesAsync();
    //  }

    //  await _next(context);
    //}
  }
}
