using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using ThemeToggle.Helpers;
using ThemeToggle.Models;
using ThemeToggle.ViewModels;

namespace ThemeToggle.Views;

public sealed partial class SettingsPage : Page
{
    private IReadOnlyList<ThemeOption> themeOptions { get; set; } = new List<ThemeOption>(Enum.GetValues<ThemeOption>());
    private SettingsViewModel ViewModel { get; } = new SettingsViewModel();

    public SettingsPage()
    {
        InitializeComponent();
    }

    private void NewWindowButton_Click(object sender, RoutedEventArgs e)
    {
        SecondaryWindow window = new();
        WindowHelper.Register(window);
        window.Activate();
    }
}
