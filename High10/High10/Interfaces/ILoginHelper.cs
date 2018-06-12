using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.Interfaces {
    public interface ILoginHelper {
        bool IsLoggedIn { get; }
        string Token { get; }
        Task<string> TryLogin(string username, string password);
        Task<bool> TryRegister(string username, string password, string email = null);
    }
}
