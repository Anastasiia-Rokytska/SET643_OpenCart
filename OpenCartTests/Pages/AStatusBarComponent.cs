﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class AStatusBarComponent : AHeadComponent
    {
        private readonly string STATUS_BAR_ERROR = "STATUS_BAR_ERROR";
        public IList<IWebElement> Breadcrumps { get; private set; }
        public AStatusBarComponent(IWebDriver driver) : base(driver)
        {
            Breadcrumps = driver.FindElements(By.XPath("//*[@id='product-category']/ul/li"));
        }
        public int GetCountBreadcrumps() => Breadcrumps.Count;
        public IWebElement GetBreadcrumb(int breadcrumbIndex)
        {
            if (breadcrumbIndex >= GetCountBreadcrumps())
            {
                throw new Exception(STATUS_BAR_ERROR);
            }
            return Breadcrumps[breadcrumbIndex];
        }
        public IWebElement GetLastBreadcrumb() => Breadcrumps[GetCountBreadcrumps() - 1];
        public string GetBreadcrumbText(int breadcrumbIndex)
        {
            return GetBreadcrumb(breadcrumbIndex).Text;
        }
        public string GetLastBreadcrumbText() => GetLastBreadcrumb().Text;
        public void ClickBreadcrumb(int breadcrumbIndex) => GetBreadcrumb(breadcrumbIndex).Click();
    }
}
