using ASPNETCoreWebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
namespace ASPNETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment? _environment;
        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost]
        public Task<common> Post([FromForm] FileUploadAPI objFile)
        {
            common obj = new common();
            obj.LstCustomer = new List<Customer>();
            obj._fileAPI = new FileUploadAPI();
            try
            {
                
                
                obj._fileAPI.ImgID = objFile.ImgID;
                obj._fileAPI.ImgName = "\\Upload\\" + objFile.files.FileName;
                

                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "/Upload/"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "/Upload/");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "/Upload/" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(filestream);
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


        public void PostCandidateData()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Y2djTlNRK1pQbDMrTzVpamVhdWl6dz09");
            var data = new StringContent(System.IO.File.ReadAllText("testCandidate.json"), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api.recruitee.com/c/60851/candidates", data);
            var responseString = await response.Content.ReadAsStringAsync();

            
        }

        public bool PostCandidateResume()
        {
            return true;
        }
    }


}