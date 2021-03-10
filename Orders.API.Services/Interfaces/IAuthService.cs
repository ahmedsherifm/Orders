using System.Threading.Tasks;
using Orders.API.Models.RequestModels;
using Orders.API.Models.ResponseModels;

namespace Orders.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Response> RegisterUser(RegisterModel model);
        Task<Response> RegisterAdmin(RegisterModel model);
        Task<LoginResponse> LoginUser(LoginModel model);

    }
}
