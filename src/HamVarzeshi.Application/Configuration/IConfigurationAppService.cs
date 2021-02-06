using System.Threading.Tasks;
using HamVarzeshi.Configuration.Dto;

namespace HamVarzeshi.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
