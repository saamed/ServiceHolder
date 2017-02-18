using System;
using System.Configuration;

namespace ServiceStarter
{
    public class ServiceEntryCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceEntry();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((ServiceEntry)element).Name;
        }
    }
}