using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using MyGameServer.Model;
using NHibernate.Criterion;

namespace MyGameServer.Manager {
    class UserInfoManager:IUserInfoManager {

        //添加用户
        public bool Add(Model.UserInfo userinfo) {
            object username = null;
            using (ISession session = NHibernateHelper.OpenSessionFactory()) {
               username = session.Save(userinfo);
            }
            if(username != null)
                return true;
            else
                return false;
        }

        public void Update(Model.UserInfo userinfo) {
            if (userinfo.Id == 0) {
                Console.WriteLine("缺失主键无法更新");
                return;
            }
            using (ISession session = NHibernateHelper.OpenSessionFactory()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    
                    session.Update(userinfo);
                    transaction.Commit();
                }
            }
        }

        public void Delete(Model.UserInfo userinfo) {
            using (ISession session = NHibernateHelper.OpenSessionFactory()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    session.Delete(userinfo);
                    transaction.Commit();
                }
            }
        }

        public bool VerifyUser(string username, string password) {
            UserInfo userinfo = null;
            using (ISession session = NHibernateHelper.OpenSessionFactory()) {
                userinfo = (UserInfo)session.CreateCriteria<UserInfo>()
                    .Add(Restrictions.Eq("Username", username))
                    .Add(Restrictions.Eq("Password", password)).UniqueResult();
            }
            if (userinfo != null)
                return true;
            else
                return false;
        }
    }
}
