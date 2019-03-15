using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using AutoIt;
using System.IO;
using System.Threading;

namespace Regression_Suite
{
    [TestClass]
    public class Ondemand_Questionmark_Com
    {
        

        [ClassInitialize]

        public static void ClassInit(TestContext testContext)
        {
          //  BaseClass.GetDriverInstance.Goto(ConfigClass.Url);

            //string url = "https://ondemand.questionmark.com/home/403160/";

            //IWebDriver webDriver = new ChromeDriver();

            //webDriver.Navigate().GoToUrl(url);
            //webDriver.Manage().Window.Maximize();
            //BaseClass.GetDriverInstance.Driver = webDriver;


            


        }

        [ClassCleanup]
            
        public static void ClassCleanUp()
        {

            BaseClass.GetDriverInstance.Clean();
            
        }










        Pom PomObj = new Pom(BaseClass.GetDriverInstance.Driver);

        [TestMethod]

        public void OrderedTests()
        {
            Error_Messagefor_RandomUserName_and_Password();

            Valid_User_reach_To_Request_new_Password_Page_and_Verify_Success_Message();

            Verify_User_Reach_To_Users_Page();

            Verify_User_Reach_To_Import_Participants_Page();

            Upload_EXcelFile_And_Verify_On_UI();

}



        [Priority(1)]
        public void Error_Messagefor_RandomUserName_and_Password()
            {


            //Username = BaseClass.GetDriverInstance.Driver.FindElement(By.Name("name")); //POM Object
            PomObj.Username.SendKeys("RandomUser");


            //var pwd = BaseClass.GetDriverInstance.Driver.FindElement(By.Name("pass"));

            PomObj.pwd.SendKeys("RandomPassword");

            //var LoginButton = BaseClass.GetDriverInstance.Driver.FindElement(By.Id("edit-submit"));

            PomObj.LoginButton.Click();

            //var LoginError = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//div[@class='alert alert-block alert-danger']"));

            string ActualLoginErrortext = PomObj.LoginError.Text;
            string ExpectedLoginErrorText = "Sorry, unrecognized username or password";


            Assert.IsTrue(ActualLoginErrortext.Contains(ExpectedLoginErrorText), "User did not see Login Error for Random Username and Pwd");



        }

        
        [Priority(2)]

        public void Valid_User_reach_To_Request_new_Password_Page_and_Verify_Success_Message()
        {
            //var ReuquestNewPasswordLinkText = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//a[text()='Request new password']"));

            PomObj.ReuquestNewPasswordLinkText.Click();

            //var EmailNewPassWordButton = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//button[@value='E-mail new password']"));

            Assert.IsTrue(PomObj.EmailNewPassWordButton.Displayed, "User did not reach to Request new password page");

            //var RequestaNewPwd_EmailField = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//label[contains( text(),'Username or e-mail address')]//following-sibling::input[@id='edit-name']"));

            PomObj.RequestaNewPwd_EmailField.SendKeys(ConfigClass.GenerateRandomEmail_Address);

            PomObj.EmailNewPassWordButton.Click();

            //var PasswordSent_SuccessMessage = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//div[@class='alert alert-block alert-success']"));

            Assert.IsTrue(PomObj.PasswordSent_SuccessMessage.Displayed, "\"Further instructions have been sent to your e-mail address\" not Displayed\"");
        }


       
        [Priority(3)]

        public void Verify_User_Reach_To_Users_Page()
        {
            //var Username = BaseClass.GetDriverInstance.Driver.FindElement(By.Name("name")); //POM Object
            PomObj.Username.SendKeys(ConfigClass.UserName);


           // var pwd = BaseClass.GetDriverInstance.Driver.FindElement(By.Name("pass"));

            PomObj.pwd.SendKeys(ConfigClass.Password);

           // var LoginButton = BaseClass.GetDriverInstance.Driver.FindElement(By.Id("edit-submit"));

            PomObj.LoginButton.Click();

            //var Dashboard = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//a[@id='main-content']//following-sibling::h1"));

            Assert.IsTrue(PomObj.Dashboard.Displayed, "User not logged in");

           // var PeopleDropDownLinkText = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//a[contains(text(),'People')]"));

            PomObj.PeopleDropDownLinkText.Click();

            // IList<IWebElement> PeopleDropDownList = BaseClass.GetDriverInstance.Driver.FindElements(By.XPath("//a[contains(text(),'People')]/..//ul[@class='dropdown-menu']//li"));
            var UserOption = PomObj.PeopleDropDownList.Where(option => option.Text == "Users").First();


            UserOption.Click();

            //var UserPageHeader = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//a[@id='main-content']//following-sibling::h1"));

            Assert.IsTrue(PomObj.UserPageHeader.Displayed, "User did not reach to Users Page");

        }

        
        [Priority(4)]
        public void Verify_User_Reach_To_Import_Participants_Page()
        {
            //var ImportParticipantsButton = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//a[contains(text(),'Import Participants')]"));

            PomObj.ImportParticipantsButton.Click();

           // var ImportParticipantsHeader = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//a[@id='main-content']//following-sibling::h1"));

            Assert.IsTrue(PomObj.ImportParticipantsHeader.Displayed, "User did not reach to ImportParticipants page");

        }

      

