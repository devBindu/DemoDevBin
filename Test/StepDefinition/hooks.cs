using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Test.StepDefinition
{
    public sealed class Hooks
    {
        private IWebDriver driver;
       
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }



    }
}
