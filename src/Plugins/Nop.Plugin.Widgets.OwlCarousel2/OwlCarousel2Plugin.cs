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
            var settings = new OwlCarousel2Setting()
            {
                SlideLg1Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-1-full.jpg")), MimeTypes.ImagePJpeg, "slide-1-full")).Id,
                SlideSm1Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-1-mobile.jpg")), MimeTypes.ImagePJpeg, "slide-1-mobile")).Id,
                Title1 = "",
                Description1 = "",
                Link1 = _webHelper.GetStoreLocation(),
                SlideLg2Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-2-full.jpg")), MimeTypes.ImagePJpeg, "slide-2-full")).Id,
                SlideSm2Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-2-mobile.jpg")), MimeTypes.ImagePJpeg, "slide-2-mobile")).Id,
                Title2 = "",
                Description2 = "",
                Link2 = _webHelper.GetStoreLocation(),
                SlideLg3Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-3-full.jpg")), MimeTypes.ImagePJpeg, "slide-3-full")).Id,
                SlideSm3Id = (await _pictureService.InsertPictureAsync(await _fileProvider.ReadAllBytesAsync(_fileProvider.Combine(sampleImagesPath, "slide-3-mobile.jpg")), MimeTypes.ImagePJpeg, "slide-3-mobile")).Id,
                Title3 = "",
                Description3 = "",
                Link3 = _webHelper.GetStoreLocation(),
            };
            await _settingService.SaveSettingAsync(settings);

            //await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            //{
            //    ["Plugins.Widgets.NivoSlider.Picture1"] = "Picture 1",
            //    ["Plugins.Widgets.NivoSlider.Picture2"] = "Picture 2",
            //    ["Plugins.Widgets.NivoSlider.Picture3"] = "Picture 3",
            //    ["Plugins.Widgets.NivoSlider.Picture4"] = "Picture 4",
            //    ["Plugins.Widgets.NivoSlider.Picture5"] = "Picture 5",
            //    ["Plugins.Widgets.NivoSlider.Picture"] = "Picture",
            //    ["Plugins.Widgets.NivoSlider.Picture.Hint"] = "Upload picture.",
            //    ["Plugins.Widgets.NivoSlider.Text"] = "Comment",
            //    ["Plugins.Widgets.NivoSlider.Text.Hint"] = "Enter comment for picture. Leave empty if you don't want to display any text.",
            //    ["Plugins.Widgets.NivoSlider.Link"] = "URL",
            //    ["Plugins.Widgets.NivoSlider.Link.Hint"] = "Enter URL. Leave empty if you don't want this picture to be clickable.",
            //    ["Plugins.Widgets.NivoSlider.AltText"] = "Image alternate text",
            //    ["Plugins.Widgets.NivoSlider.AltText.Hint"] = "Enter alternate text that will be added to image."
            //});

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            ////settings
            await _settingService.DeleteSettingAsync<OwlCarousel2Setting>();

            ////locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.OwlCarousel2");

            await base.UninstallAsync();
        }

        public bool HideInWidgetList => false;
    }
}
