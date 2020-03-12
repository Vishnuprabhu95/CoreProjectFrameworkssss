﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutoFramework.Extensions
{
    public static class WebElementExtensions
    {

        public static string GetFirstSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetAllSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        //public static void Hover(this IWebElement element)
        //{
        //    Actions actions = new Actions(DriverContext.Driver);
        //    actions.MoveToElement(element).Perform();
        //}

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element not present exception"));
        }
        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
