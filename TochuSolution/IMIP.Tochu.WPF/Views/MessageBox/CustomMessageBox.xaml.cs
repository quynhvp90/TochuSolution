using IMIP.Tochu.Shared.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IMIP.Tochu.WPF.Views.MessageBox
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message, string title, MessageType type)
        {
            InitializeComponent();

            txtTitle.Text = title;
            txtMessage.Text = message;

            SetupUI(type);
        }

        private void SetupUI(MessageType type)
        {
            switch (type)
            {
                case MessageType.Info:
                    txtIcon.Text = "ℹ";
                    txtIcon.Foreground = Brushes.Blue;
                    btnCancel.Visibility = Visibility.Collapsed;
                    break;

                case MessageType.Success:
                    txtIcon.Text = "✔";
                    txtIcon.Foreground = Brushes.Green;
                    btnCancel.Visibility = Visibility.Collapsed;
                    break;

                case MessageType.Error:
                    txtIcon.Text = "✖";
                    txtIcon.Foreground = Brushes.Red;
                    btnCancel.Visibility = Visibility.Collapsed;
                    break;

                case MessageType.Confirm:
                    txtIcon.Text = "❓";
                    txtIcon.Foreground = Brushes.Orange;
                    btnCancel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
