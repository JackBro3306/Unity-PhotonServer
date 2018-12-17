using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace MyGameServer {
    class NHibernateHelper {
        private static ISessionFactory _sessionFactory;
        
        private static ISessionFactory SessionFactory {
            get {
                if (_sessionFactory == null) {
                    //获得sessionFactory
                    Configuration configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly("MyGameServer");
                    _sessionFactory = configuration.BuildSessionFactory();
                }

                return NHibernateHelper._sessionFactory; 
            }
            
        }

        public static ISession OpenSessionFactory() {
            return SessionFactory.OpenSession();
        }
        
    }
}
