﻿using System;
using System.Reflection;
using System.Runtime.Loader;

namespace Reflection_V2
{
	public abstract class ConfigurationComponentBase
	{
        private IConfigurationProvider configurationManagerProvider;
        private IConfigurationProvider fileConfigurationProvider;
		public ConfigurationComponentBase()
		{
            PropertyInfo[] properties = GetType().GetProperties();
            LoadConfigurationProvider();
            foreach (var property in properties)
            {
                object attribute = property.GetCustomAttributes(typeof(ConfigurationItemAttribute), false).FirstOrDefault();

                if (attribute != null)
                {
                    if (property.PropertyType != typeof(int) && property.PropertyType != typeof(float) &&
                        property.PropertyType != typeof(string) && property.PropertyType != typeof(TimeSpan))
                    {
                        throw new InvalidOperationException("ConfigurationItemAttribute can only be applied to int, float, string, and TimeSpan types.");
                    }
                }
            }
        }

        public void LoadSettings()
        {
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var attribute = (ConfigurationItemAttribute)property.GetCustomAttributes(typeof(ConfigurationItemAttribute), true).FirstOrDefault();
                if (attribute != null)
                {
                    if (attribute.GetType() == typeof(ConfigurationManagerConfigurationItemAttribute))
                    {
                        try
                        {
                            var value = configurationManagerProvider.GetSetting(attribute.SettingName, property.PropertyType);
                            property.SetValue(this, value);
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine("File not found");
                        }
                    }
                    else if (attribute.GetType() == typeof(FileConfigurationItemAttribute))
                    {
                        try
                        {
                            var value = fileConfigurationProvider.GetSetting(attribute.SettingName, property.PropertyType);
                            property.SetValue(this, value);
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine("File not found");
                        }
                    }
                }
                //Console.WriteLine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);
            }
        }

        public void SaveSettings()
        {
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var attribute = (ConfigurationItemAttribute)property.GetCustomAttributes(typeof(ConfigurationItemAttribute), true).FirstOrDefault();
                if (attribute != null)
                {
                    if(attribute.GetType() == typeof(ConfigurationManagerConfigurationItemAttribute))
                    {

                    }
                    
                    if (configurationManagerProvider != null)
                    {
                        var value = (string)property.GetValue(this);
                        configurationManagerProvider.SetSetting(attribute.SettingName, value, property.PropertyType);
                    }
                }
            }
        }

        private void LoadConfigurationProvider()
        {
            string configurationManagerDllName = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\plugins\ConfigurationManager.dll";
            
            var configurationManagerAssembly = Assembly.LoadFrom(configurationManagerDllName.Replace('\\', Path.DirectorySeparatorChar));
            foreach (var type in configurationManagerAssembly.GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(IConfigurationProvider)))
                {
                    if(configurationManagerProvider != null & fileConfigurationProvider != null)
                    {
                        break;
                    }
                    if (type.Name == "ConfigurationManagerConfigurationProvider")
                    {
                        configurationManagerProvider = Activator.CreateInstance(type) as IConfigurationProvider;
                    }
                    else if (type.Name == "FileConfigurationProvider")
                    {
                        fileConfigurationProvider = Activator.CreateInstance(type) as IConfigurationProvider;
                    }
                    
                }
            }
        }
    }
}

