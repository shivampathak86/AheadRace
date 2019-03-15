using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Regression_Suite
{
   public  class Pom
    {
        public Pom(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.Name, Using = "name")]
         public IWebElement Username;

        [FindsBy(How = How.Name, Using = "pass")]
         public IWebElement pwd;

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement LoginButton;


        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-block alert-danger']")]
        public IWebElement LoginError;

        [FindsBy(How = How.XPath, Using = "//a[text()='Request new password']")]

         public IWebElement ReuquestNewPasswordLinkText;

        [FindsBy(How = How.XPath, Using = "//button[@value='E-mail new password']")]

        public IWebElement EmailNewPassWordButton;

        [FindsBy(How = How.XPath, Using = "//label[contains( text(),'Username or e-mail address')]//following-sibling::input[@id='edit-name']")]

        public IWebElement RequestaNewPwd_EmailField;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-block alert-success']")]
        public IWebElement PasswordSent_SuccessMessage;

        [FindsBy(How = How.XPath, Using = "//a[@id='main-content']//following-sibling::h1")]
        public IWebElement Dashboard;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'People')]")]
        public IWebElement PeopleDropDownLinkText;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'People')]/..//ul[@class='dropdown-menu']//li")]
        public IList<IWebElement> PeopleDropDownList;

        [FindsBy(How = How.XPath, Using = "//a[@id='main-content']//following-sibling::h1")]
        public IWebElement UserPageHeader;

        

        [FindsBy(How = How.XPath, Using = "//a[@id='main-content']//following-sibling::h1")]

        [FindsBy(How = How.XPath, Using = "//a[@id='main-content']//following-sibling::h1")]
        public IWebElement ImportParticipantsHeader;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Import Participants')]")]
        public IWebElement ImportParticipantsButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-feeds-feedsfilefetcher-upload']")]
        public IWebElement BrowseButton;


        [FindsBy(How = How.XPath, Using = "//button[@id='edit-submit']")]
        public IWebElement ImportButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-block alert-success']")]
        public IWebElement SuccessMessage;

        public By LocatorforSuccessMessage = By.XPath("//div[@class='alert alert-block alert-success']");

        [FindsBy(How = How.XPath, Using = "//a[@title='Tutorials']")]
        public IWebElement TutorialMainMenu;

        public By LocatorforTutorialMainMenu = By.XPath("//div[@class='alert alert-block alert-success']");

        [FindsBy(How = How.XPath, Using = "//a[@title='Appium']")]
        public IWebElement AppiumMenu;

        public By LocatorforAppiumMenu = By.XPath("//a[@title='Appium']");



        [FindsBy(How = How.Id, Using = "Automation Tools")]
        public IWebElement AutomationTools;

        public By LocatorforAutomationTools = By.Id("Automation Tools");


        [FindsBy(How = How.Id, Using = "Selenium")]
        public IWebElement Selenium;

        public By LocatorforSelenium = By.Id("Selenium");


        [FindsBy(How = How.Id, Using = "Selenium IDE")]
        public IWebElement SeleniumIDE;

        public By LocatorforSeleniumIDE = By.Id("Selenium IDE");

        [FindsBy(How = How.XPath, Using = "//li[@role='treeitem']")]
        public IList<IWebElement> DropDownOptionsList;

        public By locatorForDropDownList = By.XPath("//li[@role='treeitem']");


        [FindsBy(How = How.XPath, Using = "//div[@class='k-check-all']")]
        public IWebElement ChecAllOption;

        [FindsBy(How = How.XPath, Using= "//div[@class='k-multiselect-wrap k-floatwrap']")]
        public IWebElement DropDownMenu;

        //div[@class='k-multiselect-wrap k-floatwrap']
        //public IList<By> LocatorForDropDownOptionsList = new List<By>() { By.XPath("//li[@role='treeitem']") };
    }
}
