using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using System.Net.Http.Headers;
using RecruiteeASPNETCoreWebAPI.SL;
using RecruiteeASPNETCoreWebAPI.SL.Enums;
using static System.Net.Mime.MediaTypeNames;


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
    public IResult PostAttachment([FromServices] IAttachmentService service, [FromForm] Attachment attachment, string candidateId)
    {
        var result = service.PostAttachment(attachment, candidateId);

        if (result.Result == false)
            return Results.BadRequest();

        return Results.Ok();
    }
}