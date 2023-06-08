using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Reflection_V2;

namespace ConfigurationManager
{
	public class FileConfigurationProvider : Reflection_V2.IConfigurationProvider
    {
        private readonly IConfigurationRoot configuration;

        public FileConfigurationProvider()
		{
            configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("customconfig.json")
            .Build();
        }

        public object GetSetting(string key, Type type)
        {
            Console.WriteLine("I am file provider get");
            return configuration[key];
        }

        public void SetSetting(string key, string value, Type type)
        {
            Console.WriteLine("I am file provider set");
        }
    }
}

