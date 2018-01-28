using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotNetPaging.AspNetCore.Models;
using DotNetPaging.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace DotNetPaging.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DotNetPagingDbContext _dataContext;

        public HomeController(DotNetPagingDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index(int page = 1)
        {
            var releases = _dataContext.PressReleases
                                       .OrderByDescending(p => p.ReleaseDate)
                                       .GetPaged(page, 10);

            return View(releases);
        }

        public async Task<IActionResult> Async(int page = 1)
        {
            var releases = await _dataContext.PressReleases
                                             .OrderByDescending(p => p.ReleaseDate)
                                             .GetPagedAsync(page, 10);

            return View(releases);
        }

        public async Task<IActionResult> AutoMapper(int page = 1)
        {
            var releases = await _dataContext.PressReleases
                                             .OrderByDescending(p => p.ReleaseDate)
                                             .GetPagedAsync<PressRelease, PressReleaseListItem>(page, 10);
            return View(releases);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
