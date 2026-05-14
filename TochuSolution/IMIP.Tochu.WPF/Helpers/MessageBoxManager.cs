using IMIP.Tochu.Shared;
using IMIP.Tochu.Shared.enums;
using IMIP.Tochu.WPF.Views.MessageBox;
using Microsoft.Extensions.DependencyInjection;

namespace IMIP.Tochu.WPF.Helpers
{
    public static class MessageBoxManager
    {
        private static ILocalizationService? Loc =>
            App.Services?.GetService<ILocalizationService>();

        public static void ShowInfo(string message, string? title = null)
        {
            Show(message, title ?? Loc?.Get("Msg_Info") ?? "Info", MessageType.Info);
        }

        public static void ShowSuccess(string message, string? title = null)
        {
            Show(message, title ?? Loc?.Get("Msg_Success") ?? "Success", MessageType.Success);
        }

        public static void ShowError(string message, string? title = null)
        {
            Show(message, title ?? Loc?.Get("Msg_Error") ?? "Error", MessageType.Error);
        }

        public static bool ShowConfirm(string message, string? title = null)
        {
            var resolvedTitle = title ?? Loc?.Get("Msg_Confirm") ?? "Confirm";
            var window = new CustomMessageBox(message, resolvedTitle, MessageType.Confirm);
            return window.ShowDialog() == true;
        }

        private static void Show(string message, string title, MessageType type)
        {
            var window = new CustomMessageBox(message, title, type);
            window.ShowDialog();
        }
    }
}
