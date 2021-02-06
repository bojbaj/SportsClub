using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HamVarzeshi.Localization
{
    public static class HamVarzeshiLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(HamVarzeshiConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HamVarzeshiLocalizationConfigurer).GetAssembly(),
                        "HamVarzeshi.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
