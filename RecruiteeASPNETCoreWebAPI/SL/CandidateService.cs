using Microsoft.Extensions.Configuration;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using RecruiteeASPNETCoreWebAPI.DAL.Models.Response;
using RecruiteeASPNETCoreWebAPI.SL.DTOs;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RecruiteeASPNETCoreWebAPI.SL;

public class CandidateService : ICandidateService
{
    private readonly IConfiguration Configuration;

    public CandidateService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public async Task<CandidateIdReturnServiceResponse> PostCandidate(Application application)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.GetValue<string>("Bearer"));
        var data = new StringContent(JsonSerializer.Serialize(application), System.Text.Encoding.UTF8, "application/json");
        var companyId = Configuration.GetValue<string>("RecAPICompanyId");        
        var response = await client.PostAsync($"https://api.recruitee.com/c/{companyId}/candidates", data);
        var responseString = await response.Content.ReadAsStringAsync();

        var responseObject = JsonSerializer.Deserialize<Response>(responseString);

        if (responseObject == null)
            return new CandidateIdReturnServiceResponse(Enums.ServiceResponse.BadRequest);

        if (response.StatusCode != System.Net.HttpStatusCode.Created)
            return new CandidateIdReturnServiceResponse(Enums.ServiceResponse.BadRequest);

        if (responseObject.candidate.id == null)
            return new CandidateIdReturnServiceResponse(Enums.ServiceResponse.BadRequest);
        
        return new CandidateIdReturnServiceResponse((int)responseObject.candidate.id, Enums.ServiceResponse.Ok);
    }
}
