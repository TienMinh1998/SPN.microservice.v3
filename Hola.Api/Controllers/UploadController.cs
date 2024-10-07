using Hola.Core.Model;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;


namespace Hola.Api.Controllers
{
    public class UploadController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadController(IWebHostEnvironment hostEnvironment)
        {

            _hostEnvironment = hostEnvironment;
        }


        [HttpPost("upload-image")]
        public async Task<JsonResponseModel> UploadImage(IFormFile file)
        {
            var response = await UploadFileAsync(file, "image");
            return JsonResponseModel.Success(response);
        }

        [HttpPost("upload/audio")]
        public async Task<JsonResponseModel> UploadAudio(IFormFile file)
        {
            var response = await UploadFileAsync(file, "image");
            return JsonResponseModel.Success(response);
        }
        private async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            try
            {
                var httpRequest = HttpContext.Request;
                if (file.Length > 0)
                {
                    var rootPath = _hostEnvironment.WebRootPath != null ? _hostEnvironment.WebRootPath : _hostEnvironment.ContentRootPath;
                    var pathToSave = Path.Combine(rootPath, folder);
                    Console.WriteLine(pathToSave);
                    if (!Directory.Exists(pathToSave)) Directory.CreateDirectory(pathToSave);
                    string name = DateTime.UtcNow.ToString("ssddMMyyyy") + file.FileName;
                    var url = Path.Combine(Directory.GetCurrentDirectory(), $"image/{name}");
                    var fullPath = Path.Combine(pathToSave, name);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return await Task.FromResult(url);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
