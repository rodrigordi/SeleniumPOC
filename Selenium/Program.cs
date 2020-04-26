using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            var eQuery = driver.FindElement(By.Name("q"));
            eQuery.SendKeys("covid");
            eQuery.Submit();

            int page = 1;

            while (true)
            {

                foreach (var result in driver.FindElements(By.ClassName("g")))
                {
                    foreach (var item in result.FindElements(By.ClassName("r")))
                    {
                        var h3 = item.FindElement(By.TagName("h3"));
                        if (h3 != null)
                        {
                            Console.WriteLine(h3.Text);
                        }
                        else
                        {
                            Console.WriteLine("skip..");
                        }
                    }
                }

                page++;

                try
                {
                    var nextlinkpage = driver.FindElement(By.CssSelector($"a[aria-label='Page {page}']"));
                    nextlinkpage.Click();
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    break;
                }

                ////pages
                //var encontrouPaginaAtual = false;
                //var paginas = driver.FindElements(By.CssSelector("#foot td"));
                //foreach (var pag in paginas)
                //{
                //    if (encontrouPaginaAtual)
                //    {
                //        var linkNext = pag.FindElement(By.TagName("a"));
                //        linkNext.Click();
                //        break;
                //    }

                //    var span = pag.FindElement(By.TagName("span"));
                //    if (span != null)
                //    {
                //        span.nex
                //        if (!string.IsNullOrEmpty(span.Text))
                //            encontrouPaginaAtual = true;
                //    }

                //}
                //if (!encontrouPaginaAtual)
                //{
                //    break;
                //}
            }

        }
    }
}
