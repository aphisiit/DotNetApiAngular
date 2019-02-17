using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainDotNetCore.Models.SecureJWT
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
