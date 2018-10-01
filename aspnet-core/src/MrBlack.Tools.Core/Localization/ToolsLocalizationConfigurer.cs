using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MrBlack.Tools.Localization
{
    public static class ToolsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ToolsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ToolsLocalizationConfigurer).GetAssembly(),
                        "MrBlack.Tools.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
