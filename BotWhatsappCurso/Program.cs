using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BotWhatsappCurso
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "/driver";
            IWebDriver driver = WebDriverFactory.CreateWebDriver(Browser.Chrome, path);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Carrega a página");
                driver.LoadPage("https://web.whatsapp.com/");
                Thread.Sleep(TimeSpan.FromSeconds(10));

                //Lista de links de grupo
                Console.WriteLine("Listando Grupos");
                List<string> listaGrupo = new List<string>();
                listaGrupo.Add("https://chat.whatsapp.com/FvXJii3WiSU2a5DSLmLOSC");
                listaGrupo.Add("https://chat.whatsapp.com/CTceLLKtdXS7XGl4TtbFPw");

                for (int x = 0; x < listaGrupo.Count; x++)
                {
                    //Entrando Grupo
                    Console.WriteLine("Entrando em um grupo listado: " + x);
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    driver.LoadPage(listaGrupo[x]);

                    Console.WriteLine("Cliando Entrar");
                    var btnEntrarGrupo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='action-button']")));
                    btnEntrarGrupo.Click();

                    Console.WriteLine("Confirmando Entrada");

                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine("Aguardando: " + i + " segundos");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }

                    var linkEntrarGrupo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='fallback_block']/div/div/a")));
                    linkEntrarGrupo.Click();

                    Console.WriteLine("Entrando no grupo");
                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine("Aguardando: " + i + " segundos");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }

                    var confirmarEntrada = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='app']/div[1]/span[2]/div[1]/div/div/div/div/div/div[2]/div[2]")));
                    confirmarEntrada.Click();

                    //Escrevendo Grupo

                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine("Aguardando: " + i + " segundos");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }

                    Console.WriteLine("Escrevendo no grupo");
                    var campoDeTexto = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='main']/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[2]")));
                    campoDeTexto.SendKeys("Aula do curso desenvolvimento de bots com C# e Selenium");

                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine("Aguardando: " + i + " segundos");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }

                    campoDeTexto.SendKeys(Keys.Enter);

                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine("Aguardando: " + i + " segundos");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }

                    Console.WriteLine("Clicando menu");
                    var menu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='main']/header/div[3]/div/div[2]/div/div/span")));
                    menu.Click();

                    Console.WriteLine("Clicando botão sair");
                    var btnSair = driver.FindElement(By.XPath("//*[@id='app']/div[1]/span[4]/div/ul/div/div/li[5]/div[1]"));
                    btnSair.Click();

                    Console.WriteLine("Confirmando saida do grupo: " + x);
                    var confirmarSaida = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='app']/div[1]/span[2]/div[1]/div/div/div/div/div/div[2]/div[2]/div/div")));
                    confirmarSaida.Click();
                }
                ////Pesquisando Grupo ou Contato
                //Thread.Sleep(TimeSpan.FromSeconds(5));
                //var campoPesquisa = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='side']/div[1]/div/label/div/div[2]")));
                //campoPesquisa.SendKeys("Aula");

                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("_3OvU8")));
                //var listaContatos = driver.FindElements(By.ClassName("_3OvU8"));

                ////Escrevendo e saindo do grupo
                //for (int i = 0; i < listaContatos.Count; i++)
                //{
                //    listaContatos[i].Click();

                //}
            }
            catch (Exception)
            {
                driver.Quit();
            }
        }
    }
}
