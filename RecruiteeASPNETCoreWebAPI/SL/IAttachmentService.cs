using RecruiteeASPNETCoreWebAPI.DAL.Models;
using RecruiteeASPNETCoreWebAPI.SL.DTOs;

namespace RecruiteeASPNETCoreWebAPI.SL
{
    public interface IAttachmentService
    {
        Task<bool> PostAttachment(Attachment attachment, string candidateId);
    }
}
