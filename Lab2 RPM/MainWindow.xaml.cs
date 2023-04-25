using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab2_RPM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string? NickName;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NicknameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox NicknameTextBox = (System.Windows.Controls.TextBox)sender;
            NicknameTextBox.Text = string.Empty;
            NicknameTextBox.GotFocus -= NicknameTextBox_GotFocus;
            NicknameTextBox.Foreground = Brushes.Black;
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            NickName = NicknameTextBox.Text;
            GameWindow GW = new GameWindow(NickName);
            GW.Show();
            this.Hide();
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
