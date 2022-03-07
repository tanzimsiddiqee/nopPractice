using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
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
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;

        public OwlCarousel2Plugin(IWebHelper webHelper, ILocalizationService localizationService,
            ISettingService settingService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
            _settingService = settingService;
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
        public override Task InstallAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            //settings
            //await _settingService.DeleteSettingAsync<NivoSliderSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.OwlCarousel2");

            await base.UninstallAsync();
        }

        public bool HideInWidgetList => false;
    }
}
