using FluentValidation;
using Nop.Plugin.Widgets.OwlCarousel2.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.OwlCarousel2.Validators
{
    public class ConfigurationValidator : BaseNopValidator<ConfigurationModel>
    {
        public ConfigurationValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Title1).MaximumLength(40);
            RuleFor(x => x.Description1).MaximumLength(130);
            RuleFor(x => x.Link1).Matches(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");

            RuleFor(x => x.Title2).MaximumLength(40);
            RuleFor(x => x.Description2).MaximumLength(130);
            RuleFor(x => x.Link2).Matches(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");

            RuleFor(x => x.Title3).MaximumLength(40);
            RuleFor(x => x.Description3).MaximumLength(130);
            RuleFor(x => x.Link3).Matches(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$");
        }
    }
}
