namespace Resources.EntryPoint
{
  using System;
  using System.Dynamic;
  using System.Threading.Tasks;
  using System.Collections.Generic;
  using System.Text.Json;
  using System.Text.Json.Serialization;
  using Microsoft.AspNetCore.Mvc;
  using JsonLD.Entities.Context;
  using Hydra.NET;

  [SupportedClass("doc:EntryPoint")]
  public class EntryPointInfo
  {
    [JsonPropertyName("@id")]
    public Uri Id { get; set; }

    [JsonPropertyName("@type")]
    public string Type { get; set; }  

    [JsonPropertyName("@context")]
    public Object Context { get; set; }

    public string HelloInfo { get; set; }
  }

  [ApiController]
  public class EntryPointController
  {
    [HttpGet("/api")]
    [Operation(typeof(EntryPointInfo), Title = "Query EntryPoint Info", Method = Method.Get)]
    public IActionResult QueryInfo()
    {
      var info = new EntryPointInfo
      {
        Id = new Uri("/api", UriKind.RelativeOrAbsolute),
        Type = "EntryPoint",
        Context = new VocabContext<EntryPointInfo>("/api/doc#").ToObject<ExpandoObject>(),
        HelloInfo = "/api/hello"
      };

      return new OkObjectResult(info);
    }
  }
}