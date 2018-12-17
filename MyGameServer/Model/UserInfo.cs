using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameServer.Model {
    public class UserInfo {
        public virtual int Id {get;set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime RegistDate { get; set; }
    }
}
