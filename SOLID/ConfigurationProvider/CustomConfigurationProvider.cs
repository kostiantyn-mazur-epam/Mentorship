using System;
using System.Collections.Generic;

namespace ConfigurationProvider
{
    public sealed class CustomConfigurationProvider : ConfigurationProvider
    {
        private Dictionary<(string NameSpace, string ClassName, string PropertyName), string> _settings;

        public override void Initialize(string configContent)
        {
            if (configContent == null)
            {
                throw new ArgumentNullException(nameof(configContent));
            }

            _settings = ParseContent(configContent);
        }

        public override T Get<T>()
        {
            if (_settings == null)
            {
                throw new InvalidOperationException("Configuration provider isn't initialized");
            }

            var instance = new T();

            InitializeInstance(instance);

            return instance;
        }

        private static Dictionary<(string, string, string), string> ParseContent(string line)
        {
            var settings = new Dictionary<(string, string, string), string>();
            var strings = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var str in strings)
            {
                var propertyValuePair = str.Split('=');
                var propertyName = propertyValuePair[0];
                var propertyValue = propertyValuePair[1];
                var propertyKey = CreateCompositeKey(propertyName);

                settings.Add(propertyKey, propertyValue);
            }

            return settings;
        }

        private void InitializeInstance<T>(T instance)
        {
            var type = instance.GetType();
            var typeProps = type.GetProperties();

            foreach (var setting in _settings)
            {
                var settingsNamespace = setting.Key.NameSpace;
                var typeNamespace = type.Namespace;

                if (settingsNamespace != null)
                {
                    if (!settingsNamespace.EndsWith(typeNamespace))
                    {
                        continue;
                    }
                }

                var settingsClassname = setting.Key.ClassName;

                if (settingsClassname != type.Name)
                {
                    continue;
                }

                foreach (var property in typeProps)
                {
                    var settingsPropertyName = setting.Key.PropertyName;

                    if (settingsPropertyName == property.Name)
                    {
                        var propType = property.PropertyType;
                        property.SetValue(instance, ConvertType(setting.Value, propType));
                    }
                }
            }
        }

        private static object ConvertType(object source, Type type)
        {
            return Convert.ChangeType(source, type);
        }

        private static (string, string, string) CreateCompositeKey(string keyString)
        {
            var stringParts = keyString.Split('.');
            var className = stringParts[stringParts.Length - 2];
            var propertyName = stringParts[stringParts.Length - 1];
            string nameSpace;
            var classNameIndex = keyString.IndexOf(className);

            if (classNameIndex > 0)
            {
                nameSpace = keyString.Substring(0, classNameIndex - 1);
            }
            else
            {
                nameSpace = null;
            }

            return (nameSpace, className, propertyName);
        }
    }
}