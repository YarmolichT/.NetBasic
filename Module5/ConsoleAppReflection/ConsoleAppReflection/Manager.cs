﻿using System.ComponentModel;
using System.Reflection;

namespace ConsoleAppReflection
{
    public class CustomItemManager
    {
        private readonly Dictionary<ProviderType, IProvider> _providers;

        public CustomItemManager()
        {
            _providers = new Dictionary<ProviderType, IProvider>
                        { {ProviderType.ConfigurationProvider, new ConfigurationProvider() },
                        { ProviderType.FileConfigurationProvider, new FileConfigurationProvider()  } };
        }

        public void ReadFromFile(object item)
        {
            var customTypePropAttributes = ReturnItemProperties(item.GetType());

            AssignItemProperties(item, customTypePropAttributes);
        }

        public void WriteToFile(object item)
        {
            var customTypePropAttributes = ReturnItemProperties(item.GetType());

            WriteItemProperties(item, customTypePropAttributes);
        }

        private void WriteItemProperties(object item, Dictionary<string, CustomAttribute> dataOfType)
        {
            foreach (var keyValuePair in dataOfType)
            {
                var propertyInfo = item.GetType().GetProperty(keyValuePair.Key);
                var attributes = propertyInfo.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    if (attribute is CustomAttribute)
                    {
                        var key = keyValuePair.Value.SettingName;
                        var value = propertyInfo.GetValue(item).ToString();
                        var provider = keyValuePair.Value.ProviderType;

                        SetPropertyValue(key, value, provider);
                    }
                }
            }
            var providers = dataOfType.Values.Select(x => x.ProviderType).Distinct();
            foreach (var provider in providers)
            {
                SaveChanges(provider);
            }
        }

        private Dictionary<string, CustomAttribute> ReturnItemProperties(Type type)
        {
            var propertyInfo = type.GetProperties();

            Dictionary<string, CustomAttribute> pairs = new();

            foreach (var property in propertyInfo)
            {
                var customAttributes = property.GetCustomAttributes();

                foreach (var attribute in customAttributes)
                {
                    if (attribute is CustomAttribute)
                    {
                        pairs.Add(property.Name, (CustomAttribute)attribute);
                    }
                }
            }
            return pairs;
        }

        private void AssignItemProperties(object obj, Dictionary<string, CustomAttribute> dataOfType)
        {
            foreach (var pair in dataOfType)
            {
                var pairSettingName = pair.Value.SettingName;
                var providerType = pair.Value.ProviderType;
                var pairValue = GetPropertyValue(pairSettingName, providerType);
                var propertyType = obj.GetType().GetProperty(pair.Key).PropertyType;

                var adjustedValue = ConvertValue(pairValue, propertyType);

                if (adjustedValue != null)
                {
                    obj.GetType().GetProperty(pair.Key).SetValue(obj, adjustedValue);
                }
            }
        }
        private object? ConvertValue(string pairValue, Type propertyType)
        {
            var converter = TypeDescriptor.GetConverter(propertyType);
            return converter.ConvertFromString(pairValue);
        }

        private void SaveChanges(ProviderType provider)
        {
            _providers[provider].SaveChanges();
        }

        private void SetPropertyValue(string key, string value, ProviderType provider)
        {
            _providers[provider].SetValue(key, value);
        }

        private string GetPropertyValue(string pairSettingName, ProviderType provider)
        {
            return _providers[provider].GetValue(pairSettingName);
        }
    }
}
