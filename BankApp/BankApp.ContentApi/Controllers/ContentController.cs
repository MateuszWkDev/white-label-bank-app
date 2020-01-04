using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace BankApp.ContentApi.Controllers
{
    [ApiController]
    [Route("content")]
    public class ContentController : ControllerBase
    {
        public const string DefaultLang = "en";
        public const string DefaultFile = "default";
        public const string RootFolder = "wwwroot";
        private readonly IWebHostEnvironment environment;

        public ContentController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [ResponseCache(Duration = 31536000, Location = ResponseCacheLocation.Any, NoStore = false)]
        [HttpGet("main/{version}")]
        public async Task<IActionResult> GetMainContent(string company)
        {
            return Content(await GetMergedDataByCompany("content", company), new MediaTypeHeaderValue("application/json"));
        }

        [ResponseCache(Duration = 31536000, Location = ResponseCacheLocation.Client, NoStore = false)]
        [HttpGet("labels/{version}")]
        public async Task<IActionResult> GetLabels(string lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                lang = DefaultLang;
            }

            return Content(await GetFileContent($"{RootFolder}\\content.{lang}.json"), new MediaTypeHeaderValue("application/json"));
        }

        [ResponseCache(Duration = 31536000, Location = ResponseCacheLocation.Client, NoStore = false)]
        [HttpGet("theme/{version}")]
        public async Task<IActionResult> GetTheme(string company)
        {
            return Content(await GetMergedDataByCompany("theme", company), new MediaTypeHeaderValue("application/json"));
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("last-modified")]
        public IActionResult GetLastModified()
        {
            var folderInfo = environment.ContentRootFileProvider.GetFileInfo(RootFolder);
            return Ok(new { lastModified = folderInfo.LastModified.UtcDateTime.ToString("ddMMyyyyhhmmssfffUTC") });
        }

        private async Task<string> GetFileContent(string fileLocation)
        {
            var fileInfo = environment.ContentRootFileProvider.GetFileInfo(fileLocation);
            using var fileStream = fileInfo.CreateReadStream();
            using var reader = new StreamReader(fileStream);
            return await reader.ReadToEndAsync().ConfigureAwait(false);
        }

        private async Task<string> GetMergedDataByCompany(string fileType, string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                companyName = DefaultFile;
            }

            var defaultContent = JObject.Parse(await GetFileContent($"{RootFolder}\\{fileType}.{DefaultFile}.json"));
            if (companyName != DefaultFile)
            {
                var companyContent = JObject.Parse(await GetFileContent($"{RootFolder}\\{fileType}.{companyName}.json"));
                defaultContent.Merge(companyContent, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Replace,
                });
            }

            return defaultContent.ToString();
        }
    }
}
