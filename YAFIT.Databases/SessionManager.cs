using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Reflection;

namespace YAFIT.Databases
{
    public class SessionManager
    {

        private SessionManager()
        {
            InitializeSessionFactory();
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
                
                /* MYSQL  */ .Database(MySQLConfiguration.Standard.ConnectionString(cs => cs.Database("test")
                            .Server("localhost")
                            .Username("root")
                            //.Password("pass123")//@TODO HASH PASSWORD
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


        private static ISessionFactory? _sessionFactory;
        private static SessionManager? _instance;
    }
}
