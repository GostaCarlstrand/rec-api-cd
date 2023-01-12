using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace RecruiteeASPNETCoreWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]

public class CandidateController : Controller
{
    [HttpPost("/candidates/test-post-candidate")]
    public async Task<IResult> PostCandidateAsync()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Y2djTlNRK1pQbDMrTzVpamVhdWl6dz09");
        var data = new StringContent(System.IO.File.ReadAllText("testCandidate.json"), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://api.recruitee.com/c/60851/candidates", data);
        var responseString = await response.Content.ReadAsStringAsync();

        return Results.Ok(responseString);
    }
}