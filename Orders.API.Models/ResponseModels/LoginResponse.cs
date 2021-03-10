using System;

namespace Orders.API.Models.ResponseModels
{
    public class LoginResponse: Response
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
