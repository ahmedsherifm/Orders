using System;
using Orders.API.Models.Models;

namespace Orders.API.Models.ResponseModels
{
    public class LoginResponse: Response
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserModel User { get; set; }
    }
}
