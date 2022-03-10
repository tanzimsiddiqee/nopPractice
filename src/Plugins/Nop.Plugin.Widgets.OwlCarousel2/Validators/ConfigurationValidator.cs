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
            RuleFor(x => x.SlideLg1Id).NotNull();
            RuleFor(x => x.Title1).MaximumLength(20);
            RuleFor(x => x.Description1).MaximumLength(60);
            RuleFor(x => x.Link1).Matches(@"^[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$");
        }
    }
}
