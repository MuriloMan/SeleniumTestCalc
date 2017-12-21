using System;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_CalculadoraTest
{
    [TestClass]
    public class TestExample
    {
        //Calculadora oCalculadora = new Calculadora();
        private IWebDriver ChromeDriver;

        /* Metodo que executa antes de quaquer [TestMethod]*/
        [TestInitialize()]
        public void SyncDriver()
        {
            /*pegando chromedriver.exe que manipula o HTML da pagina*/
            ChromeDriver = new ChromeDriver(@"../../Dependencies");
            /*Maximiza o navegador*/
            ChromeDriver.Manage().Window.Maximize();
            /*se alguma ação no navegador demorar mais q 50 segundos, timeout*/
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50.0);
        }

        /* Metodo que excuta depois de todos os [TestMethod]*/
        [TestCleanup()]
        public void DriverCleanup()
        {
            /*fecha o processo chromedriver.exe para caso outra execução precisar usar*/
            if (ChromeDriver != null)
                ChromeDriver.Quit();
        }

        [TestMethod]
        public void AdicaoTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://www.google.com");
        }
    }
}