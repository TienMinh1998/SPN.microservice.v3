﻿using Hola.Core.Model;
using Hola.GoogleCloudStorage;
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
        public readonly IUploadFileGoogleCloudStorage _GoogleCloudStorage;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadController(IUploadFileGoogleCloudStorage googleCloudStorage, IWebHostEnvironment hostEnvironment)
        {
            _GoogleCloudStorage = googleCloudStorage;
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// Upload file image to Server, Author : Nguyễn Viết Minh Tiến
        /// </summary>
        /// <param name="inputFiles"></param>
        /// <returns></returns>
        [HttpPost("UploadImage")]
        public async Task<JsonResponseModel> UploadFile(IFormFile? inputFiles)
        {

            var filename = inputFiles;
            var filePath = Path.GetTempFileName();
            using (var stream = System.IO.File.Create(filePath))
            {
                // The formFile is the method parameter which type is IFormFile
                // Saves the files to the local file system using a file name generated by the app.
                await inputFiles.CopyToAsync(stream);
            }
            var resultUrl = _GoogleCloudStorage.UploadFile(filePath, "5512421445", inputFiles.FileName, "credentials.json", "image", "image/jpeg");
            return JsonResponseModel.Success(resultUrl);
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