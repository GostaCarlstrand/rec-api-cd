using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using RecruiteeASPNETCoreWebAPI.DAL.Models.Response;
using RecruiteeASPNETCoreWebAPI.FormValidation;
using System.Net.Http.Headers;
using System.Text.Json;
using RecruiteeASPNETCoreWebAPI.SL;
using RecruiteeASPNETCoreWebAPI.SL.Enums;




namespace RecruiteeASPNETCoreWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]


public class CandidateController : Controller
{
    private readonly IConfiguration Configuration;

    public CandidateController(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    [HttpPost("/candidates/post-candidate")]
    public IResult PostCandidate([FromServices] ICandidateService service, [FromBody] Application application)
    {
        if (!Validator.isCandidateDataValid(application.candidate))
            return Results.BadRequest();

        var result = service.PostCandidate(application);

        if (result.Result.ServiceResponse == ServiceResponse.BadRequest)
            return Results.BadRequest();

        return Results.Ok(result.Result.CandidateId);
    }
}