using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using System.Net.Http.Headers;

namespace RecruiteeASPNETCoreWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]

public class AttachmentController : Controller
{
    private readonly IConfiguration Configuration;

    public AttachmentController(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    [HttpPost("/attachments/post-attachment/{candidateId}")]
    public async Task<IResult> PostAttachmentAsync([FromForm] Attachment attachment, string candidateId)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.GetValue<string>("Bearer"));
        var data = new MultipartFormDataContent();

        var file = attachment.File;
        if (file != null)
        {
            var fileStreamData = new StreamContent(file.OpenReadStream());
            data.Add(fileStreamData, "attachment[file]", file.FileName);
        }

        data.Add(new StringContent(candidateId), "attachment[candidate_id]");
        var response = await client.PostAsync("https://api.recruitee.com/c/60851/attachments", data);

        if (response.StatusCode != System.Net.HttpStatusCode.Created)
            return Results.BadRequest();
        else
            return Results.Ok();
    }
}