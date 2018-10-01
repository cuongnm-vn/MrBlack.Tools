using Abp.AutoMapper;
using MrBlack.Tools.Authentication.External;

namespace MrBlack.Tools.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
