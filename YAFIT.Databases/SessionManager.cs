using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace YAFIT.Databases
{
    public class SessionManager
    {

        private SessionManager()
        {
            InitializeSessionFactory();
        }

        public static bool Connect()
        {
            try
            {
                return Instance.Ping();
            }
            catch(Exception e)
            {
                //@TODO: Exception 
            }
            return false;
        }

        public static SessionManager Instance => _instance ??= new SessionManager();
        

        public IStatelessSession OpenStatelessSession()
        {
            return _sessionFactory?.OpenStatelessSession() ?? throw new Exception("Session konnte nicht erstellt werden!");
        }


        private void InitializeSessionFactory()
        {
            FluentConfiguration configuration = Fluently.Configure()
                //Datenbank auswahl
                /* MS SQL */ //.Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost;Database=Test;Trusted_Connection=True;"));
                
                /* SQLite */ //.Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=:memory:;Version=3;New=True;"))
                /* SQLite */ //.Database(SQLiteConfiguration.Standard.UsingFile("nameDerDatenBank.db"))
                
                /* MYSQL  */ .Database(MySQLConfiguration.Standard.ConnectionString(cs => cs.Database("yafit")
                            .Server("10.0.126.13")
                            /* 2001:1640:18e:8000:be24:11ff:fe39:102a */
                            .Username("root")
                            .Password("yafit")//@TODO HASH PASSWORD
                            ))
                //Caching wenn nötig
                .Cache(c => c.UseQueryCache()
                    .UseSecondLevelCache()
                    .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                //Mappings für die jeweiligen Entitäten in der Datenbank
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(BuildSchema)
                ;

            _sessionFactory = configuration.BuildSessionFactory();
        }
        private void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            new NHibernate.Tool.hbm2ddl.SchemaExport(config).Create(false, true);
        }

        private bool Ping()
        {
            return true;
        }


        private static ISessionFactory? _sessionFactory;
        private static SessionManager? _instance;
    }
}
