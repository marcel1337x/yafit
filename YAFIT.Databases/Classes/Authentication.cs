using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAFIT.Databases.Classes
{
    public class Authentication
    {
        private string _username;
        private string _password;
        public Authentication(string username, string password) 
        {
            this._username = username;
            this._password = password;
        }

        public bool doLogin()
        {
            // TODO: Datenbankverbindung
            if (_username.Equals("abc") && _password.Equals("def"))
            {
                return true;
            }
            return false;
        }

        public bool doLogout()
        {
            // TODO: (?) Selbstverweis löschen
            _username = "logout";
            _password = "logout";
            return true;
        }
    }
}
