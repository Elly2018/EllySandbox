using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EllySandboxWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebugViewController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return File("~/DebugViewer.html", "text/html");
        }

        [HttpPost("IsFileExist", Name = "IsFileExist")]
        public JsonResult IsFileExist()
        {
            return System.IO.File.Exists( GetLastestFilePath()) ? new JsonResult(new IsFileExistJson(true)) : new JsonResult(new IsFileExistJson(false));
        }

        [HttpPost("Update", Name = "Update")]
        public JsonResult Update()
        {
            return new JsonResult(new TextJson(System.IO.File.ReadAllLines(GetLastestFilePath())));
        }

        /*
        [HttpPost("CleanAll", Name = "CleanAll")]
        public IActionResult CleanAll()
        {
            
        }

        [HttpPost("DeleteLine", Name = "DeleteLine")]
        public IActionResult DeleteLine(int index)
        {

        }

        [HttpPost("Command", Name = "Command")]
        public IActionResult Command(string command)
        {

        }
        */

        [System.Serializable]
        class TextJson
        {
            public string[] text;

            public TextJson(string[] text)
            {
                this.text = text;
            }
        }

        [System.Serializable]
        class IsFileExistJson
        {
            public bool exist;

            public IsFileExistJson(bool exist)
            {
                this.exist = exist;
            }
        }

        private string GetLastestFilePath()
        {
            return Path.Combine(new string[] {
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Elly Sandbox", "data", "logs", "Lastest log.txt"
                });
        }
    }
}
