using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Tool.hbm2ddl;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Reflection;
using System.Text.Json.Nodes;
using YAFIT.Databases.Classes;

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
            catch (Exception e)
            {
                Console.WriteLine(e);
                Debug.WriteLine(e);
            }
            return false;
        }

        public static SessionManager Instance => _instance ??= new SessionManager();

        public static void Disconnect()
        {
            if (_sessionFactory == null)
            {
                return;
            }
            _sessionFactory.Close();
        }

        public IStatelessSession OpenStatelessSession()
        {
            return _sessionFactory?.OpenStatelessSession() ?? throw new Exception("Session konnte nicht erstellt werden!");
        }

        private string GetConfigurationFilePath()
        {
            string configPath = Path.Combine(Environment.CurrentDirectory, "Configuration");
            string configPathAndName = Path.Combine(configPath, "DatabaseConfig.json");
            if (File.Exists(configPathAndName) == false)
            {
                File.Copy(Path.Combine(configPath, "DatabaseConfigPreset.json"), configPathAndName);
            }
            return configPathAndName;

        }

        private void InitializeSessionFactory()
        {

            string configFile = GetConfigurationFilePath();
            string json = File.ReadAllText(configFile);
            JsonNode? node = JsonNode.Parse(json);

            string? usedDatabase = node?["Using"]?.ToString();
            if (string.IsNullOrEmpty(usedDatabase) == true)
            {
                return;
            }
            FluentConfiguration configuration = Fluently.Configure();

            switch (usedDatabase)
            {
                case "MySQL":
                    configuration = configuration.Database(MySQLConfiguration.Standard.ConnectionString(cs => cs
                    .Database(         node?["Databases"]?[usedDatabase]?["Database"]?.ToString() ?? "NULL_DATABASE")
                    .Server(           node?["Databases"]?[usedDatabase]?["Server"]?.ToString() ?? "NULL_SERVER")
                    .Username(         node?["Databases"]?[usedDatabase]?["Username"]?.ToString() ?? "NULL_USERNAME")
                    .Password(         node?["Databases"]?[usedDatabase]?["Password"]?.ToString() ?? "")
                    .Port(int.TryParse(node?["Databases"]?[usedDatabase]?["Port"]?.ToString() ?? "", out int port) == true ? port : 3306))
                        .ShowSql());
                    break;
            }
            Debug.WriteLine("TESTING: "+ node?["Databases"]?[usedDatabase]?["Database"]?.ToString() ?? "NULL_DATABASE");
            //Caching wenn nötig
            if (bool.TryParse(node?["Settings"]?["Caching"]?.ToString() ?? "", out bool caching) == true)
            {
                if (caching == true)
                {
                    configuration = configuration
                        .Cache(c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>());
                }
            }
            //Mappings für die jeweiligen Entitäten in der Datenbank

            configuration = configuration.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(DefaultCascade.All()))
                .ExposeConfiguration(BuildSchema);

            //FluentConfiguration configuration = Fluently.Configure()
            //    //Datenbank auswahl
            //    /* MS SQL */ //.Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost;Database=Test;Trusted_Connection=True;"));
            //
            //    /* SQLite */ //.Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=:memory:;Version=3;New=True;"))
            //    /* SQLite */ //.Database(SQLiteConfiguration.Standard.UsingFile("nameDerDatenBank.db"))
            //
            //    /* MYSQL  */ .Database(MySQLConfiguration.Standard.ConnectionString(cs => cs.Database("yafit")
            //                .Server("10.0.126.13")
            //                /* 2001:1640:18e:8000:be24:11ff:fe39:102a */
            //                .Username("root")
            //                .Password("yafit")//@TODO HASH PASSWORD
            //                ).ShowSql()
            //    )
            //    //Caching wenn nötig
            //    .Cache(c => c.UseQueryCache()
            //        .UseSecondLevelCache()
            //        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
            //    //Mappings für die jeweiligen Entitäten in der Datenbank
            //    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
            //        .Conventions.Add(DefaultCascade.All()))
            //    .ExposeConfiguration(BuildSchema)
            //    ;


            _sessionFactory = configuration.BuildSessionFactory();
        }
        private void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            try
            {
                new SchemaValidator(config).Validate();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fluent Nhibernate SchemaValidator: \n" + e.Message);
                Debug.WriteLine("Fluent Nhibernate SchemaValidator: \n" + e.Message);
            }
            try
            {
                new SchemaExport(config).Create(false, true);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fluent Nhibernate SchemaExport: \n" + e.Message);
                Debug.WriteLine("Fluent Nhibernate SchemaExport: \n" + e.Message);
            }

        }

        private bool Ping()
        {
            DebugSeedDB seeder = new DebugSeedDB();
            seeder.CheckAndPutRootUser();
            seeder.InsertTestRegisterCode();
            seeder.CheckAndPutFirstUser();
            seeder.CheckAndPutFirstAbteilung();
            seeder.CheckAndPutFirstFach();
            seeder.CheckAndPutFirstKlasse();
            seeder.PutFirstUserUmfrage();
            return true;
        }


        private static ISessionFactory? _sessionFactory;
        private static SessionManager? _instance;
    }
}
