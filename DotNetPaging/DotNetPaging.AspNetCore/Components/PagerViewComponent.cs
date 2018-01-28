using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetPaging.AspNetCore.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            result.LinkTemplate = Url.Action(RouteData.Values["action"].ToString(), new { page = "{0}" }); 

            return View("Default", result);
        }
    }
}
