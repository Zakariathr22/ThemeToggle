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
                ElementTheme effectiveTheme = theme == ThemeOption.Default
                    ? (Application.Current.RequestedTheme == ApplicationTheme.Dark ? ElementTheme.Dark : ElementTheme.Light)
                    : (ElementTheme)theme;

                Color fg = effectiveTheme == ElementTheme.Dark ? Colors.White : Colors.Black;
                Color hv = effectiveTheme == ElementTheme.Dark
                    ? Color.FromArgb(127, 63, 63, 63)
                    : Color.FromArgb(127, 191, 191, 191);

                window.AppWindow.TitleBar.ButtonForegroundColor = fg;
                window.AppWindow.TitleBar.ButtonHoverForegroundColor = fg;
                window.AppWindow.TitleBar.ButtonHoverBackgroundColor = hv;

                window.AppWindow.TitleBar.PreferredTheme =
                    effectiveTheme == ElementTheme.Light ? TitleBarTheme.Light :
                    effectiveTheme == ElementTheme.Dark ? TitleBarTheme.Dark :
                    TitleBarTheme.UseDefaultAppMode;
            }
        }
    }

}
