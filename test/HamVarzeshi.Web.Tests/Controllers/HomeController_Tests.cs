using System.Threading.Tasks;
using HamVarzeshi.Models.TokenAuth;
using HamVarzeshi.Web.Controllers;
using Shouldly;
using Xunit;

namespace HamVarzeshi.Web.Tests.Controllers
{
    public class HomeController_Tests: HamVarzeshiWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}