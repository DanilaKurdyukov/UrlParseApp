using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using UrlParseApp.Models;

namespace UrlParseApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<UrlPage> urlPages = new List<UrlPage>();
        int maxCountTagA = 0;
        private void GetUrls()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Выберите файл...";
                ofd.Filter = "Текстовые файлы (*.txt)|*.txt";
                if (ofd.ShowDialog()==true)
                {
                    using (StreamReader stream = new StreamReader(ofd.FileName))
                    {
                        string line = "";
                        while ((line = stream.ReadLine()) != null)
                        {
                            UrlPage page = new UrlPage();
                            page.UrlValue = line;
                            page.CountTagA = 0;
                            urlPages.Add(page);
                        }
                        dgAllUrls.ItemsSource = urlPages.ToList();
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CountOfTags()
        {
            try
            {
                btnGetCount.IsEnabled = false;
                pbCountProgress.Value = 0;
                tbCount.Text = "Подсчет выполняется...";
                for (int i = 0; i < urlPages.Count; i++)
                {
                    using (WebClient client = new WebClient { Encoding=Encoding.UTF8})
                    {
                        var text = client.DownloadString(urlPages[i].UrlValue);
                        Regex regex = new Regex(@"<a.*?>.*?</a>");
                        MatchCollection matches = regex.Matches(text);
                        if (matches.Count > 0)
                        {
                            urlPages[i].CountTagA = matches.Count;
                        }
                    }
                    pbCountProgress.Value += 1;
                }
                maxCountTagA = urlPages.Max(c => c.CountTagA);
                urlPages.FirstOrDefault(c => c.CountTagA == maxCountTagA).ColorRecord = "Green";
                dgAllUrls.ItemsSource = urlPages.ToList();
                tbCount.Text = $"Макс. кол-во тегов: {maxCountTagA}";
                btnGetCount.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                tbCount.Text = "";
                pbCountProgress.Value = 0;
                maxCountTagA = 0;
                btnGetCount.IsEnabled = true;
            }
        }

        private void btnGetCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (urlPages.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите выполнить подсчет количества тегов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        CountOfTags();
                    }
                }
                else throw new Exception("Сначала необходимо загрузить списко URl адресов!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            GetUrls();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < urlPages.Count; i++)
            {
                urlPages[i].CountTagA = 0;
                urlPages[i].ColorRecord = "White";
            }
            tbCount.Text = "";
            pbCountProgress.Value = 0;
            maxCountTagA = 0;
            dgAllUrls.ItemsSource = urlPages.ToList();
        }
    }
}
