using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using RecruiteeASPNETCoreWebAPI.DAL.Models.Response;
using System.Net.Http.Headers;
using System.Text.Json;

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
    public async Task<IResult> PostCandidateAsync([FromBody] Application application)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.GetValue<string>("Bearer"));
        var data = new StringContent(JsonSerializer.Serialize(application), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://api.recruitee.com/c/60851/candidates", data);
        var responseString = await response.Content.ReadAsStringAsync();

        var responseObject = JsonSerializer.Deserialize<Response>(responseString);

        var candidateId = responseObject.candidate.id;

        if (response.StatusCode != System.Net.HttpStatusCode.Created)
            return Results.BadRequest();
        else
            return Results.Ok(candidateId);
    }
}