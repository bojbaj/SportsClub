using Abp.Application.Services;
using HamVarzeshi.MultiTenancy.Dto;

namespace HamVarzeshi.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

