using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetPaging.AspNetCore.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return View("Default", result);
        }
    }
}
