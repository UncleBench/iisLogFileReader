using Api.Models;
using IisLogFileParser;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Api.LogInfoControllers
{
  public class LogInfoController : Controller
  {
    private readonly ILogFileParser _logFileParser;

    public LogInfoController(ILogFileParser logFileParser)
    {
      _logFileParser = logFileParser;
    }

    [HttpGet]
    public async Task<JObject> Get()
    {
      // Todo: Chunked file upload in frontend...
      var result = await _logFileParser.Parse(new System.IO.FileInfo("E:\\Downloads\\INGTES-Assessment-DE\\u_ex201203.log"));
      var model = new LogInfoViewModel
      {
        LogEntries = result
      };

      var serializer = new JsonSerializer
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      };
      var jobj = JObject.FromObject(model, serializer);

      return jobj;
    }
  }
}
