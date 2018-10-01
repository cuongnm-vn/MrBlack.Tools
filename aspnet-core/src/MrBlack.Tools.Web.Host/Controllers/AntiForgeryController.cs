using Microsoft.AspNetCore.Antiforgery;
using MrBlack.Tools.Controllers;

namespace MrBlack.Tools.Web.Host.Controllers
{
    public class AntiForgeryController : ToolsControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
