using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
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

    [HttpPost("/candidates/test-post-candidate")]
    public async Task<IResult> PostTestCandidateAsync()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Y2djTlNRK1pQbDMrTzVpamVhdWl6dz09");
        var data = new StringContent(System.IO.File.ReadAllText("testCandidate.json"), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://api.recruitee.com/c/60851/candidates", data);
        var responseString = await response.Content.ReadAsStringAsync();

        return Results.Ok(responseString);
    }

    [HttpPost("/candidates/post-candidate")]
    public async Task<IResult> PostCandidateAsync([FromBody] Application application)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.GetValue<string>("Bearer"));
        var data = new StringContent(JsonSerializer.Serialize(application), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://api.recruitee.com/c/60851/candidates", data);
        var responseString = await response.Content.ReadAsStringAsync();
        var responseStringJson = JsonSerializer.Serialize(responseString);

        if (response.StatusCode != System.Net.HttpStatusCode.Created)
            return Results.BadRequest();
        else
            return Results.Ok();
    }
}