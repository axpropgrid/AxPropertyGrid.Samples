using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace AxPropertyGrid.Samples;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");
        try
        {
            if (File.Exists(settingsPath))
            {
                var json = File.ReadAllText(settingsPath);
                var settings = JsonSerializer.Deserialize<AppSettingsDto>(json);
                if (!string.IsNullOrWhiteSpace(settings?.Language))
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.Language);
                }
            }
        }
        catch { }

        base.OnStartup(e);
    }

    private class AppSettingsDto
    {
        public string Language { get; set; } = "";
    }
}
