﻿using System;
namespace Reflection_V2
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConfigurationItemAttribute : Attribute
	{
        public string SettingName { get; set; }

        public ConfigurationItemAttribute(string settingName)
        {
            SettingName = settingName;
        }
    }
}

