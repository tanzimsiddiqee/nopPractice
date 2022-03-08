using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.OwlCarousel2.Components
{
    //[ViewComponent(Name = "WidgetsOwlCarousel2")]
    public class WidgetsOwlCarousel2ViewComponent : NopViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View("~/Plugins/Widgets.OwlCarousel2/Views/PublicInfo.cshtml"));
        }
    }
}
