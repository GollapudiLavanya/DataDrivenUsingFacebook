/*
 * project = DataDrivenFrameworkUsingFacebook
 * Author = Lavanya Gollapudi
 * Created Date = 14/09/2021
 */

using System;
using DataDrivenFramework;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using DataDrivenFB.page;

namespace DataDrivenFB
{

    public class ReadFromExcel : Base.BaseClass
    {
        [Test]
        public static void ReadingDataFromExcelTestMethodAndLoginToFb()
        {
            Actions.ActionsDone.AssertAfterLauching(driver);
            ExcelOperations.PopulateInCollection(@"C:\Users\lavanya.g\source\repos\DataDrivenFB\DataDrivenFB\CredentialsOfFb.xlsx");

            Login_page login = new Login_page(driver);
            login.email.SendKeys(ExcelOperations.ReadData(1, "Username"));
            System.Threading.Thread.Sleep(2000);
            
           
            login.password.SendKeys(ExcelOperations.ReadData(1, "Password"));
            System.Threading.Thread.Sleep(2000);
            

            login.loginButton.Click();
            System.Threading.Thread.Sleep(15000);
            

        }
    }
}
