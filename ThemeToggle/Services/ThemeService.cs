using Microsoft.Windows.Storage;
using System;
using ThemeToggle.Models;

namespace ThemeToggle.Services;

public static class ThemeService
{
    private static ThemeOption _cachedTheme = ThemeOption.Default;
    public static ThemeOption CurrentTheme => _cachedTheme;

    public static event Action<ThemeOption>? ThemeChanged;

    public static void Initialize()
    {
        if (ApplicationData.GetDefault().LocalSettings.Values.TryGetValue("AppTheme", out object? themeValue) &&
            themeValue is int themeInt &&
            Enum.IsDefined(typeof(ThemeOption), themeInt))
        {
            _cachedTheme = (ThemeOption)themeInt;
        }
    }

    public static void SetTheme(ThemeOption theme)
    {
        if (_cachedTheme == theme) return;

        _cachedTheme = theme;
        ApplicationData.GetDefault().LocalSettings.Values["AppTheme"] = (int)theme;

        ThemeChanged?.Invoke(theme);
    }
}

