using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace RecruiteeASPNETCoreWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]

public class AttachmentController : ControllerBase
{
    public static IWebHostEnvironment? _environment;
    public AttachmentController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    [HttpPost("/attachment/attach-file")]
    public async Task<IResult> Post([FromForm] FileUploadAPI candData)
    {                             
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
                    await candData.files.CopyToAsync(filestream);
                    filestream.Flush();                        
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return Results.Ok();
    }
      
}