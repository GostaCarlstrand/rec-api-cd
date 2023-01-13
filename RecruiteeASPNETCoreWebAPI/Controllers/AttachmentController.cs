using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        public static IWebHostEnvironment? _environment;
        public AttachmentController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost]
        public Task<common> Post([FromForm] FileUploadAPI candData)
        {
            common obj = new common();
            obj.LstCustomer = new List<Customer>();
            obj._fileAPI = new FileUploadAPI();

          
            try
            {                                                              
                if (candData.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "/Upload/"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "/Upload/");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "/Upload/" + candData.files.FileName))
                    {
                        candData.files.CopyTo(filestream);
                        filestream.Flush();
                        //  return "\\Upload\\" + objFile.files.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(obj);
        }
          
    }
}