using IMIP.Tochu.Shared.enums;
using IMIP.Tochu.WPF.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.Helpers
{
    public static class MessageBoxManager
    {
        public static void ShowInfo(string message, string title = "Info")
        {
            Show(message, title, MessageType.Info);
        }

        public static void ShowSuccess(string message, string title = "Success")
        {
            Show(message, title, MessageType.Success);
        }

        public static void ShowError(string message, string title = "Error")
        {
            Show(message, title, MessageType.Error);
        }

        public static bool ShowConfirm(string message, string title = "Confirm")
        {
            var window = new CustomMessageBox(message, title, MessageType.Confirm);
            return window.ShowDialog() == true;
        }

        private static void Show(string message, string title, MessageType type)
        {
            var window = new CustomMessageBox(message, title, type);
            window.ShowDialog();
        }
    }
}
