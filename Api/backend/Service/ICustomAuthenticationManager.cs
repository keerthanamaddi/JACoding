using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service
{
    public interface ICustomAuthenticationManager
    {
        string Authenticate(string username, string password);

        IDictionary<string, string> Tokens { get; }
    }
}
