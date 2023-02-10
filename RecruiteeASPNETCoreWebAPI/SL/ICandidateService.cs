using RecruiteeASPNETCoreWebAPI.DAL.Models;
using RecruiteeASPNETCoreWebAPI.SL.DTOs;

namespace RecruiteeASPNETCoreWebAPI.SL;

public interface ICandidateService
{
    Task<CandidateIdReturnServiceResponse> PostCandidate(Application application);
}
