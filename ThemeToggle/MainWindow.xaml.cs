using Microsoft.UI.Xaml;
using ThemeToggle.Services;
using ThemeToggle.Views;

namespace ThemeToggle;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);

        MainFrame.Navigate(typeof(SettingsPage));
    }
}