        [Priority(5)]

        public void Upload_EXcelFile_And_Verify_On_UI()
        {
            // var BrowseButton = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//input[@id='edit-feeds-feedsfilefetcher-upload']"));
            PomObj.BrowseButton.Click();

            ProcessStartInfo process = new ProcessStartInfo("AheadPace_FileUpload.exe", Directory.GetCurrentDirectory() + @"\Participants.csv");
            process.UseShellExecute = false;


            var runAutoITScript = Process.Start(process);

            //runAutoITScript.Close();

            //Thread.Sleep(5000);
            //string filepath = Directory.GetCurrentDirectory() + "\\Participants.csv";

          //  IntPtr browseWindow;
          // AutoItX.WinWaitActive("Open","",10);
          //  browseWindow = AutoItX.ControlGetHandle()
          //  AutoItX.ControlFocus("Open", "", "Edit1");
          //  AutoItX.ControlSetText("Open","","Edit1",filepath);
          //  //AutoItX.ControlSetText("open", "", "ComboBox1", );
          // // AutoItX.Sleep(1000);
          ////  AutoItX.ControlFocus("Open", "", "Button1");
          //  //
          //  AutoItX.ControlClick("Open", "", "Button1", "middle");
           
          




            //var ImportButton = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//button[@id='edit-submit']"));

            PomObj.ImportButton.Click();
            //runAutoITScript.Dispose();

            //var SuccessMessage = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//div[@class='alert alert-block alert-success']"));

            HelperMethods.ExplicitWait(PomObj.LocatorforSuccessMessage);

            Assert.IsTrue(PomObj.SuccessMessage.Text.Contains("Updated"), "Excel did not upload sucessfully");





        }



       
        [TestMethod]
        public void MenuTraversal()
        {

            BaseClass.GetDriverInstance.Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
            HelperMethods.AdvanceMenuTravesal(PomObj.AutomationTools, PomObj.Selenium,PomObj.SeleniumIDE,BaseClass.GetDriverInstance.Driver);
        }

        [TestMethod]

        public void Multiselect()
        {
            BaseClass.GetDriverInstance.Driver.Navigate().GoToUrl("https://demos.telerik.com/kendo-ui/dropdowntree/checkboxes");
            PomObj.DropDownMenu.Click();
            HelperMethods.SelectDropDownOptions(PomObj.locatorForDropDownList, "Bed Linen", BaseClass.GetDriverInstance.Driver);

        }

        [TestMethod]

        public void UploadUsingAutoIt()
        {
            BaseClass.GetDriverInstance.Driver.Navigate().GoToUrl("https://demos.telerik.com/kendo-ui/upload/index");
           

           

            IWebElement element = BaseClass.GetDriverInstance.Driver.FindElement(By.Name("files"));

            var Executescript = (IJavaScriptExecutor)BaseClass.GetDriverInstance.Driver;
            Executescript.ExecuteScript("arguments[0].click()", element);
           // element.Click();


            ProcessStartInfo process= new ProcessStartInfo("AheadPace_FileUpload.exe", Directory.GetCurrentDirectory() + "\\Participants.csv");
            process.UseShellExecute = false;

            Process.Start(process);
            

        }

        [TestMethod]

        public void DownloadAndUpload()
        {
            BaseClass.GetDriverInstance.Driver.Navigate().GoToUrl("http://spreadsheetpage.com/index.php/file/C35/P10/");

            IWebElement element = BaseClass.GetDriverInstance.Driver.FindElement(By.XPath("//li//b[text()='Download:']//following-sibling::a[text()='smilechart.xls']"));
            var Executescript = (IJavaScriptExecutor)BaseClass.GetDriverInstance.Driver;
            Executescript.ExecuteScript("arguments[0].click()", element);

            string filepath= @"C:\Users\patha\Desktop\WebdriverDonloads\smilechart.xls";
            
            Assert.IsTrue(File.Exists(filepath),"File did now download") ;



        }


        [TestMethod]

        public void TestExcel()
        {

            ExcelUtility excel = new ExcelUtility(ConfigClass.WriteExcelPath, ConfigClass.ReadExcelPath, 1);
            string value =excel.ReadCell(ConfigClass.ExcelRowsandColumns[0, 0], ConfigClass.ExcelRowsandColumns[0, 1] );


        }

        [TestMethod]

        public void TestWriteToExcel()
        {


            ExcelUtility excel = new ExcelUtility(ConfigClass.ReadExcelPath,ConfigClass.WriteExcelPath, 1);
            excel.WriteinCell(2, 3,"TestUser");
        
        }
        [TestMethod]

        public void TestWriteToMultpleCell()
        {

            ExcelUtility excel = new ExcelUtility(ConfigClass.ReadExcelPath, ConfigClass.WriteExcelPath, 1);
            excel.WriteInMultipleCells();
            //excel.FlushFiles();
        }
    }    
}
