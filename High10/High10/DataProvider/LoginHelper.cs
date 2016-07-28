using High10.Interfaces;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High10.DataProvider {
    public class LoginHelper : ILoginHelper {
        public bool IsLoggedIn { get; private set; }
        public string Token { get; private set; }

        public LoginHelper() {
            IsLoggedIn = false;
            Token = string.Empty;
        }

        public async Task<string> TryLogin(string username, string password) {
            return "Token";
        }

        public async Task<bool> TryRegister(string username, string password, string email = null) {
            return true;
        }
    }
}
