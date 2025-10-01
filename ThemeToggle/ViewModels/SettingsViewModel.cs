using System.ComponentModel;
using ThemeToggle.Models;
using ThemeToggle.Services;

namespace ThemeToggle.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private ThemeOption _selectedTheme = ThemeService.CurrentTheme;

    public ThemeOption SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            if (_selectedTheme != value)
            {
                _selectedTheme = value;
                OnPropertyChanged(nameof(SelectedTheme));
                ThemeService.SetTheme(value);
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
