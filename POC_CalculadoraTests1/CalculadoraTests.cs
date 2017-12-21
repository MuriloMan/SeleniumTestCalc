using System;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using POC_Calculadora;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_CalculadoraTests1
{
    [TestClass]
    public class CalculadoraTests
    {
        Random oRandomico = new Random();
        Calculadora oCalculadora = new Calculadora();
        private IWebDriver ChromeDriver;

        [TestInitialize()]
        public void SyncDriver()
        {
            ChromeDriver = new ChromeDriver(@"dependencies");
            ChromeDriver.Navigate().GoToUrl("http://www.google.com");
            ChromeDriver.Manage().Window.Maximize();
            //ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20.0);
        }

        [TestCleanup()]
        public void DriverCleanup()
        {
            if (ChromeDriver != null)
                ChromeDriver.Quit();
        }

        [TestMethod]
        public void AdicaoTest()
        {
            ChromeDriver.Navigate().GoToUrl("http://www.google.com");
            IWebElement LinkTest = ChromeDriver.FindElement(By.CssSelector("asd"));

            oCalculadora.Numero1 = oRandomico.NextDouble();
            oCalculadora.Numero2 = oRandomico.NextDouble();
            double result = oCalculadora.Adicao();
            
            Assert.AreEqual(oCalculadora.Numero1 + oCalculadora.Numero2, result);
        }

        [TestMethod]
        public void SubtracaoTest()
        {
            oCalculadora.Numero1 = oRandomico.NextDouble();
            oCalculadora.Numero2 = oRandomico.NextDouble();
            double result = oCalculadora.Subtracao();

            Assert.AreEqual(oCalculadora.Numero1 - oCalculadora.Numero2, result );
        }

        [TestMethod]
        public void MultiplicacaoTest()
        {
            oCalculadora.Numero1 = oRandomico.NextDouble();
            oCalculadora.Numero2 = oRandomico.NextDouble();
            double result = oCalculadora.Multiplicacao();

            Assert.AreEqual(oCalculadora.Numero1 * oCalculadora.Numero2, result);
        }

        [TestMethod]
        public void DividirTest()
        {
            oCalculadora.Numero1 = oRandomico.NextDouble();
            oCalculadora.Numero2 = oRandomico.NextDouble();
            double result = oCalculadora.Dividir();

            Assert.AreEqual(oCalculadora.Numero1 / oCalculadora.Numero2, result);
        }

        [TestMethod]
        public void CalcularTest()
        { 
            oCalculadora.Numero1 = oRandomico.NextDouble();
            oCalculadora.Numero2 = oRandomico.NextDouble();

            Assert.AreEqual(oCalculadora.Adicao(), oCalculadora.Calcular(Calculadora.Operacao.Adicao));
            Assert.AreEqual(oCalculadora.Subtracao(), oCalculadora.Calcular(Calculadora.Operacao.Subtracao));
            Assert.AreEqual(oCalculadora.Multiplicacao(), oCalculadora.Calcular(Calculadora.Operacao.Multiplicacao));
            Assert.AreEqual(oCalculadora.Dividir(), oCalculadora.Calcular(Calculadora.Operacao.Divisao));
        }

        [TestMethod]
        public void TesteSelenium()
        {
            //IssExpress oIisEmpress = new IssExpress(ConfigurationManager.AppSettings["Path_WebApp"],
            //                                        ConfigurationManager.AppSettings["Num_Port"],
            //                                        ConfigurationManager.AppSettings["Path_IisExpress"]);
            //oIisEmpress.Iis_Start();

            //Abrir o Browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"http://localhost:" + ConfigurationManager.AppSettings["Num_Port"]);

            //Carregar Valores
            driver.FindElement(By.Id("MainContent_txtNumero1")).SendKeys(oRandomico.Next(0, 100).ToString());
            oCalculadora.Numero1 = Convert.ToDouble(driver.FindElement(By.Id("MainContent_txtNumero1")).GetAttribute("value"));

            driver.FindElement(By.Id("MainContent_txtNumero2")).SendKeys(oRandomico.Next(0, 100).ToString());
            oCalculadora.Numero2 = Convert.ToDouble(driver.FindElement(By.Id("MainContent_txtNumero2")).GetAttribute("value"));

            //Testar Operações
            driver.FindElement(By.Id("MainContent_ddlOperacao")).SendKeys("Adição");
            driver.FindElement(By.Id("MainContent_BtnCalcular")).Click();
            Assert.AreEqual(oCalculadora.Adicao().ToString(), driver.FindElement(By.Id("MainContent_txtResultado")).GetAttribute("value"));

            PrintTela(driver, "188022.jpg");

            driver.FindElement(By.Id("MainContent_ddlOperacao")).SendKeys("Subtração");
            driver.FindElement(By.Id("MainContent_BtnCalcular")).Click();
            Assert.AreEqual(oCalculadora.Subtracao().ToString(), driver.FindElement(By.Id("MainContent_txtResultado")).GetAttribute("value"));

            PrintTela(driver, "188023.jpg");

            driver.FindElement(By.Id("MainContent_ddlOperacao")).SendKeys("Multiplicação");
            driver.FindElement(By.Id("MainContent_BtnCalcular")).Click();
            Assert.AreEqual(oCalculadora.Multiplicacao().ToString(), driver.FindElement(By.Id("MainContent_txtResultado")).GetAttribute("value"));

            PrintTela(driver, "188024.jpg");

            driver.FindElement(By.Id("MainContent_ddlOperacao")).SendKeys("Divisão");
            driver.FindElement(By.Id("MainContent_BtnCalcular")).Click();
            Assert.AreEqual(oCalculadora.Dividir().ToString(), driver.FindElement(By.Id("MainContent_txtResultado")).GetAttribute("value"));

            PrintTela(driver, "188025.jpg");

            //Testar Limpar Campos
            driver.FindElement(By.Id("MainContent_BtnLimpar")).Click();
            Assert.AreEqual(driver.FindElement(By.Id("MainContent_txtNumero1")).GetAttribute("value"), "");
            Assert.AreEqual(driver.FindElement(By.Id("MainContent_txtNumero2")).GetAttribute("value"), "");
            Assert.AreEqual(driver.FindElement(By.Id("MainContent_ddlOperacao")).GetAttribute("value"), "0");
            Assert.AreEqual(driver.FindElement(By.Id("MainContent_txtResultado")).GetAttribute("value"), "");

            PrintTela(driver, "188026.jpg");

            //Sair
            driver.Close();
            driver.Quit();

            //oIisEmpress.Iis_Stop();

        }

        private static void PrintTela(IWebDriver driver, string jpgName)
        {
            if(!System.IO.Directory.Exists(ConfigurationManager.AppSettings["Path_Screenshot"]))
            {
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["Path_Screenshot"]);
            }

            var caminho = System.IO.Path.Combine(ConfigurationManager.AppSettings["Path_Screenshot"], jpgName);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(caminho, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}