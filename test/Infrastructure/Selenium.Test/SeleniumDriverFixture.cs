﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Optivem.Infrastructure.Selenium;
using Optivem.Test.Common.WebAutomation;
using System;
using System.IO;
using System.Reflection;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test
{
    public class SeleniumDriverFixture : IDisposable
    {
        // TODO: VC: Use Ioc / DI, so that we could specify Chrome, Firefox, etc.

        private readonly IWebDriver _webDriver;

        public SeleniumDriverFixture()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _webDriver = new ChromeDriver(currentDir);
            var driver = new Driver(_webDriver);
            TestDriver = new TestDriver(driver);

            // TODO: VC: Check if the top Driver should do the disposal, and construction...
        }

        public TestDriver TestDriver { get; }

        public void Dispose()
        {
            _webDriver.Dispose();
        }
    }
}