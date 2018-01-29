using DotNetPaging.EF;
using StructureMap;

namespace DotNetPaging.AspNetMvc
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<DotNetPagingDbContext>().Use<DotNetPagingDbContext>();
        }
    }
}