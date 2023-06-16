﻿using System.ComponentModel;
using System.Reflection;
using IProvider_ClassLib;

namespace ConsoleAppReflection
{
    public class CustomItemManager
    {
        private readonly Dictionary<string, IProvider> _providers;

        public CustomItemManager(string pathString)
        {
            _providers = new Dictionary<string, IProvider>();
            var providersDictionary = ProviderFinder.ReturnProviders(pathString);

            foreach (var provider in providersDictionary)
            {
                _providers.Add(provider.Key, provider.Value);
            }
        }

        public void ReadFromFile(CustomItem item)
        {
            var customTypePropAttributes = ReturnItemProperties(item.GetType());
            
            AssignItemProperties(item, customTypePropAttributes);

        }

        public void WriteToFile(CustomItem item)
        {
            var customTypePropAttributes = ReturnItemProperties(item.GetType());

            WriteItemProperties(item, customTypePropAttributes);
        }

        private void WriteItemProperties(CustomItem item, Dictionary<string, ConfigurationItemAttribute> dataOfType)
        {
            foreach (var keyValuePair in dataOfType)
            {
                var propertyInfo = item.GetType().GetProperty(keyValuePair.Key);
                var attributes = propertyInfo.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    if (attribute is ConfigurationItemAttribute)
                    {
                        var key = keyValuePair.Value.SettingName;
                        var value = propertyInfo.GetValue(item).ToString();
                        var provider = keyValuePair.Value.ProviderType;

                        SetPropertyValue(key, value, provider.ToString());
                    }
                }
            }

            var providers = dataOfType.Values.Select(x => x.ProviderType).Distinct();
            foreach (var provider in providers)
            {
                SaveChanges(provider.ToString());
            }
        }

        private Dictionary<string, ConfigurationItemAttribute> ReturnItemProperties(Type type)
        {
            var propertyInfo = type.GetProperties();

            Dictionary<string, ConfigurationItemAttribute> pairs = new();

            foreach (var property in propertyInfo)
            {
                var customAttributes = property.GetCustomAttributes();

                foreach (var attribute in customAttributes)
                {
                    if (attribute is ConfigurationItemAttribute)
                    {
                        pairs.Add(property.Name, (ConfigurationItemAttribute)attribute);
                    }
                }
            }
            return pairs;
        }

        private void AssignItemProperties(object obj, Dictionary<string, ConfigurationItemAttribute> dataOfType)
        {
            foreach (var pair in dataOfType)
            {
                var pairSettingName = pair.Value.SettingName;
                var providerType = pair.Value.ProviderType;
                var pairValue = GetPropertyValue(pairSettingName, providerType.ToString());
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

        private void SaveChanges(string provider)
        {
            _providers[provider].SaveChanges();
        }

        private void SetPropertyValue(string key, string value, string provider)
        {
            _providers[provider].SetValue(key, value);
        }

        private string GetPropertyValue(string pairSettingName, string provider)
        {
            return _providers[provider].GetValue(pairSettingName);
        }
    }
}
