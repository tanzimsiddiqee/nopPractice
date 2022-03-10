using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.OwlCarousel2.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.OwlCarousel2.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class WidgetsOwlCarousel2Controller : BasePluginController
    {
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;

        public WidgetsOwlCarousel2Controller(IPermissionService permissionService, ISettingService settingService,
            IStoreContext storeContext, IPictureService pictureService, ILocalizationService localizationService,
            INotificationService notificationService)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _pictureService = pictureService;
            _localizationService = localizationService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var owlCarousel2Settings = await _settingService.LoadSettingAsync<OwlCarousel2Settings>(storeScope);
            var model = new ConfigurationModel
            {
                SlideLg1Id = owlCarousel2Settings.SlideLg1Id,
                SlideSm1Id = owlCarousel2Settings.SlideSm1Id,
                Title1 = owlCarousel2Settings.Title1,
                Description1 = owlCarousel2Settings.Description1,
                Link1 = owlCarousel2Settings.Link1,
                SlideLg2Id = owlCarousel2Settings.SlideLg2Id,
                SlideSm2Id = owlCarousel2Settings.SlideSm2Id,
                Title2 = owlCarousel2Settings.Title2,
                Description2 = owlCarousel2Settings.Description2,
                Link2 = owlCarousel2Settings.Link2,
                SlideLg3Id = owlCarousel2Settings.SlideLg3Id,
                SlideSm3Id = owlCarousel2Settings.SlideSm3Id,
                Title3 = owlCarousel2Settings.Title3,
                Description3 = owlCarousel2Settings.Description3,
                Link3 = owlCarousel2Settings.Link3,
                ActiveStoreScopeConfiguration = storeScope
            };

            if (storeScope > 0)
            {
                model.SlideLg1Id_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.SlideLg1Id, storeScope);
                model.SlideSm1Id_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.SlideSm1Id, storeScope);
                model.Title1_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Title1, storeScope);
                model.Description1_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Description1, storeScope);
                model.Link1_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Link1, storeScope);
                model.SlideLg2Id_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.SlideLg2Id, storeScope);
                model.SlideSm2Id_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.SlideSm2Id, storeScope);
                model.Title2_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Title2, storeScope);
                model.Description2_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Description2, storeScope);
                model.Link2_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Link2, storeScope);
                model.SlideLg3Id_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.SlideLg3Id, storeScope);
                model.SlideSm3Id_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.SlideSm3Id, storeScope);
                model.Title3_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Title3, storeScope);
                model.Description3_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Description3, storeScope);
                model.Link3_OverrideForStore = await _settingService.SettingExistsAsync(owlCarousel2Settings, x => x.Link3, storeScope);
            }
            return View("~/Plugins/Widgets.OwlCarousel2/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var owlCarousel2Settings = await _settingService.LoadSettingAsync<OwlCarousel2Settings>(storeScope);

            //get previous picture identifiers
            var previousPictureIds = new[]
            {
                owlCarousel2Settings.SlideLg1Id,
                owlCarousel2Settings.SlideSm1Id,
                owlCarousel2Settings.SlideLg2Id,
                owlCarousel2Settings.SlideSm2Id,
                owlCarousel2Settings.SlideLg3Id,
                owlCarousel2Settings.SlideSm3Id
            };

            owlCarousel2Settings.SlideLg1Id = model.SlideLg1Id;
            owlCarousel2Settings.SlideSm1Id = model.SlideSm1Id;
            owlCarousel2Settings.Title1 = model.Title1;
            owlCarousel2Settings.Description1 = model.Description1;
            owlCarousel2Settings.Link1 = model.Link1;
            owlCarousel2Settings.SlideLg2Id = model.SlideLg2Id;
            owlCarousel2Settings.SlideSm2Id = model.SlideSm2Id;
            owlCarousel2Settings.Title2 = model.Title2;
            owlCarousel2Settings.Description2 = model.Description2;
            owlCarousel2Settings.Link2 = model.Link2;
            owlCarousel2Settings.SlideLg3Id = model.SlideLg3Id;
            owlCarousel2Settings.SlideSm3Id = model.SlideSm3Id;
            owlCarousel2Settings.Title3 = model.Title3;
            owlCarousel2Settings.Description3 = model.Description3;
            owlCarousel2Settings.Link3 = model.Link3;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.SlideLg1Id, model.SlideLg1Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.SlideSm1Id, model.SlideSm1Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.Description1, model.Description1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.Link1, model.Link1_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.SlideLg2Id, model.SlideLg2Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.SlideSm2Id, model.SlideSm2Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.Description2, model.Description2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.Link2, model.Link2_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.SlideLg3Id, model.SlideLg3Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.SlideSm3Id, model.SlideSm3Id_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.Description3, model.Description3_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(owlCarousel2Settings, x => x.Link3, model.Link3_OverrideForStore, storeScope, false);
            //now clear settings cache
            await _settingService.ClearCacheAsync();

            //get current picture identifiers
            var currentPictureIds = new[]
            {
                owlCarousel2Settings.SlideLg1Id,
                owlCarousel2Settings.SlideSm1Id,
                owlCarousel2Settings.SlideLg2Id,
                owlCarousel2Settings.SlideSm2Id,
                owlCarousel2Settings.SlideLg3Id,
                owlCarousel2Settings.SlideSm3Id
            };

            //delete an old picture (if deleted or updated)
            foreach (var pictureId in previousPictureIds.Except(currentPictureIds))
            {
                var previousPicture = await _pictureService.GetPictureByIdAsync(pictureId);
                if (previousPicture != null)
                    await _pictureService.DeletePictureAsync(previousPicture);
            }

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }
    }
}
