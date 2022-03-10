using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.ExternalAuth.Google.Components
{
    [ViewComponent(Name = GoogleAuthenticationConstants.VIEW_COMPONENT_NAME)]
    public class GoogleAuthenticationViewComponent : NopViewComponent
    {

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            return View("~/Plugins/ExternalAuth.Google/Views/PublicInfo.cshtml");
        }
    }
}
