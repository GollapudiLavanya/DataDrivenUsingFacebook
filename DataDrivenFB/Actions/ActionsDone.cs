/*
 * project = DataDrivenFrameworkUsingFacebook
 * Author = Lavanya Gollapudi
 * Created Date = 14/09/2021
 */

using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataDrivenFB.Actions
{
    public class ActionsDone
    {
        
        public static void AssertAfterLauching(IWebDriver driver)
        {
            string title1 = "Facebook – log in or sign up";
            string title = driver.Title;
            Assert.AreEqual(title1, title);
        }
        
        

    }
}
