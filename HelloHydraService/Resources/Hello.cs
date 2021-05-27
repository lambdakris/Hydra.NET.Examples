namespace Resources.Hello
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

  [SupportedClass("doc:Hello")]
  public class HelloInfo
  {
    [JsonPropertyName("@id")]
    public Uri Id { get; set; }
    [JsonPropertyName("@type")]
    public string Type { get; set; }
    [JsonPropertyName("@context")]
    public object Context { get; set; }
    
    public string Message { get; set; }
  }

  [ApiController]
  public class HelloController
  {
    [HttpGet("/api/hello")]
    [Operation(typeof(HelloInfo), Title = "Query Hello Info", Method = Method.Get)]
    public IActionResult QueryHelloInfo()
    {
      var info = new HelloInfo 
      {
        Id = new Uri("/api/hello", UriKind.RelativeOrAbsolute),
        Type = "Class",
        Context = new VocabContext<HelloInfo>("/api/doc#").ToObject<ExpandoObject>(),
        Message = "Hello"
      };

      return new OkObjectResult(info);
    }
  }
}