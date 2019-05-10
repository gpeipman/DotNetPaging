using System;

namespace DotNetPaging.NHibernate
{
    public class PressRelease
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Company { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
    }
}