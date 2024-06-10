using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const string ROOT_URL = "https://www.ebay.com";

        private IWebDriver driver;


        public Form1()
        {
            InitializeComponent();
            initDriver();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (driver == null || IsDriverClosed())
            {
                initDriver();
            }

            var searchKeyword = this.textBox1.Text;

            driver.FindElement(By.Id("gh-ac")).Clear();
            driver.FindElement(By.Id("gh-ac")).SendKeys(searchKeyword);
            driver.FindElement(By.Id("gh-btn")).Click();

            var url = driver.Url;
            this.textBox2.Text = url;
            this.richTextBox1.Text += url + "\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (driver == null || IsDriverClosed())
            {
                initDriver();
            }

            driver.Navigate().GoToUrl(ROOT_URL);

            this.textBox1.Clear();
            this.textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Close();
        }

        private void initDriver()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ROOT_URL);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (driver != null)
            {
                driver.Quit();
            }
            base.OnFormClosed(e);
        }

        private bool IsDriverClosed()
        {
            try
            {
                var url = driver.Url;
                return false;
            }
            catch (WebDriverException)
            {
                return true;
            }
        }
    }
}
