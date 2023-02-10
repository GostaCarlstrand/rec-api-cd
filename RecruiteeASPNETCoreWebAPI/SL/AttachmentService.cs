using RecruiteeASPNETCoreWebAPI.DAL.Models;
using System.Net.Http.Headers;

namespace RecruiteeASPNETCoreWebAPI.SL;

public class AttachmentService : IAttachmentService
{
    private readonly IConfiguration Configuration;

    public AttachmentService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public async Task<bool> PostAttachment(Attachment attachment, string candidateId)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration.GetValue<string>("Bearer"));
        var data = new MultipartFormDataContent();
        var companyId = Configuration.GetValue<string>("RecAPICompanyId");

        var file = attachment.File;
        if (file != null)
        {
            var fileStreamData = new StreamContent(file.OpenReadStream());
            data.Add(fileStreamData, "attachment[file]", file.FileName);
        }


        
        data.Add(new StringContent(candidateId), "attachment[candidate_id]");
        var response = await client.PostAsync($"https://api.recruitee.com/c/{companyId}/attachments", data);

        if (response.StatusCode != System.Net.HttpStatusCode.Created)
            return false;
        else
            return true;
    }
}
