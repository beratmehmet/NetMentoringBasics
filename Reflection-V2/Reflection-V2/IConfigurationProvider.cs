using System;
namespace Reflection_V2
{
	public interface IConfigurationProvider
	{
        object GetSetting(string key, Type type);
        void SetSetting(string key, string value, Type type);
    }
}

