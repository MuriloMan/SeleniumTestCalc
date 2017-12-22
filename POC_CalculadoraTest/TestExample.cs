using System;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.IO;

namespace POC_CalculadoraTest
{
    [TestClass]
    public class TestExample
    {
        //Calculadora oCalculadora = new Calculadora();
        private IWebDriver ChromeDriver;
        private const string Url = "http://10.100.60.111:13995/";

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
            /*Faz o chrome ir para a URL do projeto que será testado*/
            ChromeDriver.Navigate().GoToUrl(Url);
        }

        /* Metodo que excuta depois de todos os [TestMethod]*/
        [TestCleanup()]
        public void DriverCleanup()
        {
            /*fecha o processo chromedriver.exe para caso outra execução precisar usar*/
            if (ChromeDriver != null)
                ChromeDriver.Quit();
        }

        /*Todo metodo de test precisa ter a DataNotation [TestMethod] para ser identificado pelo visual studio e compilado como TESTE*/
        [TestMethod]
        public void AdicaoTest()
        {
            /* criando uma instancia de um "Esperador" que espera se o elemento aparecerá nos próximos 50 segundos (horas, minutos, segundos), caso contrário, erro de timeout*/
            WebDriverWait wait = new WebDriverWait(ChromeDriver, new TimeSpan(0, 0, 50));

            /*Pega instancia da classe para randomizar numeros para realizar o teste*/
            Random oRandomico = new Random();

            /*Cria duas variaveis randomizadas no intervalo de 0-50 aleatórias*/
            int n1 = oRandomico.Next(0, 50);
            int n2 = oRandomico.Next(0, 50);

            /*Significa: Aguarde até o Chrome encontrar o elemento pelo seletor CSS*/
            wait.Until(ChromeDriver => ChromeDriver.FindElement(By.CssSelector("#MainContent_txtNumero1")));
            /*Essa linha de cima tem a mesma função que essa:*/
            /*wait.Until(ChromeDriver => ChromeDriver.FindElement(By.Id("MainContent_txtNumero1")));*/

            /*Pegar o elemento e armazena na variavel inputN1 e clicar nele*/
            IWebElement inputN1 = ChromeDriver.FindElement(By.CssSelector("#MainContent_txtNumero1"));
            inputN1.Click();

            /*Mandar acoes do teclado para o Elemento e digitar valores*/
            var acoesDigitarNumeroInput1 = new Actions(ChromeDriver);
            acoesDigitarNumeroInput1.SendKeys(n1.ToString());

            /*essa linha tem que ter, ela realiza as operações que foram pedidas acima (clicar, enviar numeros) etc*/
            acoesDigitarNumeroInput1.Build().Perform();

            /*Significa: Aguarde até o Chrome encontrar o elemento pelo seletor CSS*/
            wait.Until(ChromeDriver => ChromeDriver.FindElement(By.CssSelector("#MainContent_txtNumero2")));

            /*Pegar o elemento e clicar nele*/
            IWebElement inputN2 = ChromeDriver.FindElement(By.CssSelector("#MainContent_txtNumero2"));
            inputN2.Click();

            /*Mandar acoes do teclado para o Elemento e digitar valores*/
            var acoesDigitarNumeroInput2 = new Actions(ChromeDriver);
            acoesDigitarNumeroInput2.SendKeys(n2.ToString());

            /*essa linha tem que ter, ela realiza as operações que foram pedidas acima (clicar, enviar numeros) etc*/
            acoesDigitarNumeroInput2.Build().Perform();

            /*Buscando o elemento Select por ID e clicando nele para abrir as opções*/
            IWebElement selectOperacao = ChromeDriver.FindElement(By.Id("MainContent_ddlOperacao"));
            selectOperacao.Click();

            /*Escolhendo opção de adicao, que é a opcao 2*/
            IWebElement selectAdicaoOpcao = ChromeDriver.FindElement(By.CssSelector("#MainContent_ddlOperacao > option:nth-child(2)"));
            selectAdicaoOpcao.Click();

            /*Clicando no botao para calcular o resultado*/
            IWebElement btnCalcular = ChromeDriver.FindElement(By.Id("MainContent_BtnCalcular"));
            btnCalcular.Click();

            /*Pegando o valor do campo e verificando se realmente é feita a soma dos 2 numeros*/
            IWebElement inputResultado = ChromeDriver.FindElement(By.Id("MainContent_txtResultado"));

            /*Pegando o valor da input que foi calculada pelo sistema*/
            var resultadoFinal = inputResultado.GetAttribute("value");

            /*Colocando o valor que esperamos na variavel para testar*/
            var resultadoEsperado = (n1 + n2).ToString();

            /*Essa funcao dispara erro quando o valor final for falso (AreEqual) = (São iguais)*/
            Assert.AreEqual(resultadoFinal, resultadoEsperado);

            /*Chamando esse metodo, sera tirado um print da tela, e salvará na pasta ScreenShots do projeto*/
            /*Caso o nome do arquivo "TesteAdicao" ja existir na pasta sera substituido!*/
            /*Caso não deseje que o arquivo anterior seja perdido, podemos colocar a data junto com o nome !*/
            //PrintTela(ChromeDriver, "TesteAdicao");

            /*exemplo: arquivo com um numero aleatorio junto com o nome:*/
            PrintTela(ChromeDriver, "TesteAdicao" + oRandomico.Next(0, 1000));
        }

        [TestMethod]
        public void SubtracaoTest()
        {

        }

        [TestMethod]
        public void OutroTest()
        {

        }

        /*Metodos private nao são testes, somente utilizado por varios testes para evitar codigo duplicado*/
        /*Esse metodo foi feito para salvar o screenshot da tela do Tipo PNG*/
        private static void PrintTela(IWebDriver driver, string jpgName)
        {
            if (!System.IO.Directory.Exists("../../ScreenShots"))
                System.IO.Directory.CreateDirectory("../../ScreenShots");
            var caminho = System.IO.Path.Combine("../../ScreenShots", jpgName + ".png");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(caminho, ScreenshotImageFormat.Png);
        }
    }
}