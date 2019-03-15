using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Regression_Suite
{
    internal class HelperMethods
    {
        
            
        

        //internal static  IWebElement ExplicitWait(IWebElement element ,int timeout=50)
        //{
        //    WebDriverWait wait = new WebDriverWait(BaseClass.GetDriverInstance.Driver, TimeSpan.FromSeconds(timeout));

        //    return wait.Until(ExpectedConditions.ElementToBeClickable(element));
            
        //}

            internal static IWebElement ExplicitWait(By locator, int timeout = 50)
        {
            WebDriverWait wait = new WebDriverWait(BaseClass.GetDriverInstance.Driver, TimeSpan.FromSeconds(timeout));

            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator)).SingleOrDefault();

        }

        internal static void MenuTravesal (IWebElement parentElement , IWebElement childElement,IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(parentElement).Build().Perform();
            Thread.Sleep(5000);
            builder.MoveToElement(childElement).Click();
        }

        internal static void AdvanceMenuTravesal(IWebElement parentElement, IWebElement childElement,IWebElement ChilEelement2, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(parentElement).Build().Perform();
            
            builder.MoveToElement(childElement).Build().Perform();
            builder.MoveToElement(ChilEelement2).Click();
        }

        internal static void SelectDropDownOptions(By options , string UserChoice, IWebDriver driver)

        {
            IWebElement parent = driver.FindElement(By.XPath("/div[@class='k-list-container k-popup k-group k-reset k-multiple-selection k-popup-dropdowntree k-state-border-up']/."));

           IList<IWebElement> dropDownList = parent.FindElements(By.TagName("li")); 

            var Selection2 = dropDownList.Where(option => option.Text.Contains(UserChoice)).First();
            Selection2.Click();

            //int j = 0;
            
            //while (j <dropDownList.Count-1)
            //{
            //    var Selection = dropDownList.Where(option => option.GetAttribute("class").Contains("k-checkbox-wrapper")).First();
            //    Selection.Click();

            //    j++;
            //}
            
            //dropDownList = driver.FindElements(options);
            // var Selection2 = dropDownList.Where(option => option.Text.Contains(UserChoice)).First();
            // Selection2.Click();

        }



    }
}
