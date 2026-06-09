using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AxControls;
using AxPropertyGrid.Samples.Models;

namespace AxPropertyGrid.Samples;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static readonly string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

    public MainWindow()
    {
        InitializeComponent();
        LoadLanguageSelection();
        LoadTestObject(0);
    }

    private void CmbTestObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (IsVisible)
        {
            if (cmbTestObject.SelectedIndex >= 0)
                LoadTestObject(cmbTestObject.SelectedIndex);
        }
    }

    private void LoadTestObject(int index)
    {
        switch (index)
        {
            case 0:
                // SampleObject: demonstrates attribute-based configuration
                pg.GridSetting = null;
                pg.SelectedObject = new SampleObject();
                break;
            case 1:
                // ServerConnectionSettings: demonstrates AxGridSetting fluent API
                pg.GridSetting = ServerConnectionSettings.BuildSettings();
                pg.SelectedObject = new ServerConnectionSettings();
                break;
            case 2:
                // ApplicationSettings: demonstrates [AxExplicitProperties] mode
                pg.GridSetting = null;
                pg.SelectedObject = new ApplicationSettings();
                break;
        }
    }

    private void LoadLanguageSelection()
    {
        var settings = AppSettings.Load();
        var culture = settings?.Language ?? "";

        for (int i = 0; i < cmbLanguage.Items.Count; i++)
        {
            if (cmbLanguage.Items[i] is ComboBoxItem item && item.Tag?.ToString() == culture)
            {
                cmbLanguage.SelectedIndex = i;
                return;
            }
        }
        cmbLanguage.SelectedIndex = 0;
    }

    private void ColorSwatch_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (sender is not Border border || border.Tag is not string hex) return;

        var color = (Color)ColorConverter.ConvertFromString(hex);
        ThemeManager.ApplyTheme(color);
    }

    private void CmbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbLanguage.SelectedItem is not ComboBoxItem item || !IsLoaded)
            return;

        var culture = item.Tag?.ToString() ?? "";
        var settings = AppSettings.Load() ?? new AppSettings();
        settings.Language = culture;
        settings.Save();

        if (!string.IsNullOrEmpty(culture))
        {
            var result = MessageBox.Show(
                $"The application needs to restart to apply the language change.\n\nRestart now?",
                "Restart Required",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }
    }

    private class AppSettings
    {
        public string Language { get; set; } = "";

        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

        public static AppSettings? Load()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    var json = File.ReadAllText(SettingsPath);
                    return JsonSerializer.Deserialize<AppSettings>(json);
                }
            }
            catch { }
            return null;
        }

        public void Save()
        {
            try
            {
                var json = JsonSerializer.Serialize(this, _jsonOptions);
                File.WriteAllText(SettingsPath, json);
            }
            catch { }
        }
    }
}
