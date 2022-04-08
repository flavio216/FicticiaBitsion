using Ficticia_Bitsion.Models.Response;
using Ficticia_Bitsion.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ficticia_Bitsion.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest request);
    }
}
