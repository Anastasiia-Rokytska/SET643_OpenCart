﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class ALeftMenuComponent : AStatusBarComponent
    {
        // fields

        public ALeftMenuComponent(IWebDriver driver) : base(driver)
        {
            // constructor
        }

        // Methods
    }
}
