using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DotNetPaging.NHibernate
{
    public class PressReleaseMap : ClassMapping<PressRelease>
    {
        public PressReleaseMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
            });

            Property(p => p.Company, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(true);
            });

            Property(p => p.ReleaseDate, x =>
            {
                x.Type(NHibernateUtil.Date);
                x.NotNullable(true);
            });

            Property(p => p.Title, x =>
            {
                x.Length(255);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(true);
            });

            Table("PressReleases");
        }
    }
}