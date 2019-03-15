using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regression_Suite
{
    internal class BaseClass
    {
         
        private static IWebDriver m_Driver;
        private BaseClass()
        {
            


        }

        public IWebDriver Driver
        {
            set
            {
                value = m_Driver;
            }

            get
            {
                return m_Driver;
            }
        }

        private static  ChromeOptions chromeoptions()
        {

            ChromeOptions options = new ChromeOptions();

            options.AddUserProfilePreference("Downloads", @"C:\Users\patha\Desktop\WebdriverDonloads");

            return options;
        }
        
        
        public static BaseClass GetDriverInstance

        {
            get
            { 
                if(m_Driver==null)
                {
                    m_Driver = new ChromeDriver(chromeoptions());
                    
                }
                return new BaseClass();
            }


        }


        public void Goto(string url)
        {
            m_Driver.Navigate().GoToUrl(url);
            m_Driver.Manage().Window.Maximize();
        }

        public void Clean()
        {

            m_Driver.Close();

            m_Driver.Quit();
        }

    }
}
