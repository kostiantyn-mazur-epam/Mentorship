using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConfigurationProvider.Tests
{
    [TestClass]
    public class ConfigurationProviderTests
    {
        [TestMethod]
        public void Get_ServiceSettingsConnectionStringWithNamespace_ShouldReturnConnectionString()
        {
            var serviceSettings = new ServiceSettings();
            serviceSettings.ConnectionString = "sqlserver/dba";
            var configProvider = new CustomConfigurationProvider();
            configProvider.Initialize("ConfigurationProvider.ServiceSettings.ConnectionString=sqlserver/dba");

            var settings = configProvider.Get<ServiceSettings>();

            Assert.AreEqual("sqlserver/dba", settings.ConnectionString);
        }

        [TestMethod]
        public void Get_ServiceSettingsBatchSizeWithoutNamespace_ShouldReturnBatchSize()
        {
            var serviceSettings = new ServiceSettings();
            serviceSettings.BatchSize = 300;
            var configProvider = new CustomConfigurationProvider();
            configProvider.Initialize("ServiceSettings.BatchSize=300");

            var settings = configProvider.Get<ServiceSettings>();

            Assert.AreEqual(300, settings.BatchSize);
        }

        [TestMethod]
        public void Get_ServiceSettingsPortWithNamespace_ShouldReturnPort()
        {
            var serviceSettings = new ServiceSettings();
            serviceSettings.Port = 4563;
            var configProvider = new CustomConfigurationProvider();
            configProvider.Initialize("ConfigurationProvider.ServiceSettings.Port=4563");

            var settings = configProvider.Get<ServiceSettings>();

            Assert.AreEqual(4563, settings.Port);
        }

        [TestMethod]
        public void Get_ServiceSettingsPortWithEmptyConfig_ShouldReturnEmptyInstance()
        {
            var serviceSettings = new ServiceSettings();
            serviceSettings.Port = 4563;
            var configProvider = new CustomConfigurationProvider();
            configProvider.Initialize("");

            var settings = configProvider.Get<ServiceSettings>();

            Assert.AreEqual(0, settings.Port);
        }
    }
}