namespace Resources.ApiDoc
{
  using System;
  using Microsoft.AspNetCore.Mvc;
  using Hydra.NET;

  using Resources.EntryPoint;
  using Resources.Hello;

  [ApiController]
  public class HelpInfoController
  {
    [HttpGet("/api/doc")]
    public IActionResult GetInfo()
    {
      var info = new ApiDocumentation(new Uri("/api/doc", UriKind.RelativeOrAbsolute));

      info.AddSupportedClass<EntryPointInfo>();
      info.AddSupportedClass<HelloInfo>();

      return new OkObjectResult(info);
    }
  }
}