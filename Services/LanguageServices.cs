using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Reflection;

namespace TriatlonProject.Services
{
    public class SharedResource
    {
    }

    public class LanguageServices
    {
        private IStringLocalizerFactory _localizerFactory;
        private readonly IStringLocalizer _localizer;

        public LanguageServices(IStringLocalizerFactory factory)
        {
            var type= typeof(SharedResource);
            var assemblyName= new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizerFactory = factory;
            _localizer = factory.Create(nameof(SharedResource),assemblyName.Name);
        }






        public string GetTranslation(string key, string culture)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            var localizer = _localizerFactory.Create(nameof(SharedResource), assemblyName.Name);

            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            var localizedString = localizer[key];
            CultureInfo.CurrentCulture = originalCulture;

            return localizedString;
        }
        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}
