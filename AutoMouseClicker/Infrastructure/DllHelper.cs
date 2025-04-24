using System.Runtime.InteropServices;

namespace AutoMouseClicker.Infrastructure
{
    internal class DllHelper
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        public static extern void MouseEvent(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(nint hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(nint hWnd, int id);
    }
}