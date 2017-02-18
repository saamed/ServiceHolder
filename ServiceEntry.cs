using System.Configuration;

namespace ServiceStarter
{
    public class ServiceEntry : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["Name"] as string; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("Path", IsKey = false, IsRequired = true)]
        public string Path
        {
            get { return this["Path"] as string; }
            set { this["Path"] = value; }
        }

        [ConfigurationProperty("Params", IsKey = false, IsRequired = false)]
        public string Params
        {
            get { return this["Params"] as string; }
            set { this["Params"] = value; }
        }
    }
}