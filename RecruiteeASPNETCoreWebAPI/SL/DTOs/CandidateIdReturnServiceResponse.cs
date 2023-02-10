using RecruiteeASPNETCoreWebAPI.SL.Enums;

namespace RecruiteeASPNETCoreWebAPI.SL.DTOs;

public class CandidateIdReturnServiceResponse
{
    public CandidateIdReturnServiceResponse(int candidateId, ServiceResponse serviceResponse)
    {
        CandidateId = candidateId;
        ServiceResponse = serviceResponse;
    }

    public CandidateIdReturnServiceResponse(ServiceResponse serviceResponse)
    {
        ServiceResponse = serviceResponse;
    }

    public int CandidateId { get; set; }
    public ServiceResponse ServiceResponse { get; set; }
}
