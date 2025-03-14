using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Nodes;
using YAFIT.Databases.Classes;
using YAFIT.Databases.Entities;

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
            _useTestEntries = node?["Settings"]?["TestEntries"]?.GetValue<bool?>() ?? false;
            Debug.WriteLine(_useTestEntries);

            FluentConfiguration configuration = Fluently.Configure();

            switch (usedDatabase)
            {
                case "MySQL":
                    configuration = configuration.Database(MySQLConfiguration.Standard.ConnectionString(cs => cs
                    .Database(node?["Databases"]?[usedDatabase]?["Database"]?.ToString() ?? "NULL_DATABASE")
                    .Server(node?["Databases"]?[usedDatabase]?["Server"]?.ToString() ?? "NULL_SERVER")
                    .Username(node?["Databases"]?[usedDatabase]?["Username"]?.ToString() ?? "NULL_USERNAME")
                    .Password(node?["Databases"]?[usedDatabase]?["Password"]?.ToString() ?? "")
                    .Port(int.TryParse(node?["Databases"]?[usedDatabase]?["Port"]?.ToString() ?? "", out int port) == true ? port : 3306))
                        .ShowSql());
                    break;
            }
            //Caching wenn nötig
            if (node?["Settings"]?["Caching"]?.GetValue<bool?>() ?? false == true)
            {
                configuration = configuration
                    .Cache(c => c.UseQueryCache()
                    .UseSecondLevelCache()
                    .ProviderClass<NHibernate.Cache.HashtableCacheProvider>());
            }
            //Mappings für die jeweiligen Entitäten in der Datenbank

            configuration = configuration.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(DefaultCascade.All()))
                .ExposeConfiguration(BuildSchema);

            _sessionFactory = configuration.BuildSessionFactory();
            Debug.WriteLine("Database connection established");
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
            if (UserEntity.GetUserService().GetEntity(x => x.Name == "root") == null)
            {
                UserEntity.GetUserService().Insert(new UserEntity()
                {
                    Name = "root",
                    Password = "root",
                    IsAdmin = true
                });
            }
            if (_useTestEntries == false)
            {
                return true;
            }
            DebugSeedDB seeder = new DebugSeedDB();
            seeder.InsertTestRegisterCode();
            seeder.AddTestUsers();
            seeder.AddAbteilungen();
            seeder.AddFaecher();
            seeder.AddKlassen();
            seeder.AddUmfragenTests();
            return true;
        }

        private bool _useTestEntries = false;
        private static ISessionFactory? _sessionFactory;
        private static SessionManager? _instance;
    }
}
