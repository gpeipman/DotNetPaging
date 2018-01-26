using System;

namespace DotNetPaging.EFCore
{
    public class PressRelease
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Body { get; set; }
    }
}
