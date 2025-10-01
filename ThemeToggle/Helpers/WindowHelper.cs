using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using System.Collections.Generic;
using ThemeToggle.Models;
using ThemeToggle.Services;
using Windows.UI;

namespace ThemeToggle.Helpers;

public static class WindowHelper
{
    private static readonly List<Window> windows = new();

    public static void Register(Window window)
    {
        if (!windows.Contains(window))
        {
            windows.Add(window);
            window.Closed += (_, __) => windows.Remove(window);

            ApplyThemeToWindow(window, ThemeService.CurrentTheme);
        }
    }

    public static void ApplyTheme(ThemeOption theme)
    {
        foreach (Window window in windows)
        {
            ApplyThemeToWindow(window, theme);
        }
    }

    private static void ApplyThemeToWindow(Window window, ThemeOption theme)
    {
        if (window.Content is FrameworkElement root)
        {
            root.RequestedTheme = (ElementTheme)theme;

            if (window.AppWindow is not null)
            {
                Color fg = (ElementTheme)theme == ElementTheme.Light ? Colors.Black : Colors.White;
                Color hv = (ElementTheme)theme == ElementTheme.Light ? Color.FromArgb(127, 191, 191, 191) : Color.FromArgb(127, 63, 63, 63);
                window.AppWindow.TitleBar.ButtonForegroundColor = fg;
                window.AppWindow.TitleBar.ButtonHoverForegroundColor = fg;
                window.AppWindow.TitleBar.ButtonHoverBackgroundColor = hv;

                window.AppWindow.TitleBar.PreferredTheme = (ElementTheme)theme == ElementTheme.Light ? TitleBarTheme.Light : TitleBarTheme.Dark;
            }
        }
    }
}
