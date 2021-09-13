using System;
using DataDrivenFramework;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DataDrivenFB
{

    public class ReadFromExcel : Base.BaseClass
    {
        [Test]
        public void ReadingDataFromExcelTestMethod()
        {
            ExcelOperations.PopulateInCollection(@"C:\Users\lavanya.g\Downloads\TestData.xlsx");
            driver.FindElement(By.Name("email")).SendKeys(ExcelOperations.ReadData(1, "Username"));
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Name("pass")).SendKeys(ExcelOperations.ReadData(1, "Password"));
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Name("login")).Click();
            System.Threading.Thread.Sleep(8000);

        }
    }
}
