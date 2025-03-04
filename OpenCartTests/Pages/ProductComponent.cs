﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class ProductComponent
    {   
        private IWebElement _productLayout;
        private IWebElement _name;
        private IWebElement _price;
        private IWebElement _description;
        private IWebElement _addToCartButton;
        private IWebElement _addToWishButton;
        private IWebElement _addToCompareButton;

        public ProductComponent (IWebElement productLayout)
        {
            _productLayout = productLayout;
            _name = _productLayout.FindElement(By.CssSelector("h4 a"));
            _price = _productLayout.FindElement(By.CssSelector(".price"));
            _description = _productLayout.FindElement(By.CssSelector("p"));
            _addToCartButton = _productLayout.FindElement(By.CssSelector(".fa.fa-shopping-cart"));
            _addToWishButton = _productLayout.FindElement(By.CssSelector(".fa.fa-heart"));
            _addToCompareButton = _productLayout.FindElement(By.CssSelector(".fa.fa-exchange"));
        }

        

        public IWebElement ProductLayout => _productLayout;
        public IWebElement Name => _name;
        public IWebElement Price => _price;
        public IWebElement Description => _description;
        public IWebElement AddToCartButton => _addToCartButton;
        public IWebElement AddToWishButton => _addToWishButton;
        public IWebElement AddToCompareButton => _addToCompareButton;

        public string GetNameText() => Name.Text;
        public string GetPriceText() => Price.Text;
        public string GetDescriptionText() => Description.Text;
        public void ClickName() => Name.Click();
        public void ClickAddToCartButton() => AddToCartButton.Click();
        public void ClickAddToWishButton() => AddToWishButton.Click();
        public void ClickAddToCompareButton() => AddToCompareButton.Click();

    }
}
