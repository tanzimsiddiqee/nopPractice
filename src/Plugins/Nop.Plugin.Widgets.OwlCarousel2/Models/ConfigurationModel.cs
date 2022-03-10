using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.OwlCarousel2.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        
        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.SlideLg")]
        [UIHint("Picture")]
        public int SlideLg1Id { get; set; }
        public bool SlideLg1Id_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.SlideSm")]
        [UIHint("Picture")]
        public int SlideSm1Id { get; set; }
        public bool SlideSm1Id_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Title")]
        public string Title1 { get; set; }
        public bool Title1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Description")]
        public string Description1 { get; set; }
        public bool Description1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Link")]
        public string Link1 { get; set; }
        public bool Link1_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.SlideLg")]
        [UIHint("Picture")]
        public int SlideLg2Id { get; set; }
        public bool SlideLg2Id_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.SlideSm")]
        [UIHint("Picture")]
        public int SlideSm2Id { get; set; }
        public bool SlideSm2Id_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Title")]
        public string Title2 { get; set; }
        public bool Title2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Description")]
        public string Description2 { get; set; }
        public bool Description2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Link")]
        public string Link2 { get; set; }
        public bool Link2_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.SlideLg")]
        [UIHint("Picture")]
        public int SlideLg3Id { get; set; }
        public bool SlideLg3Id_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.SlideSm")]
        [UIHint("Picture")]
        public int SlideSm3Id { get; set; }
        public bool SlideSm3Id_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Title")]
        public string Title3 { get; set; }
        public bool Title3_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Description")]
        public string Description3 { get; set; }
        public bool Description3_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.OwlCarousel2.Link")]
        public string Link3 { get; set; }
        public bool Link3_OverrideForStore { get; set; }
    }
}