using System.Windows;
using System.Windows.Media;
using AxControls.Controls;
using AxControls.Atrributes;

namespace AxPropertyGrid.Samples.Models
{
    /// <summary>
    /// Demonstrates [AxExplicitProperties] mode where only properties
    /// explicitly marked with [AxProperty] are shown.
    /// This example models application display settings.
    /// </summary>
    [AxExplicitProperties]
    public class ApplicationSettings
    {
        // --- These WILL appear (have [AxProperty]) ---

        [AxProperty("Window Title", "General", HelpText = "The title displayed in the window caption bar")]
        public string WindowTitle { get; set; } = "My Application";

        [AxProperty("Theme", "General", HelpText = "Select the application color theme")]
        public AppTheme Theme { get; set; } = AppTheme.Light;

        [AxProperty("Language", "General", HelpText = "Application display language")]
        public AppLanguage Language { get; set; } = AppLanguage.English;

        [AxProperty("Show Toolbar", "Layout", HelpText = "Show or hide the main toolbar", EditorStyle = ValueEditorStyle.Bool_ToggleSwitch)]
        public bool ShowToolbar { get; set; } = true;

        [AxProperty("Show Status Bar", "Layout", HelpText = "Show or hide the status bar", EditorStyle = ValueEditorStyle.Bool_ToggleSwitch)]
        public bool ShowStatusBar { get; set; } = true;

        [AxProperty("Font Size", "Appearance", HelpText = "Base font size in points")]
        [AxIntegerEdit(8, 72, 1, "", "pt")]
        public int FontSize { get; set; } = 12;

        [AxProperty("UI Scale", "Appearance", HelpText = "Interface scaling percentage")]
        [AxDecimalEdit(50, 300, 10, "", "%")]
        public double UiScale { get; set; } = 100.0;

        [AxProperty("Accent Color", "Appearance", HelpText = "Primary accent color for UI elements")]
        public Color AccentColor { get; set; } = Colors.DodgerBlue;

        [AxProperty("Background Color", "Appearance", HelpText = "Main background color")]
        public Color BackgroundColor { get; set; } = Colors.White;

        [AxProperty("Window Size", "Layout", HelpText = "Default window dimensions")]
        [AxSizeEdit(0, WidthText = "Width", HeightText = "Height", MinWidth = 640, MaxWidth = 3840, MinHeight = 480, MaxHeight = 2160)]
        public Size DefaultWindowSize { get; set; } = new Size(1280, 720);

        [AxProperty("Window Position", "Layout", HelpText = "Default window location")]
        [AxPointEdit(0)]
        public Point DefaultWindowPosition { get; set; } = new Point(100, 100);

        [AxProperty("Auto Save", "Behavior", HelpText = "Automatically save changes", EditorStyle = ValueEditorStyle.Bool_ToggleSwitch)]
        public bool AutoSave { get; set; } = true;

        [AxProperty("Auto Save Interval", "Behavior", HelpText = "Minutes between auto-saves")]
        [AxIntegerEdit(1, 60, 1, "", "min")]
        public int AutoSaveInterval { get; set; } = 5;

        [AxProperty("Max Undo Steps", "Behavior", HelpText = "Maximum number of undo history entries")]
        [AxIntegerEdit(10, 1000, 10)]
        public int MaxUndoSteps { get; set; } = 100;

        [AxProperty("Last Modified", "Info", HelpText = "Date when settings were last modified")]
        public DateTime LastModified { get; set; } = DateTime.Now;

        // --- These will NOT appear (no [AxProperty]) ---
        public string InternalId { get; set; } = Guid.NewGuid().ToString();
        public int SettingsVersion { get; set; } = 2;
        public bool IsDirty { get; set; } = false;
    }

    public enum AppTheme
    {
        [AxEnumValueDisplayText("Light")]
        Light,
        [AxEnumValueDisplayText("Dark")]
        Dark,
        [AxEnumValueDisplayText("System Default")]
        System,
        [AxEnumValueDisplayText("High Contrast")]
        HighContrast
    }

    public enum AppLanguage
    {
        English,
        Chinese,
        Japanese,
        Spanish
    }
}
