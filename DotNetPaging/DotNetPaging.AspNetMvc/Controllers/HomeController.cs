using System.Linq;
using System.Web.Mvc;
using DotNetPaging.EF;

namespace DotNetPaging.AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DotNetPagingDbContext _dataContext;

        public HomeController (DotNetPagingDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ActionResult Index(int page = 1)
        {
            var data = _dataContext.PressReleases
                                   .OrderByDescending(p => p.ReleaseDate)
                                   .GetPaged(page, 10);
            return View(data);
        }
    }
}