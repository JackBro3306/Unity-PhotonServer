using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGameServer.Model;

namespace MyGameServer.Manager {
    interface IUserInfoManager {
        bool Add(UserInfo userinfo);
        void Update(UserInfo userinfo);
        void Delete(UserInfo userinfo);
        bool VerifyUser(string username, string password);
    }
}
