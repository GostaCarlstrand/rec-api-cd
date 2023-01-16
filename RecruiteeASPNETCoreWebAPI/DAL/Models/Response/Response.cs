namespace RecruiteeASPNETCoreWebAPI.DAL.Models.Response;

public class Response
{
    public Candidate candidate { get; set; }
    public List<Reference> references { get; set; }

    public static implicit operator Response(string v)
    {
        throw new NotImplementedException();
    }
}