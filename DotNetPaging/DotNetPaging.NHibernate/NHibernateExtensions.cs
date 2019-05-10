using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;

namespace DotNetPaging
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(NHibernateExtensions).Assembly.ExportedTypes);
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Validate;

                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });
            configuration.AddMapping(domainMapping);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddScoped(factory => sessionFactory.OpenSession());

            return services;
        }
    }
}