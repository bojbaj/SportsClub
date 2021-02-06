using System.Threading.Tasks;
using Abp.Application.Services;
using HamVarzeshi.Sessions.Dto;

namespace HamVarzeshi.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
