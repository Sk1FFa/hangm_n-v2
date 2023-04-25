using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab2_RPM
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        string NickName;
        public GameWindow(string NickName)
        {
            InitializeComponent();
            this.NickName = NickName;
        }

        public string Text;
        public char[] Word;
        public int HP;
        public int HPTrue;
        public int Count;

        private void GuessingWordButton_Click(object sender, RoutedEventArgs e)
        {
            //Обнуление всех переменных
            img.Content = null;
            Text = GuessingWordTextBox.Text;
            HP = 0;
            Count = 10;
            HPCount.Content = $"{Count}";
            NonVisibleWord.Text = null;
            GuessingWordTextBox.Text = null;
            Word = new char[Text.Length];
            for (int i = 0; i < Text.Length; i++)
            {
                NonVisibleWord.Text += "*";
                Word[i] = '*';
            }
        }

        private void EnterLetterButton_Click(object sender, RoutedEventArgs e)
        {
            bool words = false;

            //Условие для ввода одной буквы
            if (EnterLetterTextBox.Text.Length == 1)
            {
                for (int i = 0; i < Text.Length; i++)
                {
                    if (EnterLetterTextBox.Text[0] == Text[i])
                    {
                        words = true;
                        HPTrue++;
                        Word[i] = Text[i];
                        NonVisibleWord.Text = null;

                    }
                }
                if (words == true)
                {
                    for (int i=0; i < Text.Length; i++)
                    {
                        NonVisibleWord.Text += Word[i];
                    }
                    if (HPTrue == Text.Length)
                    {
                        System.Windows.MessageBox.Show("Ура победа!");
                        using (StreamWriter sw = new StreamWriter("stat.txt", true))
                        {
                            sw.WriteLine(NickName + " | слово: " + Text + " | попыток осталось: " + Count);
                            this.ListView.Items.Add(NickName + " | слово: " + Text + " | попыток осталось: " + Count);
                        }
                    }
                }
                else
                {
                    HP++;
                    Count--;
                    HPCount.Content = $"{Count}";

                    if (HP == 1)
                    {
                        img.Content = Resources["Image1"];
                    }
                    else if (HP == 2)
                    {
                        img.Content = Resources["Image2"];
                    }
                    else if (HP == 3)
                    {
                        img.Content = Resources["Image3"];
                    }
                    else if (HP == 4)
                    {
                        img.Content = Resources["Image4"];
                    }
                    else if (HP == 5)
                    {
                        img.Content = Resources["Image5"];
                    }
                    else if (HP == 6)
                    {
                        img.Content = Resources["Image6"];
                    }
                    else if (HP == 7)
                    {
                        img.Content = Resources["Image7"];
                    }
                    else if (HP == 8)
                    {
                        img.Content = Resources["Image8"];
                    }
                    else if (HP == 9)
                    {
                        img.Content = Resources["Image9"];
                    }
                    else
                    {
                        img.Content = Resources["Image10"];
                        System.Windows.MessageBox.Show("Вы проиграли! :(");
                        using (StreamWriter sw = new StreamWriter("stat.txt", true))
                        {
                            sw.WriteLine(NickName + " | слово: " + Text + " неугадано");
                            this.ListView.Items.Add(NickName + " | слово: " + Text + " неугадано");
                        }
                        NonVisibleWord.Text = null;
                        NonVisibleWord.Text = Text;
                    }
                }
            }
            //Для ввода полного ответа
            else if (EnterLetterTextBox.Text.Length > 1)
            {
                if (EnterLetterTextBox.Text == Text)
                {
                    NonVisibleWord.Text = null;
                    for (int i = 0; i < Text.Length; i++)
                    {
                        NonVisibleWord.Text += Text[i];
                    }
                    System.Windows.MessageBox.Show("Ура победа!");
                    using (StreamWriter sw = new StreamWriter("stat.txt", true))
                    {
                        sw.WriteLine(NickName + " | слово: " + Text + " | попыток осталось: " + Count);
                        this.ListView.Items.Add(NickName + " | слово: " + Text + " | попыток осталось: " + Count);
                    }

                }
                else
                {
                    HP = 10;
                    img.Content = Resources["Image10"];
                    System.Windows.MessageBox.Show("Вы проиграли! :(");
                    using (StreamWriter sw = new StreamWriter("stat.txt", true))
                    {
                        sw.WriteLine(NickName + " | слово: " + Text + " неугадано");
                        this.ListView.Items.Add(NickName + " | слово: " + Text + " неугадано");
                    }
                    NonVisibleWord.Text = null;
                    NonVisibleWord.Text = Text;
                }
            }
            EnterLetterTextBox.Text = null;
            EnterLetterTextBox.Focus();
        }

        private void BackMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ListView_Click(object sender, RoutedEventArgs e)
        {
            ListView.Visibility = Visibility.Visible;
            CloseList.Visibility = Visibility.Visible;
        }

        private void CloseListView_Click(object sender, RoutedEventArgs e)
        {
            ListView.Visibility = Visibility.Collapsed;
            CloseList.Visibility = Visibility.Hidden;
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            Help.ShowHelp(null, "help.chm");
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Help.ShowHelp(null, "help.chm");
            }
        }
    }
}