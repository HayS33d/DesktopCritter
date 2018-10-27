using DesktopCritter.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DesktopCritter.Services
{
    public class WindowService
    {
        /// <summary>Contains functionality to get info on the open windows.</summary>
        public static class RunningWindows
        {
            private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

            public static List<WindowFrame> GetOpenedWindows()
            {
                IntPtr shellWindow = GetShellWindow();
                List<WindowFrame> windows = new List<WindowFrame>();

                EnumWindows(new EnumWindowsProc(delegate (IntPtr hWnd, int lParam)
                {
                    if (hWnd == shellWindow) return true;
                    if (!IsWindowVisible(hWnd)) return true;
                    
                    int length = GetWindowTextLength(hWnd);
                    if (length == 0) return true;
                    StringBuilder builder = new StringBuilder(length);
                    GetWindowText(hWnd, builder, length + 1);
                    RECT rct = new RECT();
                    GetWindowRect(hWnd, ref rct);

                    WindowFrame window = new WindowFrame
                    {
                        Handel = hWnd,
                        Title = builder.ToString(),
                        Left = rct.Left,
                        Top = rct.Top,
                        Right = rct.Right,
                        Bottom = rct.Bottom
                    };
                    windows.Add(window);
                    windows.Add(WindowBottom());
                    return true;
                }), 0);
                return windows;
            }
            private static WindowFrame WindowBottom()
            {
                WindowFrame w = new WindowFrame()
                {
                    Top = Screen.PrimaryScreen.Bounds.Bottom,
                    Left = Screen.PrimaryScreen.Bounds.Left,
                    Right = Screen.PrimaryScreen.Bounds.Right
                };
                return w;
            }
            [DllImport("USER32.DLL")]
            private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("USER32.DLL")]
            private static extern IntPtr GetShellWindow();

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

            [DllImport("USER32.DLL")]
            private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

            [DllImport("USER32.DLL")]
            private static extern int GetWindowTextLength(IntPtr hWnd);

            //WARN: Only for "Any CPU":
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern int GetWindowThreadProcessId(IntPtr handle, out uint processId);

            [DllImport("USER32.DLL")]
            private static extern bool IsWindowVisible(IntPtr hWnd);

            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
        }
    }
}