using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsInAspMvc.Commons.Interfaces
{
    public interface IHttpMethod
    {
       Task<bool> GetTokenAccess(string email, string password);
    }
}
