using System.Windows;
using System.Windows.Input;

namespace BlowFish
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Blowfish _bf = new Blowfish("blowfish");

        /// <summary>
        ///     Инициализация компонентов
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            OutputBox.Visibility = Visibility.Hidden;
            MainButton.Visibility = Visibility.Hidden;
            OpenEnvelopeImage.Visibility = Visibility.Hidden;
            ClosedEnvelopeImage.Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///     Функция удаления подсказки
        /// </summary>
        private void KeyInputMouseEnter(object sender, MouseEventArgs e)
        {
            InputBox.Text = "";
            InputBox.MouseEnter -= KeyInputMouseEnter;
        }

        /// <summary>
        ///     Функция текстовой подсказки
        /// </summary>
        private void InputBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "Enter your key here \n (E. g. \"blowfish\")";
        }

        /// <summary>
        ///     Функция подтверждения введённого ключа
        /// </summary>
        private void KeyButton_OnClick(object sender, RoutedEventArgs e)
        {
            KeyButton.Visibility = Visibility.Hidden;
            KeyImage.Visibility = Visibility.Hidden;
            OutputBox.Visibility = Visibility.Visible;
            MainButton.Visibility = Visibility.Visible;
            OpenEnvelopeImage.Visibility = Visibility.Visible;
            ClosedEnvelopeImage.Visibility = Visibility.Visible;
            Header.Text = "Encrypt/Decrypt";
            if (InputBox.Text == "")
                InputBox.Text = "blowfish";
            _bf = new Blowfish(InputBox.Text);
            InputBox.Text = "";
        }

        /// <summary>
        ///     Функция шифрования/дешифрования
        /// </summary>
        private void Go(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text != "" && OutputBox.Text == "")
            {
                OutputBox.Text = _bf.Encipher(InputBox.Text);
                InputBox.Text = "";
                MainButton.Content = "Encrypted";
            }
            else if (InputBox.Text == "" && OutputBox.Text != "")
            {
                InputBox.Text = _bf.Decipher(OutputBox.Text);
                OutputBox.Text = "";
                MainButton.Content = "Decrypted";
            }
            else if (InputBox.Text != "" && OutputBox.Text != "")
            {
                MainButton.Content = "Clear one of the fields";
            }
        }
    }
}