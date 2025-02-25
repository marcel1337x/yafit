using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAFIT.Databases.Entities;
using YAFIT.Databases.Services;

namespace YAFIT.Databases.Classes
{
    public class Authentication
    {
        private string _username;
        private string _password;
        private UserEntity _user;
        
        public Authentication(string username, string password) 
        {
            this._username = username;
            this._password = password;
        }

        public UserEntity DoLogin()
        {
            UserService userService = new UserService();
            UserEntity? user = userService.GetEntity(x => x.Name == _username);
            if(user == null)
            {
                throw new Exception("Eintrag mit Namen " + _username + " existiert nicht!");
            }
            return _user;
        }

        public bool DoLogout()
        {
            // TODO: (?) Selbstverweis löschen
            _username = "logout";
            _password = "logout";
            return true;
        }
    }
}
