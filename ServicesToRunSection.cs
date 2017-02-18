using System.Configuration;

namespace ServiceStarter
{
    public class ServicesToRunSection : ConfigurationSection
    {
        public const string SectionName = "servicesToRun";

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ServiceEntryCollection ServiceEntryCollection
        {
            get
            {
                return this[""] as ServiceEntryCollection;
            }
        }

        public static ServicesToRunSection GetConfig()
        {
            return ConfigurationManager.GetSection(SectionName) as ServicesToRunSection ?? new ServicesToRunSection();
        }
    }
}