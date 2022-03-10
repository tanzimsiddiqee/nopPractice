using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.OwlCarousel2
{
    public class OwlCarousel2Plugin : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;

        public OwlCarousel2Plugin(IWebHelper webHelper, INopFileProvider fileProvider, ILocalizationService localizationService,
            ISettingService settingService, IPictureService pictureService)
        {
            _webHelper = webHelper;
            _fileProvider = fileProvider;
            _localizationService = localizationService;
            _settingService = settingService;
            _pictureService = pictureService;
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsOwlCarousel2";
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsOwlCarousel2/Configure";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //pictures
            var sampleImagesPath = _fileProvider.MapPath("~/Plugins/Widgets.OwlCarousel2/Content/sample-images/");

            //settings
            var settings = new OwlCarousel2Settings()
            {
                SlideLg1Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-1-full.jpg")), MimeTypes.ImagePJpeg, "slide-1-full")).Id,
                SlideSm1Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-1-mobile.jpg")), MimeTypes.ImagePJpeg, "slide-1-mobile")).Id,
                Title1 = "Big choice of <br> Plumbing products",
                Description1 = $"Lorem ipsum dolor sit amet," +
                               $"consectetur adipiscing elit.<br>Etiam pharetra laoreet dui quis" +
                               $"molestie.",
                Link1 = _webHelper.GetStoreLocation(),
                SlideLg2Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-2-full.jpg")), MimeTypes.ImagePJpeg, "slide-2-full")).Id,
                SlideSm2Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-2-mobile.jpg")), MimeTypes.ImagePJpeg, "slide-2-mobile")).Id,
                Title2 = "Screwdrivers<br>Professional Tools",
                Description2 = $"Lorem ipsum dolor sit amet," +
                               $"consectetur adipiscing elit.<br>Etiam pharetra laoreet dui quis" +
                               $"molestie.",
                Link2 = _webHelper.GetStoreLocation(),
                SlideLg3Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-3-full.jpg")), MimeTypes.ImagePJpeg, "slide-3-full")).Id,
                SlideSm3Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-3-mobile.jpg")), MimeTypes.ImagePJpeg, "slide-3-mobile")).Id,
                Title3 = "One more<br>Unique header",
                Description3 = $"Lorem ipsum dolor sit amet," +
                               $"consectetur adipiscing elit.<br>Etiam pharetra laoreet dui quis" +
                               $"molestie.",
                Link3 = _webHelper.GetStoreLocation(),
            };
            await _settingService.SaveSettingAsync(settings);

            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.OwlCarousel2.Slide1"] = "Slide 1",
                ["Plugins.Widgets.OwlCarousel2.Slide2"] = "Slide 2",
                ["Plugins.Widgets.OwlCarousel2.Slide3"] = "Slide 3",
                ["Plugins.Widgets.OwlCarousel2.SlideLg"] = "Large Slide",
                ["Plugins.Widgets.OwlCarousel2.SlideLg.Hint"] = "Upload Slide for Desktop User.",
                ["Plugins.Widgets.OwlCarousel2.SlideSm"] = "Small Slide",
                ["Plugins.Widgets.OwlCarousel2.SlideSm.Hint"] = "Upload Slide for mobile User.",
                ["Plugins.Widgets.OwlCarousel2.Title"] = "Title",
                ["Plugins.Widgets.OwlCarousel2.Title.Hint"] = "Enter Title for slide. Leave empty if you don't want to display any text.",
                ["Plugins.Widgets.OwlCarousel2.Description"] = "Description",
                ["Plugins.Widgets.OwlCarousel2.Description.Hint"] = "Enter Description for slide. Leave empty if you don't want to display any text.",
                ["Plugins.Widgets.OwlCarousel2.Link"] = "URL",
                ["Plugins.Widgets.OwlCarousel2.Link.Hint"] = "Enter URL. Leave empty if you don't want this picture to be clickable."
            });

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            ////settings
            await _settingService.DeleteSettingAsync<OwlCarousel2Settings>();

            ////locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.OwlCarousel2");

            await base.UninstallAsync();
        }

        public bool HideInWidgetList => false;
    }
}
