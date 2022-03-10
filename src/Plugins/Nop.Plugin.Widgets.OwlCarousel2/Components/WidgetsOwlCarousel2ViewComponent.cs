using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.OwlCarousel2.Infrastructure.Cache;
using Nop.Plugin.Widgets.OwlCarousel2.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.OwlCarousel2.Components
{
    [ViewComponent(Name = "WidgetsOwlCarousel2")]
    public class WidgetsOwlCarousel2ViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;

        public WidgetsOwlCarousel2ViewComponent(IStoreContext storeContext,
            IStaticCacheManager staticCacheManager,
            ISettingService settingService,
            IPictureService pictureService,
            IWebHelper webHelper)
        {
            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var nivoSliderSettings = await _settingService.LoadSettingAsync<OwlCarousel2Settings>(store.Id);

            var model = new PublicInfoViewModel
            {
                SlideLg1Url = await GetPictureUrlAsync(nivoSliderSettings.SlideLg1Id),
                SlideSm1Url = await GetPictureUrlAsync(nivoSliderSettings.SlideSm1Id),
                Title1 = nivoSliderSettings.Title1,
                Description1 = nivoSliderSettings.Description1,
                Link1 = nivoSliderSettings.Link1,

                SlideLg2Url = await GetPictureUrlAsync(nivoSliderSettings.SlideLg2Id),
                SlideSm2Url = await GetPictureUrlAsync(nivoSliderSettings.SlideSm2Id),
                Title2 = nivoSliderSettings.Title2,
                Description2 = nivoSliderSettings.Description2,
                Link2 = nivoSliderSettings.Link2,

                SlideLg3Url = await GetPictureUrlAsync(nivoSliderSettings.SlideLg3Id),
                SlideSm3Url = await GetPictureUrlAsync(nivoSliderSettings.SlideSm3Id),
                Title3 = nivoSliderSettings.Title3,
                Description3 = nivoSliderSettings.Description3,
                Link3 = nivoSliderSettings.Link3,
            };

            if (string.IsNullOrEmpty(model.SlideLg1Url) &&
                string.IsNullOrEmpty(model.SlideLg2Url) && 
                string.IsNullOrEmpty(model.SlideLg3Url))
                //no pictures uploaded
                return Content("");

            return View("~/Plugins/Widgets.OwlCarousel2/Views/PublicInfo.cshtml", model);
        }


        protected async Task<string> GetPictureUrlAsync(int pictureId)
        {
            var cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(ModelCacheEventConsumer.PICTURE_URL_MODEL_KEY,
                pictureId, _webHelper.IsCurrentConnectionSecured() ? Uri.UriSchemeHttps : Uri.UriSchemeHttp);

            return await _staticCacheManager.GetAsync(cacheKey, async () =>
            {
                //little hack here. nulls aren't cacheable so set it to ""
                var url = await _pictureService.GetPictureUrlAsync(pictureId, showDefaultPicture: false) ?? "";
                return url;
            });
        }
    }
}
