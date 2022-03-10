using Nop.Core;
using Nop.Services.Authentication.External;
using Nop.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.ExternalAuth.Google
{
    public class GoogleAuthenticationMethod : BasePlugin, IExternalAuthenticationMethod
    {
        private readonly IWebHelper _webHelper;

        public GoogleAuthenticationMethod(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        public string GetPublicViewComponentName()
        {
            return GoogleAuthenticationConstants.VIEW_COMPONENT_NAME;
        }

        //public override string GetConfigurationPageUrl()
        //{
        //    return $"{_webHelper.GetStoreLocation()}Admin/GoogleAuthentication/Configure";
        //}

        public override async Task InstallAsync()
        {
            await base.InstallAsync();
        }

        public override Task UninstallAsync()
        {
            return base.UninstallAsync();
        }
    }
}
