using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.OwlCarousel2.Models
{
    public record PublicInfoViewModel : BaseNopModel
    {
        public string SlideLg1Url { get; set; }

        public string SlideSm1Url { get; set; }

        public string Title1 { get; set; }

        public string Description1 { get; set; }

        public string Link1 { get; set; }

        public string SlideLg2Url { get; set; }

        public string SlideSm2Url { get; set; }

        public string Title2 { get; set; }

        public string Description2 { get; set; }

        public string Link2 { get; set; }

        public string SlideLg3Url { get; set; }

        public string SlideSm3Url { get; set; }

        public string Title3 { get; set; }

        public string Description3 { get; set; }

        public string Link3 { get; set; }

    }
}
