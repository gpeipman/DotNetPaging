using System.Linq;
using System.Threading.Tasks;
using DotNetPaging.NHibernate;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace DotNetPaging.AspNetCore.Controllers
{
    public class NHibernateController : Controller
    {
        private readonly ISession _nhibernateSession;

        public NHibernateController(ISession nhibernateSession)
        {
            _nhibernateSession = nhibernateSession;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var releases = await _nhibernateSession.Query<PressRelease>()
                                                   .OrderByDescending(p => p.ReleaseDate)
                                                   .GetPagedAsync(page, 10);
            return View(releases);
        }

        public async Task<IActionResult> ICriteria(int page = 1)
        {
            var releases = await _nhibernateSession.CreateCriteria<PressRelease>()
                                                   .GetPagedAsync<PressRelease>(page, 10);

            return View(releases);
        }

        public async Task<IActionResult> QueryOver(int page = 1)
        {
            var releases = await _nhibernateSession.QueryOver<PressRelease>()
                                                   .GetPagedAsync<PressRelease>(page, 10);

            return View(releases);
        }
    }
}