using System;

namespace DotNetPaging.EF
{
    public class PressRelease
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
