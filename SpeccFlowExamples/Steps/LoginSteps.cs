using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SpeccFlowExamples.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Remote;
using static SpeccFlowExamples.Steps.LoginSteps;
using OpenQA.Selenium.Support.UI;

namespace SpeccFlowExamples.Steps
{
    [Binding]
    public class LoginSteps 
    {
        public enum enumExample
        {
            cat,
            dogs
        }

        public enumExample enumExamplAnimalName { get; set; }
           

        LoginPage loginPage = null;
        public IWebDriver driver = null;
        //Step Definitions
      

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.DebuggerAddress = "sjds";
            driver = new ChromeDriver();


            Thread.Sleep(7000);
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#inbox");
        }


        private IWebElement expandRootElement(IWebElement element)
        {
            IWebElement ele = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot", element);
            return ele;
        }

        [Given(@"I click login link")]
        public void GivenIClickLoginLink()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLogin();
        }
        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login((string)data.Username, (string)data.Password);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WindowWidth = 12;
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should see Employee details link")]
        public void ThenIShouldSeeEmployeeDetailsLink()
        {
            Assert.That(loginPage.IsEmployeeDetailsExist(),Is.True);
            driver.Close();
        }

    }
    public class experimentEnum
    {
        
        public static void main()
        {
            LoginSteps h = new LoginSteps();
            h.enumExamplAnimalName = enumExample.cat;
        }
    }
}
