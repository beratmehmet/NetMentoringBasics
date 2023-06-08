using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Reflection
{
	public class ConfigurationManagerConfigurationProvider : IConfigurationProvider
	{
        public object GetSetting(string key, Type Type)
        {
            try
            {
                var appSettings = System.Configuration.ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return null;
            }
        }

        public void SetSetting(string key, object value, Type type)
        {
            Console.WriteLine("sasd");
        }
    }
}

